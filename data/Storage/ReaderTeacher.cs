using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderTeacher : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<Teacher> primariTeacher = (List<Teacher>)entities;
            List<Teacher> teachers;
            if (Teacher.Fields.Id.ToString() == TKey) { teachers = primariTeacher.Where(p => p.Id == Convert.ToInt32(TValue)).ToList(); }
            else if (Teacher.Fields.FName.ToString() == TKey) { teachers = primariTeacher.Where(p => p.FName == TValue).ToList(); }
            else if (Teacher.Fields.SName.ToString() == TKey) { teachers = primariTeacher.Where(p => p.SName == TValue).ToList(); }
            else if (Teacher.Fields.PhoneNumber.ToString() == TKey) { teachers = primariTeacher.Where(p => p.PhoneNumber == Convert.ToInt32(TValue)).ToList(); }
            else if (Teacher.Fields.Login.ToString() == TKey) { teachers = primariTeacher.Where(p => p.Login == TValue).ToList(); }
            else if (Teacher.Fields.Password.ToString() == TKey) { teachers = primariTeacher.Where(p => p.Password == TValue).ToList(); }
            else if (Teacher.Fields.Head.ToString() == TKey) { teachers = primariTeacher.Where(p => p.Head == Convert.ToBoolean(TValue)).ToList(); }

            else { teachers = primariTeacher; }
            return teachers;
        }
    }
}
