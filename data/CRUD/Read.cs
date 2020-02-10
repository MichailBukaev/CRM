using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.CRUD
{
    public class Read : ICommand
    {
        public ApplicationContext db { get; set; }

        public IEnumerable<IEntity> Execute<T>() where T : IEntity, new()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                T obj = new T();

                if (obj is Lead)
                {
                    List<Lead> listObjectTmp = db.Leads
                        .Include(l => l.Status)
                        .Include(l => l.Course)
                        .Include(l => l.Group)
                            .ThenInclude(gr => gr.Teacher)
                        .ToList();
                    return listObjectTmp;
                }
                else if (obj is Course)
                {
                    List<Course> listObjectTmp = db.Courses.ToList();
                    return listObjectTmp;
                }
                else if (obj is History)
                {
                    List<History> listObjectTmp = db.Historys
                        .Include(hist => hist.Lead)
                        .ToList();
                    return listObjectTmp;
                }
                else if (obj is HistoryGroup)
                {
                    List<HistoryGroup> listObjectTmp = db.HistoryGroups
                        .Include(hist => hist.Group)
                        .ToList();
                    return listObjectTmp;
                }
                else if (obj is HR)
                {
                    List<HR> listObjectTmp = db.HRs.ToList();
                    return listObjectTmp;
                }
                else if (obj is Log)
                {
                    List<Log> listObjectTmp = db.Logs
                        .Include(log => log.Lead)
                        .ToList();
                    return listObjectTmp;
                }
                else if (obj is Skills)
                {
                    List<Skills> listObjectTmp = db.Skills.ToList();
                    return listObjectTmp;
                }
                else if (obj is Status)
                {
                    List<Status> listObjectTmp = db.Statuss.ToList();
                    return listObjectTmp;
                }
                else if (obj is SkillsLead)
                {
                    List<SkillsLead> listObjectTmp = db.SkillsLeads
                        .Include(s => s.Lead)
                        .Include(s => s.Skill)
                        .ToList();
                    return listObjectTmp;
                }
                else if (obj is Teacher)
                {
                    List<Teacher> listObjectTmp = db.Teacherss.ToList();
                    return listObjectTmp;
                }
                else if (obj is Group)
                {
                    List<Group> listObjectTmp = db.Groups
                        .Include(gr => gr.Teacher)
                        .Include(gr => gr.Course)
                        .ToList();
                    return listObjectTmp;
                }
                return null;
            }
        }
    }
}
