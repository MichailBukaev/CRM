using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace data.StorageEntity
{
    public class StorageHistory : IStorage
    {
        IReader _reader;
        public StorageHistory()
        {
            _reader = new ReaderHistory();
        }
        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Historys.Add((History)obj);
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
                    db.Historys.Remove((History)obj);
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
                var historys = db.Historys.Include(p=>p.Lead).ToList();
                return _reader.Read(Tkey, TValue, historys);
            }

        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var historys = db.Historys.Include(p => p.Lead).ToList();
                return _reader.Read(null, null, historys);
            }
                
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Historys.Update((History)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
