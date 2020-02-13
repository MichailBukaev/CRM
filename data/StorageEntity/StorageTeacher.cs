using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.Storage;

namespace data.StorageEntity
{

    public class StorageTeacher : IStorage
    {
        IReader _reader;
        public StorageTeacher()
        {
            _reader = new ReaderTeacher();
        }

        public bool Add(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Teacherss.Add((Teacher)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool Delete(IEntity obj)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Teacherss.Remove((Teacher)obj);
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
                var teachers = db.Teacherss.ToList();
                return _reader.Read(Tkey, TValue, teachers);
            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var teachers = db.Teacherss.ToList();
                return _reader.Read(null, null, teachers);
            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Teacherss.Update((Teacher)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
