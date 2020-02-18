using business.Models;
using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSAdmin
{
    public class AdminManager
    {
        IStorage _storage;
        AdminCache _cache;
        PublisherChangesInBD _publisher;
        public AdminManager()
        {
            _cache = new AdminCache();
            _publisher = PublisherChangesInBD.GetPublisher();
            SetCache();
        }

        void SetCache()
        {
            if (_cache.FlagActual == false)
            {
                _storage = new StorageTeacher();
                _cache.Teachers = (List<Teacher>)_storage.GetAll();
                _storage = new StorageHR();
                _cache.Hrs = (List<HR>)_storage.GetAll();
                _cache.FlagActual = true;
            }
        }
        public IEnumerable<IModelsBusiness> GetHR()
        {
            List<HR> hrs = _cache.Hrs;
            List<HRBusinessModel> hrsBusiness = new List<HRBusinessModel>();
            foreach(HR item in hrs)
            {
                hrsBusiness.Add(new HRBusinessModel
                {
                    Id = item.Id,
                    FName = item.FName,
                    SName = item.SName,
                    Head = item.Head
                    
                });
            };
            return hrsBusiness;
        }

        public IEnumerable<IModelsBusiness> GetTeacher()
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
                    PhoneNumber = item.PhoneNumber,
                    Head = item.Head
                });
            };
            return teachersBusiness;
        }

        public bool CreateHR(HRBusinessModel _hr)
        {
            _storage = new StorageHR();
            IEntity hR = new HR
            {
                Id = _hr.Id,
                FName = _hr.FName,
                SName = _hr.SName,
                Login = _hr.Login,
                Password = _hr.Password,
                Head = _hr.Head
            };
            bool success = _storage.Add(ref hR);
            if (success)
                _publisher.Notify(hR);
            return success;
        }

        public bool CreateTeacher(TeacherBusinessModel _teacher)
        {
            _storage = new StorageTeacher();
            IEntity teacher = new Teacher
            {
                Id = _teacher.Id,
                FName = _teacher.FName,
                SName = _teacher.SName,
                PhoneNumber = _teacher.PhoneNumber,
                Login = _teacher.Login,
                Password = _teacher.Password,
                Head = _teacher.Head
            };
            bool success = _storage.Add(ref teacher);
            if (success)
                _publisher.Notify(teacher);
            return success;
        }

    }
}
