using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity
{
    public class StorageTasksStatus : IStorage
    {
        IReader _reader;

        public StorageTasksStatus()
        {
            _reader = new ReaderTasksStatus();
        }
        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.TasksStatuses.Add((TasksStatus)obj);
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
                    db.TasksStatuses.Remove((TasksStatus)obj);
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
                var tasksStatus = db.TasksStatuses.ToList();
                return _reader.Read(null, null, tasksStatus);

            }
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var taskStatus = db.TasksStatuses.ToList();
                return _reader.Read(Tkey, TValue, taskStatus);

            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.TasksStatuses.Update((TasksStatus)obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
