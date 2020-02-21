//using business.Models;
//using business.WSUser.interfaces;
//using data.Storage;
//using data.StorageEntity;
//using models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace business.WSHR
//{
//    public class HRManager : DefaultHR
//    {
//        HRManagerCache _cache;
//        IStorage _storage;
//        PublisherChangesInDB _publisher;
//        public HRManager()
//        {
//            _cache = new HRManagerCache();
//            _publisher = PublisherChangesInDB.GetPublisher();
//            SetCache();
//        }

//        //метод заполнения cache
//        public override void SetCache()
//        {
//            if (_cache.FlagActual == false)
//            {
//                _storage = new StorageLead();
//                _cache.Leads = (List<Lead>)_storage.GetAll();
//                _storage = new StorageTeacher();
//                _cache.Teachers = (List<Teacher>)_storage.GetAll();
//                _cache.FlagActual = true;
//            }
//        }

//        public override IEnumerable<IModelsBusiness> GetLeads()
//        {
//            IEnumerable<IEntity> leads = _cache.Leads;
//            if (leads == null)
//            {
//                _storage = new StorageLead();
//                leads = _storage.GetAll();
//            }
//            List<LeadBusinessModel> leadBusinesses = new List<LeadBusinessModel>();
//            foreach (Lead item in leads)
//            {
//                leadBusinesses.Add(new LeadBusinessModel
//                {
//                    FName = item.FName,
//                    SName = item.SName,
//                    Numder = item.Numder,
//                    DateBirthday = item.DateBirthday,
//                    Status = new StatusBusinessModel() { Id = GetStatus(item.StatusId).Id, Name = GetStatus(item.StatusId).Name },
//                    EMail = item.EMail,
//                    Login = item.Login,
//                    Password = item.Password
//                });
//            }
//            return leadBusinesses;
//        }
//        Status GetStatus(int id)
//        {
//            _storage = new StorageStatus();
//            List<Status> statuses = (List<Status>)_storage.GetAll();
//            Status st = statuses.FirstOrDefault(x => x.Id == id);
//            return st;
//        }
//        public override int? CreateLead(LeadBusinessModel _model)
//        {
//            _storage = new StorageLead();
//            IEntity lead = new Lead
//            {
//                FName = _model.FName,
//                SName = _model.SName,
//                Numder = _model.Numder,
//                DateBirthday = _model.DateBirthday,
//                Status = new Status
//                {
//                    Id = _model.Status.Id,
//                    Name = _model.Status.Name
//                },
//                EMail = _model.EMail,
//                AccessStatus = true,
//                DateRegistration = Convert.ToString(DateTime.UtcNow),
//                Login = _model.Login,
//                Password = _model.Password

//            };
//            bool success = _storage.Add(ref lead);
//            Lead result = (Lead)lead;
//            if (success)
//            {
//                _publisher.Notify(lead);
//                return result.Id;
//            }
//            return null;
//        }

//        public override IEnumerable<IModelsBusiness> GetTeacher()
//        {
//            List<Teacher> teachers = _cache.Teachers;
//            List<TeacherBusinessModel> teachersBusiness = new List<TeacherBusinessModel>();
//            foreach (Teacher item in teachers)
//            {
//                teachersBusiness.Add(new TeacherBusinessModel
//                {
//                    Id = item.Id,
//                    FName = item.FName,
//                    SName = item.SName,
//                    PhoneNumber = item.PhoneNumber,
//                    Head = item.Head
//                });
//            };
//            return teachersBusiness;
//        }

//        public override bool UpdateLead(LeadBusinessModel _model)
//        {
//            _storage = new StorageLead();
//            Lead lead = new Lead
//            {
//                FName = _model.FName,
//                SName = _model.SName,
//                Numder = _model.Numder,
//                DateBirthday = _model.DateBirthday,
//                Status = new Status
//                {
//                    Id = _model.Status.Id,
//                    Name = _model.Status.Name
//                },
//                EMail = _model.EMail,
//                Login = _model.Login,
//                Password = _model.Password
//            };
//            bool success = _storage.Update(lead);
//            if (success)
//                _publisher.Notify(lead);
//            return success;
//        }

//    }
//}
