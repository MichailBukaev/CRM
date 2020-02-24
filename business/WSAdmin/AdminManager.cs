using business.Models;
using business.WSHR;
using business.WSUser.interfaces;
using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSAdmin
{
    public class AdminManager : IUserManager
    {
        IStorage _storage;
        public IEnumerable<IModelsBusiness> GetHR()
        {
            _storage = new StorageHR();
            List<HR> hrs = (List<HR>)_storage.GetAll();
            List<HRBusinessModel> hrsBusiness = new List<HRBusinessModel>();
            foreach (HR item in hrs)
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
            _storage = new StorageTeacher();
            List<Teacher> teachers = (List<Teacher>)_storage.GetAll();
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

        public int? CreateHR(HRBusinessModel _hr)
        {
            if (InspectorLogin.CheckUniqueness(_hr.Login))
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
                {
                    PublishingHouse publishingHouse = PublishingHouse.Create();
                    PublisherChangesInDB _publisher = publishingHouse.HR;
                    _publisher.Notify();
                    HR result = (HR)hR;
                    return result.Id;
                }
            }
            return null;
        }

        public int? CreateTeacher(TeacherBusinessModel _teacher)
        {
            if (InspectorLogin.CheckUniqueness(_teacher.Login))
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
                {
                    PublishingHouse publishingHouse = PublishingHouse.Create();
                    PublisherChangesInDB _publisher = publishingHouse.Teacher;
                    _publisher.Notify();
                    Teacher result = (Teacher)teacher;
                    return result.Id;

                }
            }
            return null;
        }

        public override IModelsBusiness GetLead(int id)
        {
            _storage = new StorageLead();
            List<Lead> leads = (List<Lead>)_storage.GetAll();
            Lead lead = leads.FirstOrDefault(x => x.Id == id);
            _storage = new StorageSkills();
            List<SkillsLead> skillsEntity = (List<SkillsLead>)_storage.GetAll(SkillsLead.Fields.LeadId.ToString(), lead.Id.ToString());
            List<SkillBusinessModel> skills = new List<SkillBusinessModel>();
            foreach (SkillsLead item in skillsEntity)
            {
                skills.Add(new SkillBusinessModel()
                {
                    IdSkill = item.SkillsId,
                    NameSkill = item.Skill.NameSkills
                });
            }
            List<string> history = new List<string>();
            _storage = new StorageHistory();
            List<History> historyEntity = (List<History>)_storage.GetAll(History.Fields.LeadId.ToString(), lead.Id.ToString());
            foreach (History item in historyEntity)
            {
                history.Add(item.HistoryText);
            }
            return new LeadBusinessModel()
            {
                Id = lead.Id,
                FName = lead.FName,
                SName = lead.SName,
                DateBirthday = lead.DateBirthday,
                EMail = lead.EMail,
                Numder = lead.Numder,
                Skills = skills,
                Status = new StatusBusinessModel()
                {
                    Id = lead.Status.Id,
                    Name = lead.Status.Name
                },
                History = history
            };
        }
    }
}
