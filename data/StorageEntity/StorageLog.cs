using data.Storage;
using models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace data.StorageEntity
{
    public class StorageLog : IStorage
    {
        IReader _reader;
        public StorageLog()
        {
            _reader = new ReaderLog();
        }
        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {

                    db.Logs.Add((Log)obj);
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

                    db.Logs.Remove((Log)obj);
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
                var logs = db.Logs.Include(p=>p.Lead).ToList();
                return _reader.Read(Tkey, TValue, logs);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var logs = db.Logs.Include(p => p.Lead).ToList();
                return _reader.Read(null, null, logs);
            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {

                    db.Logs.Update((Log)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
