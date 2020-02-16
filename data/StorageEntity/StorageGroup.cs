using data.Storage;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity
{
    public class StorageGroup : IStorage
    {
        IReader _reader;
        public StorageGroup()
        {
            _reader = new ReaderGroup();
        }
        public bool Add(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Groups.Add((Group)obj);
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
                    db.Groups.Remove((Group)obj);
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
                var groups = db.Groups.Include(p=>p.Course).Include(p=>p.Teacher).ToList();
                return _reader.Read(Tkey, TValue, groups);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var groups = db.Groups.Include(p => p.Course).Include(p => p.Teacher).ToList();
                return _reader.Read(null, null, groups);
            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Groups.Update((Group)obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
