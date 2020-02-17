using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.Storage;
using Microsoft.EntityFrameworkCore;

namespace data.StorageEntity
{
   public class StorageSkillsLead : IStorage
    {
        IReader _reader;
        public StorageSkillsLead()
        {
            _reader = new ReaderSkillsLead();
        }

        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.SkillsLeads.Add((SkillsLead)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool Delete(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.SkillsLeads.Remove((SkillsLead)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var skillsLeads = db.SkillsLeads.
                    Include(p=>p.Lead).
                    Include(p => p.Skill).
                    ToList();
                return _reader.Read(Tkey, TValue, skillsLeads);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var skillsLeads = db.SkillsLeads.
                    Include(p => p.Lead).
                    Include(p => p.Skill).
                    ToList();
                return _reader.Read(null, null, skillsLeads);
            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.SkillsLeads.Update((SkillsLead)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
