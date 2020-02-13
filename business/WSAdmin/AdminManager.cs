using business.Models;
using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSAdmin
{
    public class AdminManager
    {
        Storage storage;
        AdminCache _cache;
        PublisherChangesInBD _publisher;
        public AdminManager()
        {
            storage = new Storage();
            _cache = new AdminCache();
            _publisher = PublisherChangesInBD.GetPublisher();
            SetCache();
        }

        void SetCache()
        {
            if (_cache.FlagActual == false)
            {
                _cache.Teachers = (List<Teacher>)storage.GetAll<Teacher>();
                _cache.Hrs = (List<HR>)storage.GetAll<HR>();
                _cache.FlagActual = true;
            }
        }
        public IEnumerable<IEntity> GetHR()
        {
            return _cache.Hrs;
        }

        public IEnumerable<IEntity> GetTeacher()
        {
            return _cache.Teachers;
        }

        public bool CreateHR(HRBusinessModelAdmin _hr)
        {
            HR hR = new HR
            {
                Id = _hr.Id,
                FName = _hr.FName,
                SName = _hr.SName,
                Login = _hr.Login,
                Password = _hr.Password
            };
            bool success = storage.Add(hR);
            if (success)
                _publisher.Notify(hR);
            return success;
        }

        public bool CreateTeacher(TeacherBusinessModelAdmin _teacher)
        {
            Teacher teacher = new Teacher
            {
                Id = _teacher.Id,
                FName = _teacher.FName,
                SName = _teacher.SName,
                PhoneNumber = _teacher.PhoneNumber,
                Login = _teacher.Login,
                Password = _teacher.Password
            };
            bool success = storage.Add(teacher);
            if (success)
                _publisher.Notify(teacher);
            return success;
        }

    }
}
