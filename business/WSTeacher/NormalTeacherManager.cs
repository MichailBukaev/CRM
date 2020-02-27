using business.Cache;
using business.Models;
using business.WSTeacher.Cache;
using business.WSTeacher.Cache.CacheEntity;
using business.WSUser.interfaces;
using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSTeacher
{
    public class NormalTeacherManager : IUserManager
    {
        HistoryWriter historyWriter;
        protected IStorage _storage;
        protected TeacherManagerCache _cache;
        protected Teacher _teacher;
        public TeacherManagerCache Cache { get { return _cache; } }
        public Teacher Teacher { get { return _teacher; } }
        public NormalTeacherManager(int teacherId)
        {
            _storage = new StorageTeacher();
            List<Teacher> teachers = (List<Teacher>)_storage.GetAll();
            _teacher = teachers.FirstOrDefault(p => p.Id == teacherId);
            _cache = new TeacherManagerCache(_teacher);
            historyWriter = new HistoryWriter();
            SetCache();
        }

        public  bool AddSkillsForLead(int skillId, int LeadId)
        {
            bool ok = false;

            LeadBusinessModel lead = null;
            GroupBusinessModel group = null;
            for(int i = 0; i<_cache.Leads.Count; i++)
            {
                if (!_cache.Leads[i].FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheLeads(_cache.Leads[i]);
                lead = _cache.Leads[i].Leads.FirstOrDefault(p => p.Id == LeadId);
                if (lead != null)
                {
                    if(!_cache.Group.FlagActual)
                        ReconstructorTeacherManagerCache.UpdateCacheGroup(_cache.Group, _teacher);
                    group = _cache.Group.Groups.FirstOrDefault(p => p.Id == _cache.Leads[i].GroupId);
                    break;
                }
            }
            SkillBusinessModel skill = _cache.Skills.Skills.FirstOrDefault(p => p.IdSkill == skillId);
            if (lead != null && skill != null)
            {
                PublishingHouse publishingHouse = PublishingHouse.Create();
                PublisherChangesInDB publisher = publishingHouse.CombineByGroup[group.Id];
                _storage = new StorageSkillsLead();
                SkillsLead skillsLead = new SkillsLead() { 
                    LeadId = lead.Id,
                    SkillsId = skill.IdSkill
                };
                IEntity entity = skillsLead;
                _storage = new StorageSkillsLead();
                historyWriter.AddSkills(LeadId, skill.NameSkill);
                ok = _storage.Add(ref entity);
                publisher.Notify();
            }
            return ok;
        }

        public  List<CourseBusinessModel> GetAllCourse()
        {
            if (!_cache.Course.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheCourses(_cache.Course, _teacher);
            List<CourseBusinessModel> courses = _cache.Course.Courses;
            return courses;
        }

        public  List<GroupBusinessModel> GetAllGroupe()
        {
            if (!_cache.Group.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheGroup(_cache.Group, _teacher);
            List<GroupBusinessModel> groups = _cache.Group.Groups;
            return groups;
        }


        public  List<TaskWorkBusinessModel> GetAllMyTask()
        {
            if (!_cache.TaskWorkMyself.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheMyselfTask(_cache.TaskWorkMyself, _teacher.Login);
            List<TaskWorkBusinessModel> tasks = _cache.TaskWorkMyself.TasksWork;
            return tasks;
        }

        public  List<TaskWorkBusinessModel> GetAllMyTask(string nameStatus)
        {
            if(!_cache.TasksStatus.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheMyselfTask(_cache.TaskWorkMyself, _teacher.Login);
            TasksStatusBusinessModel tasksStatuses = _cache.TasksStatus.TasksStatus.FirstOrDefault(x => x.Name == nameStatus);

            if (!_cache.TaskWorkMyself.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheMyselfTask(_cache.TaskWorkMyself, _teacher.Login);
            List<TaskWorkBusinessModel> tasks = _cache.TaskWorkMyself.TasksWork.Where(x => x.TasksStatusId == tasksStatuses.Id).ToList();
            return tasks;
        }

        public  List<TaskWorkBusinessModel> GetAllMyTask(DateTime dateStart)
        {
            if (!_cache.TaskWorkMyself.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheMyselfTask(_cache.TaskWorkMyself, _teacher.Login);
            List<TaskWorkBusinessModel> tasks = _cache.TaskWorkMyself.TasksWork.Where(x => x.DateStart.CompareTo(dateStart) > 0).ToList();
            return tasks;
        }
        public override IModelsBusiness GetGroup(int id)
        {
            if (!_cache.Group.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheGroup(_cache.Group, _teacher);
            GroupBusinessModel group = _cache.Group.Groups.FirstOrDefault(x => x.Id == id);
            return group;

        }

        public override IModelsBusiness GetLead(int id)
        {
            LeadBusinessModel leadBusinesses = null;
            foreach (CacheLeadsCombineByGroup item in _cache.Leads)
            {
                leadBusinesses = item.Leads.FirstOrDefault(x => x.Id == id);
                if (leadBusinesses != null)
                    return leadBusinesses;
            }
            return leadBusinesses;
        }

        public override IModelsBusiness GetTacher(int teacherId)
        {
            if (!_cache.Teachers.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheTeachers(_cache.Teachers, _teacher);
            return _cache.Teachers.Teachers.FirstOrDefault(p => p.Id == teacherId);
        }

        public  bool SetAttendence(DayInLogBusinessModel dayLog)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.Group;
            _storage = new StorageLog();
            bool ok = true;
            for (int i = 0; i < dayLog.StudentsInLog.Count; i++)
            {
                IEntity log = new Log()
                {
                    Date = dayLog.Date,
                    LeadId = dayLog.StudentsInLog[i].Lead.Id,
                    Visit = dayLog.StudentsInLog[i].Visit
                };
                if (!_storage.Add(ref log))
                    ok = false;
                else
                    publisher.Notify();
            }
            return ok;
        }

        public  int? SetSelfTask(string task, DateTime deadLine, int tasksStatusId)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
           
            _storage = new StorageTaskWork();
            IEntity myTask = new TaskWork()
            {
                DateStart = DateTime.Now,
                DateEnd = deadLine,
                Text = task,
                TasksStatusId = tasksStatusId,
                LoginAuthor = _teacher.Login,
                LoginExecuter = _teacher.Login
            };
            if (_storage.Add(ref myTask))
            {
                publishingHouse.CombineByExecuter[_teacher.Login].Notify(_teacher.Login);
                TaskWork taskWork = (TaskWork)myTask;
                return taskWork.Id;
            }
            else
                return null;
                
        }

        private void SetCache()
        {
            TeacherEntityCache entityCache = new FillEntityCache(_teacher).Fill();
            _cache = new FillTeacherManagerCache(entityCache, _teacher).Fill();
        }
      
    }
}
