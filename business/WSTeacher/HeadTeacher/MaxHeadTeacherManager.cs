using business.Cache;
using business.Models;
using business.WSTeacher.Cache;
using business.WSUser.interfaces;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSTeacher.HeadTeacher
{
    public class MaxHeadTeacherManager : TeacherManagerDecorater
    {
        public MaxHeadTeacherManager(TeacherManager teacherManager)
            : base(teacherManager)
        {
            _cache = teacherManager.Cache;

        }
        public override bool AddSkillsForLead(int skillId, int LeadId)
        {
            return base.AddSkillsForLead(skillId, LeadId);
        }

        public override bool SetAttendence(DayInLogBusinessModel dayLog)
        {
            return base.SetAttendence(dayLog);
        }

        public int? AddNewSkill(SkillBusinessModel skill)
        {
            _storage = new StorageSkills();
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.Skills;
            IEntity skills = new Skills()
            {
                NameSkills = skill.NameSkill
            };
            if (_storage.Add(ref skills))
            {
                publisher.Notify();
                Skills newSkills = (Skills)skills;
                return newSkills.Id;
            }
            else
            {
                return null;
            }

        }

        public bool AssignTeacherForGroup(int teacherId, int groupeId)
        {
            bool ok = false;
            if (!_cache.Group.FlagActual)
            {
                ReconstructorTeacherManagerCache.UpdateCacheGroup(_cache.Group, _teacherManager.Teacher);
            }
            GroupBusinessModel group = _cache.Group.Groups.FirstOrDefault(x => x.Id == groupeId);

            if (!_cache.Teachers.FlagActual)
            {
                ReconstructorTeacherManagerCache.UpdateCacheTeachers(_cache.Teachers, _teacherManager.Teacher);
            }
            TeacherBusinessModel teacherLocal = _cache.Teachers.Teachers.FirstOrDefault(p => p.Id == teacherId);

            if (teacherLocal != null && group != null)
            {
                bool flag = false;
                for (int i = 0; i < teacherLocal.Courses.Count; i++)
                {
                    if (group.Course.Id == teacherLocal.Courses[i].Id)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    throw new Exception($"Этот преподаватель не может вести группу с курсом {group.Course.Name}");
                }

                Group currentGroup = new Group()
                {
                    Id = group.Id,
                    CourseId = group.Course.Id,
                    StartDate = group.StartDate,
                    NameGroup = group.Name,
                    TeacherId = teacherLocal.Id

                };

                _storage = new StorageGroup();
                ok = _storage.Update(currentGroup);
                PublishingHouse publishingHouse = PublishingHouse.Create();

                PublisherChangesInDB publisherGroupe = publishingHouse.Group,
                                     publisherTeacher = publishingHouse.Teacher;
                publisherGroupe.Notify();
                publisherTeacher.Notify();
            }
            return ok;
        }
        public int? AddNewCourse(CourseBusinessModel model)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.Courses;
            _storage = new StorageCourse();
            IEntity course = new Course
            {
                Name = model.Name,
                CourseInfo = model.CourseInfo
            };
            ;
            if (_storage.Add(ref course))
            {
                publisher.Notify();
                Course newCourse = (Course)course;
                return newCourse.Id;
            }
            else
            {
                return null;
            }

        }
        public override List<GroupBusinessModel> GetAllGroupe()
        {
            return base.GetAllGroupe();
        }

        public override List<CourseBusinessModel> GetAllCourse()
        {
            return base.GetAllCourse();
        }

        public override bool SetSelfTask(string task, DateTime deadLine, int tasksStatusId)
        {
            return base.SetSelfTask(task, deadLine, tasksStatusId);
        }

        public override IModelsBusiness GetLead(int id)
        {
            LeadBusinessModel leadBusinesses = null;
            foreach (CacheLeadsCombineByGroup item in _cache.Leads)
            {
                leadBusinesses = item.Leads.FirstOrDefault(x => x.Id == id);
            }
            return leadBusinesses;
        }

        public override List<TaskWorkBusinessModel> GetMyselfTask()
        {
            return base.GetMyselfTask();
        }

        public int? SetTasksForSlaves(string task, DateTime deadLine, int tasksStatusId, string loginExecuter)
        {
            
            PublishingHouse publishingHouse = PublishingHouse.Create();
            _storage = new StorageTaskWork();
            IEntity slavesTask = new TaskWork()
            {
                DateStart = DateTime.Now,
                DateEnd = deadLine,
                Text = task,
                LoginAuthor = _teacher.Login,
                LoginExecuter = loginExecuter,
                TasksStatusId = tasksStatusId
            };
            if (_storage.Add(ref slavesTask))
            {

                publishingHouse.CombineByExecuter[loginExecuter].Notify(_teacher.Login);
                TaskWork taskSet = (TaskWork)slavesTask;
                return taskSet.Id;
            }
            else
                return null;
        }
        public override List<TaskWorkBusinessModel> GetAllMyTask()
        {
            return base.GetAllMyTask();
        }

        public override List<TaskWorkBusinessModel> GetAllMyTask(string nameStatus)
        {
            return base.GetAllMyTask(nameStatus);
        }

        public override List<TaskWorkBusinessModel> GetAllMyTask(DateTime dateStart)
        {
            return base.GetAllMyTask(dateStart);
        }

        public List<TaskWorkBusinessModel> GetAllTasksForSlaves()
        {
            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();
            
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheTaskForSlaves(item, _teacher.Login);
                if(item.TasksWork.Count>0)
                {
                    tasks.AddRange(item.TasksWork);
                }
                
            }
            return tasks;
        }
        public List<TaskWorkBusinessModel> GetAllTasksForSlaves(string nameStatus)
        {
            if (!_cache.TasksStatus.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheMyselfTask(_cache.TaskWorkMyself, _teacher.Login);
            TasksStatusBusinessModel tasksStatuses = _cache.TasksStatus.TasksStatus.FirstOrDefault(x => x.Name == nameStatus);

            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheTaskForSlaves(item, _teacher.Login);
                if (item.TasksWork.Count > 0)
                {
                    tasks.AddRange(item.TasksWork.Where(x => x.TasksStatusId == tasksStatuses.Id).ToList());
                }

            }
            return tasks;
        }
        public List<TaskWorkBusinessModel> GetAllTasksForSlaves(DateTime dateStart)
        {
            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();

            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheTaskForSlaves(item, _teacher.Login);
                if (item.TasksWork.Count > 0)
                {
                    tasks.AddRange(item.TasksWork.Where(x => x.DateStart.CompareTo(dateStart) > 0).ToList());
                }

            }
            return tasks;

        }
        public override IModelsBusiness GetGroup(int id)
        {
            if (!_cache.Group.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheGroup(_cache.Group, _teacher);
            GroupBusinessModel group = _cache.Group.Groups.FirstOrDefault(x => x.Id == id);
            return group;

        }
    }
}
