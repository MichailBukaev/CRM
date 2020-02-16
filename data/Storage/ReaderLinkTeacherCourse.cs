using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderLinkTeacherCourse : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<LinkTeacherCourse> primariLink = (List<LinkTeacherCourse>)entities;
            List<LinkTeacherCourse> links;
            if (LinkTeacherCourse.Fields.Id.ToString() == TKey) { links = primariLink.Where(p => p.Id == Convert.ToInt32(TValue)).ToList(); }
            else if(LinkTeacherCourse.Fields.TeacherId.ToString() == TKey) { links = primariLink.Where( p => p.TeacherId == Convert.ToInt32(TValue)).ToList(); }
            else if(LinkTeacherCourse.Fields.CourseId.ToString() == TKey) { links = primariLink.Where(p => p.CourseId == Convert.ToInt32(TValue)).ToList(); }
            else { links = primariLink; }
            return links;
        }
    }
}
