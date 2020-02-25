using business.Cache;

using business.Models;
using business.WSHR.Cache;
using business.WSHR.Headhr.Cache;
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
    public class HRManager : DefaultHR
    {
        HistoryWriter historyWriter;
        public HRManager(int hrId)
        {
            _storage = new StorageHR();
            List<HR> hrs = (List<HR>)_storage.GetAll();
            _hr = hrs.FirstOrDefault(p => p.Id == hrId);
            historyWriter = new HistoryWriter();
            _cache = new HRManagerCache();
            SetCache();
        }

       
        public void SetCache()
        {
            HREntityCache entityCache = new FillEntityCache(_hr).Fill();
            _cache = new FillHRManagerCache(entityCache).Fill();
        }

        public IEnumerable<IModelsBusiness> GetLeadsByStatus(int statusId)
        {            
            List<LeadBusinessModel> leadBusinesses = new List<LeadBusinessModel>();
            foreach (CacheLeadsCombineByStatus item in _cache.Leads)
            {
                if(item.StatusId == statusId)
                {
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
            _storage = new StorageStatus();
            List<Status> statuses = (List<Status>)_storage.GetAll();
            Status st = statuses.FirstOrDefault(x => x.Id == id);
            return st;
        }

        public override int? CreateLead(LeadBusinessModel _model)
        {
            if (InspectorLogin.CheckUniqueness(_model.Login))
            {
                PublishingHouse publishingHouse = PublishingHouse.Create();
                //_model.Status.Id = 1; 
                PublisherChangesInDB publisher = publishingHouse.CombineByStatus[_model.Status.Id];
                _storage = new StorageLead();
                IEntity lead = new Lead
                {
                    FName = _model.FName,
                    SName = _model.SName,
                    Numder = _model.Numder,
                    DateBirthday = _model.DateBirthday,
                    StatusId = _model.Status.Id,
                    EMail = _model.EMail,
                    AccessStatus = true,
                    DateRegistration = Convert.ToString(DateTime.UtcNow),
                    Login = _model.Login,
                    Password = _model.Password
                };

                bool success = _storage.Add(ref lead);
                Lead result = (Lead)lead;
                historyWriter.CreateLead(ref result);
                if (success)
                {
                    publisher.Notify();
                    return result.Id;
                }
            }
            return null;
        }

        public override IEnumerable<IModelsBusiness> GetTeacher()
        {
            if (!_cache.Teachers.FlagActual)
                ReconstructorHRManagerCache.UpdateCacheTeachers(_cache.Teachers);
            List<TeacherBusinessModel> teachersBusiness = _cache.Teachers.Teachers;
            
            return teachersBusiness;
        }

        public override bool UpdateLead(LeadBusinessModel _model)
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
            historyWriter.UpdateLead(lead);
            if (success)
                publisher.Notify();
            return success;
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

        public override bool ChangeStatus(int leadId, int statusId)
        {
            throw new NotImplementedException();
        }
    }
}
