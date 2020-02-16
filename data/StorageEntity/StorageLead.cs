using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity
{
    public class StorageLead : IStorage
    {
        IReader _reader;
        public StorageLead()
        {
            _reader = new ReaderLead();
        }
        public bool Add(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {

                    db.Leads.Add((Lead)obj);
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

                    db.Leads.Remove((Lead)obj);
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
                var leads = db.Leads.ToList();
                return _reader.Read(Tkey, TValue, leads);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var leads = db.Leads.ToList();
                return _reader.Read(null, null, leads);
            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {

                    db.Leads.Update((Lead)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
