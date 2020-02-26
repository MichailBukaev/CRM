﻿using business.Cache;
using business.Models;
using business.Models.CutModel;
using business.WSHR.Cache;
using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSHR
{
    public class HeadHR : HeadHRDecorator
    {
        public HeadHR(DefaultHR hr) : base(hr)
        {
            _cache = hr.Cache;
        }

        public override IEnumerable<IModelsBusiness> GetHR()
        {
            if (!_cache.HRs.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheHRs(_cache.HRs, this._hr);
            List<HRBusinessModel> hrs = _cache.HRs.HRs;
            return hrs;
        }
        public IEnumerable<IModelsBusiness> GetLeadsByStatus(int statusId)
        {
            List<LeadBusinessModel> leadBusinesses = new List<LeadBusinessModel>();
            foreach (CacheLeadsCombineByStatus item in _cache.Leads)
            {
                if(item.StatusId == statusId)
                {
                    if(!item.FlagActual)
                        ReconstructorHRManagerCache.UpdateCacheLeads(item);
                    foreach (LeadBusinessModel itemLead in item.Leads)
                    {
                        leadBusinesses.Add(itemLead);
                    }
                }
            }
            
            return leadBusinesses;
        }
        public override IEnumerable<IModelsBusiness> GetTeacher()
        {
            if (!_cache.Teachers.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheTeachers(_cache.Teachers);
            List<TeacherBusinessModel> teachers = _cache.Teachers.Teachers;

            return teachers;
        }
        public override IEnumerable<IModelsBusiness> GetGroups()
        {
            if (!_cache.Groups.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheGroup(_cache.Groups);
            List<GroupBusinessModel> groups = _cache.Groups.Groups;

            return groups;
        }
        public override int? CreateLead(LeadBusinessModel _model)
        {
            return defaultHR.CreateLead(_model);
        }
        public override int? CreateGroup(GroupBusinessModel _model)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.Group;
            _storage = new StorageGroup();
            IEntity group = new Group()
            {
                NameGroup = _model.Name,
                StartDate = _model.StartDate
            };
            bool success = _storage.Add(ref group);

            if (success)
            {
                publisher.Notify();
                Group result = (Group)group;
                publishingHouse.CombineByGroup.Add(result.Id, new PublisherChangesInDB());
                return result.Id;
            }
            return null;
        }
        public override bool DeleteGroup(GroupBusinessModel _model)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.Group;
            _storage = new StorageGroup();
            Group group = new Group()
            {
                NameGroup = _model.Name,
                CourseId = _model.Course.Id,
                Course = GetCourse(_model.Course.Id),
                StartDate = _model.StartDate,
                TeacherId = _model.Teacher.Id,
                Teacher = GetTeacher(Convert.ToInt32(_model.Teacher.Id))
            };
            bool success = _storage.Delete(group);
            if (success)
                publisher.Notify();
            return success;
        }
        public override bool DeleteLead(LeadBusinessModel _model)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.CombineByStatus[_model.Status.Id];
            _storage = new StorageLead();
            Lead lead = new Lead()
            {
                FName = _model.FName,
                SName = _model.SName,
                DateBirthday = _model.DateBirthday,
                Numder = _model.Numder,
                EMail = _model.EMail,
                StatusId = _model.Status.Id,
                Status = GetStatus(_model.Status.Id),
                Login = _model.Login,
                Password = _model.Password

            };
            bool success = _storage.Delete(lead);
            if (success)
                publisher.Notify();
            return success;
        }
        public override bool UpdateLead(LeadBusinessModel _model)
        {
            return defaultHR.UpdateLead(_model);
        }        
        Course GetCourse(int id)
        {
            if (!_cache.Courses.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheCourses(_cache.Courses);
            Course course = null;
            foreach (CourseBusinessModel item in _cache.Courses.Courses)
            {
                if(item.Id == id)
                {
                    course = new Course() { Id = item.Id, Name = item.Name, CourseInfo = item.CourseInfo };
                }

            }           
            
            return course;
        }
        Teacher GetTeacher(int id)
        {
            if (!_cache.Teachers.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheTeachers(_cache.Teachers);
            Teacher teacher = null;
            foreach (TeacherBusinessModel item in _cache.Teachers.Teachers)
            {
                if (item.Id == id)
                {
                    teacher = new Teacher()
                    {
                        Id = item.Id,
                        FName = item.FName,
                        SName = item.SName,
                        Head = item.Head,
                        Login = item.Login,
                        Password = item.Password,
                        PhoneNumber = item.PhoneNumber
                    };
                }                
            }
            
            return teacher;
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
        LogBusinessModel GetLog(GroupBusinessModel group)
        {
            if (!_cache.Groups.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheGroup(_cache.Groups);
            List<GroupBusinessModel> groups = _cache.Groups.Groups;
            LogBusinessModel logBus = null;            

            foreach (GroupBusinessModel item in groups)
            {
                if (item.Id == group.Id)
                {
                    logBus = item.LogOfGroup;
                }
            }

            return logBus;
        }
        int GetTeacher(GroupBusinessModel group)
        {
            if (!_cache.Groups.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheGroup(_cache.Groups);
            int teacherId = 0;
            foreach (GroupBusinessModel item in _cache.Groups.Groups)
            {
                if (group.Teacher.Id != null)
                {
                    teacherId = Convert.ToInt32(group.Teacher.Id);
                }                
            }
            return teacherId;            
        }
        List<CutLeadBusinessModel> GetCutLead(GroupBusinessModel group)
        {
            if (!_cache.Groups.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheGroup(_cache.Groups);
            List<CutLeadBusinessModel> leadsInGroupBusiness = new List<CutLeadBusinessModel>();
            
            foreach (GroupBusinessModel item in _cache.Groups.Groups)
            {
                if (item.Id != group.Id)
                {
                    leadsInGroupBusiness = item.Leads;
                }                
            }
            return leadsInGroupBusiness;
        }     
        public override IModelsBusiness GetLead(int id)
        {
            LeadBusinessModel leadBusinesses = null;
            foreach (CacheLeadsCombineByStatus item in _cache.Leads)
            {
                if (!item.FlagActual)
                    ReconstructorHRManagerCache.UpdateCacheLeads(item);
                leadBusinesses = item.Leads.FirstOrDefault(x => x.Id == id);
            }
            return leadBusinesses;
        }

        public override bool ChangeStatus(LeadBusinessModel lead, int statusId)
        {
            return defaultHR.ChangeStatus(lead, statusId);
        }

        public override IModelsBusiness GetGroup(int id)
        {
            return defaultHR.GetGroup(id);
        }
        public override IEnumerable<IModelsBusiness> GetTasksMyself(int taskStatusId)
        {
            return defaultHR.GetTasksMyself(taskStatusId);
        }

        public override IEnumerable<IModelsBusiness> GetTasksMyself(DateTime taskStartDate)
        {
            return defaultHR.GetTasksMyself(taskStartDate);
        }

        public override IEnumerable<IModelsBusiness> GetTasksMyself()
        {
            return defaultHR.GetTasksMyself();
        }

        public IEnumerable<IModelsBusiness> GetTaskWorkForSlaves() //для всех hrs
        {            
            List<TaskWorkBusinessModel> taskBusinesses = new List<TaskWorkBusinessModel>();
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorHRManagerCache.UpdateCacheTaskWorkForSlaves(item, this._hr);
                foreach (TaskWorkBusinessModel task in item.TasksWork)
                {
                    taskBusinesses.Add(task);
                }
            }

            return taskBusinesses;
        }

        public IEnumerable<IModelsBusiness> GetTaskWorkForSlaves(HRBusinessModel hrExecutor) //для конкретного hr
        {
            List<TaskWorkBusinessModel> taskBusinesses = new List<TaskWorkBusinessModel>();
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorHRManagerCache.UpdateCacheTaskWorkForSlaves(item, this._hr);
                if (item.LoginExecuter == hrExecutor.Login)
                {
                    foreach (TaskWorkBusinessModel task in item.TasksWork)
                    {
                        taskBusinesses.Add(task);
                    }
                }
            }

            return taskBusinesses;
        }
        public IEnumerable<IModelsBusiness> GetTaskWorkForSlaves(HRBusinessModel hrExecutor, int taskStatusId) //для конкретного hr
        {
            List<TaskWorkBusinessModel> taskBusinesses = new List<TaskWorkBusinessModel>();
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorHRManagerCache.UpdateCacheTaskWorkForSlaves(item, this._hr);
                if (item.LoginExecuter == hrExecutor.Login)
                {
                    foreach (TaskWorkBusinessModel task in item.TasksWork)
                    {
                        if(task.TasksStatusId == taskStatusId)
                            taskBusinesses.Add(task);
                    }
                }
            }

            return taskBusinesses;
        }
        public IEnumerable<IModelsBusiness> GetTaskWorkForSlaves(HRBusinessModel hrExecutor, DateTime taskStartDate) //для конкретного hr
        {
            List<TaskWorkBusinessModel> taskBusinesses = new List<TaskWorkBusinessModel>();
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorHRManagerCache.UpdateCacheTaskWorkForSlaves(item, this._hr);
                if (item.LoginExecuter == hrExecutor.Login)
                {
                    foreach (TaskWorkBusinessModel task in item.TasksWork)
                    {
                        if(task.DateStart.CompareTo(taskStartDate) <= 0)
                            taskBusinesses.Add(task);
                    }
                }
            }

            return taskBusinesses;
        }
        public int SetTasksForSlaves(string taskText, DateTime deadLine, int tasksStatusId, string loginExecuter) 
        {
            int id = 0;
            TasksStatus status = GetTasksStatus(tasksStatusId);
            
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInTasks publisher = publishingHouse.CombineByExecuter[this._hr.Login];
            _storage = new StorageTaskWork();
            IEntity task = new TaskWork()
            {
                LoginAuthor = this._hr.Login,
                DateStart = DateTime.Now,
                DateEnd = deadLine,
                TasksStatusId = tasksStatusId,
                Text = taskText,
                LoginExecuter = loginExecuter,
                TasksStatus = status
            };
            bool success = _storage.Add(ref task);

            if (success)
            {
                publisher.Notify(this._hr.Login);
                TaskWork result = (TaskWork)task;
                publishingHouse.CombineByExecuter.Add(this._hr.Login, new PublisherChangesInTasks());
                id = result.Id;
                return id;
            }
            return id;
        }

        public override int SetTaskMyself(string taskText, DateTime deadline, int statusId)
        {
            return defaultHR.SetTaskMyself(taskText, deadline, statusId);
        }
        private TasksStatus GetTasksStatus(int taskStatusId)
        {
            TasksStatus status = null;
            foreach (TasksStatusBusinessModel item in _cache.TasksStatus.TasksStatus)
            {
                if (!_cache.TasksStatus.FlagActual)
                    ReconstructorHRManagerCache.UpdateCacheTasksStatus(_cache.TasksStatus);
                if (item.Id == taskStatusId)
                    status = new TasksStatus() { Id = item.Id, Name = item.Name };
            }
            return status;
        }
    }
}
