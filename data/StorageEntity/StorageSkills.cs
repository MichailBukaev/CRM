using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.Storage;
namespace data.StorageEntity
{
    public class StorageSkills : IStorage
    {
        IReader _reader;
        public StorageSkills()
        {
            _reader = new ReaderSkills();
        }

        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Skills.Add((Skills)obj);
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
                    db.Skills.Remove((Skills)obj);
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
                var skills = db.Skills.ToList();
                return _reader.Read(Tkey, TValue, skills);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var skills = db.Skills.ToList();
                return _reader.Read(null, null, skills);
            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Skills.Update((Skills)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
