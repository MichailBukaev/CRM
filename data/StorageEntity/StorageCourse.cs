using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity
{
    public class StorageCourse : IStorage
    {
        IReader _reader;
        public StorageCourse()
        {
            _reader = new ReaderCourse();
        }

        public bool Add(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Courses.Add((Course)obj);
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
                    db.Courses.Remove((Course)obj);
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
               var courses = db.Courses.ToList();
                return _reader.Read(Tkey, TValue, courses);

            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Courses.ToList();
                return _reader.Read(null, null, courses);

            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Courses.Update((Course)obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
