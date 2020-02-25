using business.Cache;
using business.Models;
using business.Models.CutModel;
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

        #region Get
        public override IEnumerable<IModelsBusiness> GetHR()
        {
            List<HRBusinessModel> hrs = _cache.HRs.HRs;
            return hrs;
        }

        public IEnumerable<IModelsBusiness> GetLeadsByStatus(int statusId)
        {
            List<CacheLeadsCombineByStatus> leads = _cache.Leads;
            List<LeadBusinessModel> leadBusinesses = new List<LeadBusinessModel>();
            foreach (CacheLeadsCombineByStatus item in leads)
            {
                if (item.StatusId == statusId)
                    foreach (LeadBusinessModel itemLead in item.Leads)
                    {
                        leadBusinesses.Add(itemLead);
                    }
            }
            return leadBusinesses;
        }

        public override IEnumerable<IModelsBusiness> GetTeacher()
        {
            List<TeacherBusinessModel> teachers = _cache.Teachers.Teachers;

            return teachers;
        }

        public override IEnumerable<IModelsBusiness> GetGroups()
        {
            List<GroupBusinessModel> groups = _cache.Groups.Groups;

            return groups;
        }
        #endregion
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
                leadBusinesses = item.Leads.FirstOrDefault(x => x.Id == id);
            }
            return leadBusinesses;
        }

       

        public override bool ChangeStatus(LeadBusinessModel lead, int statusId)
        {
            return defaultHR.ChangeStatus(lead, statusId);
        }
    }
}
