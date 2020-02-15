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
        
        public HeadHR(DefaultHR hr)
        {
            this.defaultHR = hr;
            _publisher = PublisherChangesInBD.GetPublisher();
        }
        public override void SetCache()
        {
            throw new NotImplementedException();
        }
        public override bool CreateGroup(GroupBusinessModel _model)
        {
            _storage = new StorageGroup();
            Group group = new Group()
            {
                NameGroup = _model.Name,
                CourseId = _model.CourseId,
                Course = GetCourse(_model.CourseId),
                TeacherId = _model.TeacherId,
                Teacher = GetTeacher(_model.TeacherId),
                StartDate = _model.StartDate
            };
            bool success = _storage.Add(group);
            if (success)
                _publisher.Notify(group);
            return success;
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
            List<Teacher> teachers = (List<Teacher>)_storage.GetAll();
            Teacher teacher = teachers.FirstOrDefault(x => x.Id == id);
            return teacher;
        }
       

        
        public override bool DeleteGroup(GroupBusinessModel _model)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteLead(LeadBusinessModel _model)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IModelsBusiness> GetLead()
        {
            return defaultHR.GetLead();
        }

        public override IEnumerable<IModelsBusiness> GetTeacher()
        {
            return defaultHR.GetTeacher();
        }

        public override bool CreateLead(LeadBusinessModel _model)
        {
            return defaultHR.CreateLead(_model);
        }

        public override bool UpdateLead(LeadBusinessModel _model)
        {
            return defaultHR.UpdateLead(_model);
        }

       
    }
}
