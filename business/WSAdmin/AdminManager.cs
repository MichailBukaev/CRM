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
        Storage _storage;
        AdminCache _cache;
        PublisherChangesInBD _publisher;
        public AdminManager()
        {
            _storage = new Storage();
            _cache = new AdminCache();
            _publisher = PublisherChangesInBD.GetPublisher();
            SetCache();
        }

        void SetCache()
        {
            if (_cache.FlagActual == false)
            {
                //_//storage = new StorageTeacher();
                //_cache.Teachers = (List<Teacher>)_storage.GetAll();
                ////_storage = new StorageHR();
                //_cache.Hrs = (List<HR>)_storage.GetAll();
                //_cache.FlagActual = true;
                _cache.Teachers = new List<Teacher>()
                {
                    new Teacher()
                    {
                        Id = 1,
                        FName = "Teacher",
                        SName = "test",
                        PhoneNumber = 123
                        
                    },
                    new Teacher()
                    {
                        Id = 2,
                        FName = "Teacher2",
                        SName = "test",
                        PhoneNumber = 123
                    }
                };
                _cache.Hrs = new List<HR>()
                {
                    new HR()
                    {
                        Id = 1,
                        FName = "HR",
                        SName = "test"

                    },
                    new HR()
                    {
                        Id = 2,
                        FName = "HR2",
                        SName = "test"
                    }
                };

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
                    SName = item.SName
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
                    PhoneNumber = item.PhoneNumber
                });
            };
            return teachersBusiness;
        }

        public bool CreateHR(HRBusinessModel _hr)
        {
            //_storage = new StorageHR();
            HR hR = new HR
            {
                Id = _hr.Id,
                FName = _hr.FName,
                SName = _hr.SName,
                Login = _hr.Login,
                Password = _hr.Password
            };
            bool success = _storage.Add(hR);
            if (success)
                _publisher.Notify(hR);
            return success;
        }

        public bool CreateTeacher(TeacherBusinessModel _teacher)
        {
           // _storage = new StorageTeacher();
            Teacher teacher = new Teacher
            {
                Id = _teacher.Id,
                FName = _teacher.FName,
                SName = _teacher.SName,
                PhoneNumber = _teacher.PhoneNumber,
                Login = _teacher.Login,
                Password = _teacher.Password
            };
            bool success = _storage.Add(teacher);
            if (success)
                _publisher.Notify(teacher);
            return success;
        }

    }
}
