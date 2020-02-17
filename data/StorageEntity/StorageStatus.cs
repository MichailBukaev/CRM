using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.Storage;

namespace data.StorageEntity
{
    public class StorageStatus : IStorage
    {
        IReader _reader;
        public StorageStatus()
        {
            _reader = new ReaderStatus();
        }

        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Statuss.Add((Status)obj);
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
                    db.Statuss.Remove((Status)obj);
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
                var statuss = db.Statuss.ToList();
                return _reader.Read(Tkey, TValue, statuss);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var statuss = db.Statuss.ToList();
                return _reader.Read(null, null, statuss);
            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Statuss.Update((Status)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
