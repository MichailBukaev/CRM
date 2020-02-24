using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.StorageEntity
{
    public class StorageTaskWork : IStorage
    {
        IReader reader;

        public StorageTaskWork()
        {
            reader = new ReaderTask();
        }
        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db. Add((Course)obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Delete(IEntity obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            throw new NotImplementedException();
        }

        public bool Update(IEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
