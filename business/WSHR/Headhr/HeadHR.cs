using business.Models;
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
        IStorage _storage;
        PublisherChangesInBD _publisher;
        HeadHRCache _cache;

        public HeadHR(DefaultHR hr)
        {
            this.defaultHR = hr;
            _publisher = PublisherChangesInBD.GetPublisher();
            _cache = new HeadHRCache();
            SetCache();
        }
        public override void SetCache()
        {
            if (_cache.FlagActual == false)
            {
                _storage = new StorageLead();
                _cache.Leads = (List<Lead>)_storage.GetAll();
                _storage = new StorageTeacher();
                _cache.Teachers = (List<Teacher>)_storage.GetAll();
                _storage = new StorageGroup();
                _cache.Groups = (List<Group>)_storage.GetAll();
                _storage = new StorageHR();
                _cache.Hrs = (List<HR>)_storage.GetAll();
                _storage = new StorageLog();
                _cache.Logs = (List<Log>)_storage.GetAll();
                _cache.FlagActual = true;
            }
        }
        #region Get
        public override IEnumerable<IModelsBusiness> GetHR()
        {
            List<HR> hrs = _cache.Hrs;
            List<HRBusinessModel> hrsBusiness = new List<HRBusinessModel>();
            foreach (HR item in hrs)
            {
                if (!item.Head)
                {
                    hrsBusiness.Add(new HRBusinessModel
                    {
                        Id = item.Id,
                        FName = item.FName,
                        SName = item.SName
                    });
                }
               
            };
            return hrsBusiness;
        }
        public override IEnumerable<IModelsBusiness> GetLead()
        {
            List<Lead> leads = _cache.Leads;
            List<LeadBusinessModel> leadBusinesses = new List<LeadBusinessModel>();
            foreach (Lead item in leads)
            {
                leadBusinesses.Add(new LeadBusinessModel
                {
                    FName = item.FName,
                    SName = item.SName,
                    Numder = item.Numder,
                    DateBirthday = item.DateBirthday,
                    Status = item.Status.Name,
                    EMail = item.EMail,
                    Login = item.Login,
                    Password = item.Password
                });
            }
            return leadBusinesses;
        }

        public override IEnumerable<IModelsBusiness> GetTeacher()
        {
            List<Teacher> teachers = _cache.Teachers;
            List<TeacherBusinessModel> teachersBusiness = new List<TeacherBusinessModel>();
            foreach (Teacher item in teachers)
            {
                teachersBusiness.Add(new TeacherBusinessModel
                {
                    Id = item.Id,
                    FName = item.FName,
                    SName = item.SName,
                    PhoneNumber = item.PhoneNumber
                });
            };
            return teachersBusiness;
        }
        public override IEnumerable<IModelsBusiness> GetGroups()
        {
            List<Group> groups = _cache.Groups;
            List<GroupBusinessModel> groupBusinesses = new List<GroupBusinessModel>();
            foreach (Group item in groups)
            {
                groupBusinesses.Add(new GroupBusinessModel
                {
                    Name = item.NameGroup,
                    CourseId = item.CourseId,
                    CourseName = item.Course.Name,
                    TeacherId = GetTeacher(item),
                    Leads = GetLeads(item),
                    StartDate = item.StartDate,
                    LogOfGroup = GetLog(item)
                });
            }
            return groupBusinesses;
        }
        #endregion
        public override bool CreateLead(LeadBusinessModel _model)
        {
            return defaultHR.CreateLead(_model);
        }
        public override bool CreateGroup(GroupBusinessModel _model)
        {
            _storage = new StorageGroup();
            Group group = new Group()
            {
                NameGroup = _model.Name,      
                StartDate = _model.StartDate
            };
            bool success = _storage.Add(group);
            if (success)
                _publisher.Notify(group);
            return success;
        }
       
        public override bool DeleteGroup(GroupBusinessModel _model)
        {
            _storage = new StorageGroup();
            Group group = new Group()
            {
                NameGroup = _model.Name,
                CourseId = _model.CourseId,
                Course = GetCourse(_model.CourseId),
                StartDate = _model.StartDate,
                TeacherId = _model.TeacherId,
                Teacher = GetTeacher(_model.TeacherId)
            };
            bool success = _storage.Add(group);
            if (success)
                _publisher.Notify(group);
            return success;
        }

        public override bool DeleteLead(LeadBusinessModel _model)
        {
            _storage = new StorageLead();
            Lead lead = new Lead()
            {
                FName = _model.FName,
                SName = _model.SName,
                DateBirthday = _model.DateBirthday,
                Numder = _model.Numder,
                EMail = _model.EMail,
                StatusId = GetStatus(_model.Status).Id,
                Status = GetStatus(_model.Status),
                Login = _model.Login,
                Password = _model.Password

            };
            bool success = _storage.Add(lead);
            if (success)
                _publisher.Notify(lead);
            return success;
        }

        public override bool UpdateLead(LeadBusinessModel _model)
        {
            return defaultHR.UpdateLead(_model);
        }


        Course GetCourse(int id)
        {
            _storage = new StorageCourse();
            List<Course> courses = (List<Course>)_storage.GetAll();
            Course course = courses.FirstOrDefault(x => x.Id == id);
            return course;
        }
        Teacher GetTeacher(int id)
        {
            _storage = new StorageTeacher();
            List<Teacher> teachers = _cache.Teachers;
            Teacher teacher = teachers.FirstOrDefault(x => x.Id == id);
            return teacher;
        }
        Status GetStatus(string name)
        {
            _storage = new StorageStatus();
            List<Status> statuses = (List<Status>)_storage.GetAll();
            Status st = statuses.FirstOrDefault(x => x.Name == name);
            return st;
        }
        List<LeadBusinessModel> GetLeads(Group group)
        {
            _storage = new StorageLead();
            List<LeadBusinessModel> leadsInGroupBusiness = new List<LeadBusinessModel>();
            List<Lead> leads = _cache.Leads;
            foreach (Lead item in leads)
            {
                if (item.Group.Id != group.Id)
                {
                    leads.Remove(item);
                }
                leadsInGroupBusiness.Add(new LeadBusinessModel()
                {
                    Id = item.Id,
                    FName = item.FName,
                    SName = item.SName
                });
            }
            return leadsInGroupBusiness;
        }
        LogBusinessModel GetLog(Group group)
        {
            List<Lead> leads = _cache.Leads;
            LogBusinessModel logBus = null;
            List<Log> logs = _cache.Logs;
            List<DayInLogBusinessModel> dayInLogs = new List<DayInLogBusinessModel>();
            List<StudentInLogBusinessModel> studentsInLog = new List<StudentInLogBusinessModel>();
            
            foreach (Log item in logs)
            {
                foreach (Lead lead in leads)
                {
                    if (group.Id == lead.GroupId)
                    {
                        studentsInLog.Add(new StudentInLogBusinessModel
                        {
                            LeadId = lead.Id,
                            LeadFName = lead.FName,
                            LeadSName = lead.SName,
                            Visit = item.Visit
                        });
                    }
                }
                dayInLogs.Add(new DayInLogBusinessModel{ 
                    Date = item.Date,
                    StudentsInLog = studentsInLog
                });
                studentsInLog.Clear();
            }
            logBus = new LogBusinessModel()
            {
                GroupId = group.Id,
                GroupName = group.NameGroup,
                Days = dayInLogs
            };
            return logBus;
        }
        int GetTeacher(Group group)
        {
            if (group.TeacherId != null)
            {
                return Convert.ToInt32(group.TeacherId);
            } else
            {
                return 0;
            }
        }
    }
}
