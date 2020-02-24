using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity
{
    public class StorageTaskWork : IStorage
    {
        IReader _reader;

        public StorageTaskWork()
        {
            _reader = new ReaderTaskWork();
        }
        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.TaskWorks.Add((TaskWork)obj);
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
                    db.TaskWorks.Remove((TaskWork)obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tasks = db.TaskWorks.ToList();
                return _reader.Read(null, null, tasks);

            }
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var taskWork = db.TaskWorks.ToList();
                return _reader.Read(Tkey, TValue, taskWork);

            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.TaskWorks.Update((TaskWork)obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
