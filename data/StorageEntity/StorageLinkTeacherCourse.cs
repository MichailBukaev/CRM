using data.Storage;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity
{
    public class StorageLinkTeacherCourse : IStorage
    {
        IReader _reader;

        public StorageLinkTeacherCourse()
        {
            _reader = new ReaderLinkTeacherCourse();
        }
        public bool Add(ref IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.LinkTeacherCourses.Add((LinkTeacherCourse)obj);
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
                    db.LinkTeacherCourses.Remove((LinkTeacherCourse)obj);
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
                var links = db.LinkTeacherCourses.
                    Include(p => p.Teacher).
                    Include(p => p.Course).
                    ToList();
                return _reader.Read(Tkey, TValue, links);

            }
        }

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var links = db.LinkTeacherCourses.
                    Include(p => p.Teacher).
                    Include(p => p.Course).
                    ToList();
                return _reader.Read(null, null, links);

            }
        }

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.LinkTeacherCourses.Update((LinkTeacherCourse)obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
