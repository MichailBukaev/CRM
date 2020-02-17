using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity
{

    public class StorageHR : IStorage
    {
        IReader _reader;
        public StorageHR()
        {
            _reader = new ReaderHR();
        }

        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    
                    db.HRs.Add((HR)obj);
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
                    db.HRs.Remove((HR)obj);
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
                var hrs = db.HRs.ToList();
                return _reader.Read(Tkey, TValue, hrs);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var hrs = db.HRs.ToList();
                return _reader.Read(null, null, hrs); 
            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.HRs.Update((HR)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
