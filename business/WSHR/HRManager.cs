using business.Cache;

using business.Models;
using business.WSHR.Cache;
using business.WSHR.Headhr.Cache;
using business.WSTeacher.Cache;
using business.WSUser.interfaces;
using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSHR
{
    public class HRManager : IUserManager
    {
        HistoryWriter historyWriter;

        protected IStorage _storage;
        protected HRManagerCache _cache;
        protected HR _hr;
        public HRManagerCache Cache { get { return _cache; } }
        public HR hR { get { return _hr; } }
        public HRManager(int hrId)
        {
            _storage = new StorageHR();
            List<HR> hrs = (List<HR>)_storage.GetAll();
            _hr = hrs.FirstOrDefault(p => p.Id == hrId);
            historyWriter = new HistoryWriter();
            _cache = new HRManagerCache(this._hr);
            SetCache();
        }
        public void SetCache()
        {
            HREntityCache entityCache = new FillEntityCache(_hr).Fill();
            _cache = new FillHRManagerCache(entityCache, this._hr).Fill();
        }
        public IEnumerable<IModelsBusiness> GetLeadsByStatus(int statusId)
        {
            List<LeadBusinessModel> leadBusinesses = new List<LeadBusinessModel>();
            foreach (CacheLeadsCombineByStatus item in _cache.Leads)
            {
                if (item.StatusId == statusId)
                {
                    if (!item.FlagActual)
                        ReconstructorHRManagerCache.UpdateCacheLeads(item);
                    foreach (LeadBusinessModel lead in item.Leads)
                    {
                        leadBusinesses.Add(lead);
                    }
                }
            }

            return leadBusinesses;
        }
        Status GetStatus(int id)
        {
            if (!_cache.Statuses.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheStatus(_cache.Statuses);
            Status st = null;
            foreach (StatusBusinessModel item in _cache.Statuses.Statuses)
            {
                if (item.Id == id)
                {
                    st = new Status()
                    {
                        Id = item.Id,
                        Name = item.Name
                    };
                }

            }
            return st;
        }


        public IEnumerable<LeadBusinessModel> GetByFiltr(FiltrLeadBusinessModel model)
        {
           
            List<LeadBusinessModel> leadBusinesses = new List<LeadBusinessModel>();
            List<LeadBusinessModel> leads = new List<LeadBusinessModel>();
            

            foreach (CacheLeadsCombineByStatus item in _cache.Leads)
            {
                if (!item.FlagActual)
                    ReconstructorHRManagerCache.UpdateCacheLeads(item);
                
            }
            foreach (CacheLeadsCombineByStatus item in _cache.Leads)
            {
                
                leadBusinesses.AddRange(item.Leads);
                leads.AddRange(item.Leads);
            }
            int count = leadBusinesses.Count;
            foreach (LeadBusinessModel item in leadBusinesses)
            {
                if (model.SName != null && model.SName != item.SName)
                {
                    leads.Remove(item);
                    continue;
                }
                if (model.FName != null && model.FName != item.FName)
                {
                    leads.Remove(item);
                    continue;
                }
                if (model.DateBirthday != null && model.DateBirthday != item.DateBirthday)
                {
                    leads.Remove(item);
                    continue;
                }
                if (model.EMail != null && model.EMail != item.EMail)
                {
                    leads.Remove(item);
                    continue;
                }
                if (model.Skills.Count > 0 && !model.Skills.SequenceEqual(_cache.Skills.Skills))
                {
                    leads.Remove(item);
                    continue;
                }
                if (model.Numder > 0 && model.Numder != item.Numder)
                {
                    leads.Remove(item);
                    continue;
                }
                
            }
            return leads;
        }

        public bool SetTeacherToGroup(int groupId, int teacherId)
        {
            bool ok = false;
            if (!_cache.Groups.FlagActual)
            {
                ReconstructorHRManagerCache.UpdateCacheGroup(_cache.Groups);
            }
            GroupBusinessModel group = _cache.Groups.Groups.FirstOrDefault(x => x.Id == groupId);

            if (!_cache.Teachers.FlagActual)
            {
                ReconstructorHRManagerCache.UpdateCacheTeachers(_cache.Teachers);
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
                    return false;
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
                if (ok)
                {
                    historyWriter.AddTeacherToGroup(group.Id, teacherLocal.Id);
                    publisherGroupe.Notify();
                    publisherTeacher.Notify();

                }
            }
            return ok;
        }
        public bool UnSetTeacherToGroup(int groupId, int teacherId)
        {
            bool ok = false;
            if (!_cache.Groups.FlagActual)
            {
                ReconstructorHRManagerCache.UpdateCacheGroup(_cache.Groups);
            }
            GroupBusinessModel group = _cache.Groups.Groups.FirstOrDefault(x => x.Id == groupId);

            if (!_cache.Teachers.FlagActual)
            {
                ReconstructorHRManagerCache.UpdateCacheTeachers(_cache.Teachers);
            }
            TeacherBusinessModel teacherLocal = _cache.Teachers.Teachers.FirstOrDefault(p => p.Id == teacherId);

            if (teacherLocal != null && group != null)
            {
            

                Group currentGroup = new Group()
                {
                    Id = group.Id,
                    CourseId = group.Course.Id,
                    StartDate = group.StartDate,
                    NameGroup = group.Name,
                    TeacherId = null

                };

                _storage = new StorageGroup();
                ok = _storage.Update(currentGroup);
                PublishingHouse publishingHouse = PublishingHouse.Create();

                PublisherChangesInDB publisherGroupe = publishingHouse.Group,
                                     publisherTeacher = publishingHouse.Teacher;
                if (ok)
                {
                    historyWriter.DeleteTeacherToGroup(group.Id, teacherLocal.Id);
                    publisherGroupe.Notify();
                    publisherTeacher.Notify();

                }
            }
            return ok;
        }

        public int? CreateLead(LeadBusinessModel _model)
        {
            if (InspectorLogin.CheckUniqueness(_model.Login))
            {
                Status status = new Status() { Id = 1, Name = "NewLead" };
                if (_model.Status.Id > 0)
                {
                    status = new Status()
                    {
                        Id = _model.Status.Id,
                        Name = _model.Status.Name
                    };
                        
                };
                PublishingHouse publishingHouse = PublishingHouse.Create();

                PublisherChangesInDB publisher = publishingHouse.CombineByStatus[_model.Status.Id];
                _storage = new StorageLead();
                IEntity lead = new Lead
                {
                    FName = _model.FName,
                    SName = _model.SName,
                    Numder = _model.Numder,
                    DateBirthday = _model.DateBirthday,
                    StatusId = status.Id,
                    EMail = _model.EMail,
                    AccessStatus = true,
                    DateRegistration = Convert.ToString(DateTime.UtcNow),
                    Login = _model.Login,
                    Password = _model.Password
                };

                bool success = _storage.Add(ref lead);
                Lead result = (Lead)lead;
                if (success)
                {
                    historyWriter.CreateLead(ref result, status.Name);
                    publisher.Notify();
                    return result.Id;
                }
            }
            return null;
        }
        public IEnumerable<IModelsBusiness> GetTeacher()
        {
            if (!_cache.Teachers.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheTeachers(_cache.Teachers);
            List<TeacherBusinessModel> teachersBusiness = _cache.Teachers.Teachers;

            return teachersBusiness;
        }
        public bool UpdateLead(LeadBusinessModel _model)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.CombineByStatus[_model.Status.Id];
            _storage = new StorageLead();
            Lead lead = new Lead
            {
                Id = _model.Id,
                FName = _model.FName,
                SName = _model.SName,
                Numder = _model.Numder,
                DateBirthday = _model.DateBirthday,
                StatusId = _model.Status.Id,
                EMail = _model.EMail,
                Login = _model.Login,
                Password = _model.Password
            };
            bool success = _storage.Update(lead);
            if (success)
            {
                historyWriter.UpdateLead(lead);
                publisher.Notify();

            }
            return success;
        }
        public override IModelsBusiness GetLead(int id)
        {
            LeadBusinessModel leadBusinesses = null;
            foreach (CacheLeadsCombineByStatus item in _cache.Leads)
            {
                if (!item.FlagActual)
                    ReconstructorHRManagerCache.UpdateCacheLeads(item);
                leadBusinesses = item.Leads.FirstOrDefault(x => x.Id == id);
                if (leadBusinesses != null)
                {
                    break;
                }
            }
            return leadBusinesses;
        }
        public bool ChangeStatus(LeadBusinessModel _model, int statusId)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisheFirst = publishingHouse.CombineByStatus[_model.Status.Id];
            PublisherChangesInDB publisheSecond = publishingHouse.CombineByStatus[statusId];
            LeadBusinessModel leadBusiness = new LeadBusinessModel();
            StatusBusinessModel statusBusiness = new StatusBusinessModel();
            _storage = new StorageLead();
            bool success = false;
            for (int i = 0; i < _cache.Leads.Count; i++)
            {
                leadBusiness = _cache.Leads[i].Leads.FirstOrDefault(p => p.Id == _model.Id);
                if (leadBusiness != null)
                {
                    statusBusiness = _cache.Statuses.Statuses.FirstOrDefault(p => p.Id == statusId);
                    break;
                }
            }
            if (leadBusiness != null)
            {
                Lead lead = new Lead
                {
                    Id = _model.Id,
                    FName = _model.FName,
                    SName = _model.SName,
                    Numder = _model.Numder,
                    DateBirthday = _model.DateBirthday,
                    StatusId = statusId,
                    EMail = _model.EMail,
                    Login = _model.Login,
                    Password = _model.Password
                };
                success = _storage.Update(lead);
                if (success)
                {
                    historyWriter.ChangeStatus(lead.Id, statusBusiness.Name);
                    publisheFirst.Notify();
                    publisheSecond.Notify();
                }
            }
            return success;
        }


        public override IModelsBusiness GetGroup(int id)
        {
            if (!_cache.Groups.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheGroup(_cache.Groups);
            GroupBusinessModel group = _cache.Groups.Groups.FirstOrDefault(x => x.Id == id);
            return group;
        }
        public IEnumerable<IModelsBusiness> GetTasksMyself(int taskStatusId)
        {
            if (!_cache.TaskWorkMyself.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheTaskWorkMyself(_cache.TaskWorkMyself, this._hr);
            List<TaskWorkBusinessModel> taskBusinesses = new List<TaskWorkBusinessModel>();
            foreach (TaskWorkBusinessModel item in _cache.TaskWorkMyself.TasksWork)
            {
                if (item.TasksStatusId == taskStatusId)
                {
                    taskBusinesses.Add(item);
                }
            }

            return taskBusinesses;
        }
        public IEnumerable<IModelsBusiness> GetTasksMyself(DateTime taskStartDate)
        {
            if (!_cache.TaskWorkMyself.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheTaskWorkMyself(_cache.TaskWorkMyself, this._hr);
            List<TaskWorkBusinessModel> taskBusinesses = new List<TaskWorkBusinessModel>();
            foreach (TaskWorkBusinessModel item in _cache.TaskWorkMyself.TasksWork)
            {
                if (item.DateStart.CompareTo(taskStartDate) <= 0)
                {
                    taskBusinesses.Add(item);
                }
            }

            return taskBusinesses;
        }
        public IEnumerable<IModelsBusiness> GetTasksMyself()
        {
            if (!_cache.TaskWorkMyself.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheTaskWorkMyself(_cache.TaskWorkMyself, this._hr);
            List<TaskWorkBusinessModel> taskBusinesses = new List<TaskWorkBusinessModel>();
            foreach (TaskWorkBusinessModel item in _cache.TaskWorkMyself.TasksWork)
            {
                taskBusinesses.Add(item);
            }

            return taskBusinesses;
        }

        public int? SetTaskMyself(string taskText, DateTime deadline, int statusId)
        {
            int? id = null;           
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInTasks publisher = publishingHouse.CombineByExecuter[this._hr.Login];
            _storage = new StorageTaskWork();
            IEntity task = new TaskWork()
            {
                LoginAuthor = this._hr.Login,
                DateStart = DateTime.Now,
                DateEnd = deadline,
                TasksStatusId=statusId, 
                Text = taskText,
                LoginExecuter = this._hr.Login,
                
            };
            bool success = _storage.Add(ref task);

            if (success)
            {
                publishingHouse.CombineByExecuter[this._hr.Login].Notify(this._hr.Login);
                TaskWork result = (TaskWork)task;                
                id = result.Id;
                return id;
            }
            return id;
        }

        public override IModelsBusiness GetTacher(int teacherId)
        {
            TeacherBusinessModel teacher = null;
            if (!_cache.Teachers.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheTeachers(_cache.Teachers);
            foreach (TeacherBusinessModel item in _cache.Teachers.Teachers)
            {
                if (item.Id == teacherId)
                {
                    teacher = item;
                    break;
                }
            }

            return teacher;
        }

        public override IModelsBusiness GetCourse(int id)
        {
            CourseBusinessModel course = null;
            if (!_cache.Courses.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheCourses(_cache.Courses);
            foreach (CourseBusinessModel item in _cache.Courses.Courses)
            {
                if (item.Id == id)
                {
                    course = item;
                    break;
                }
            }
            return course;

        }
    }
}
