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
                switch (obj.GetType().Name) 
                {
                    case "Lead":                
                        {
                            List<Lead> listObjectTmp = db.Leads
                                .Include(l => l.Status)
                                .Include(l => l.Course)
                                .Include(l => l.Group)
                                    .ThenInclude(gr => gr.Teacher)
                                .ToList();
                            return listObjectTmp;
                        }                   
                    case "Course":                
                            {
                                List<Course> listObjectTmp = db.Courses.ToList();
                                return listObjectTmp;
                            }
                    case "History":
                            {
                                List<History> listObjectTmp = db.Historys
                                    .Include(hist => hist.Lead)
                                    .ToList();
                                return listObjectTmp;
                            }
                    case "HistoryGroup":
                        {
                            List<HistoryGroup> listObjectTmp = db.HistoryGroups
                                .Include(hist => hist.Group)
                                .ToList();
                            return listObjectTmp;
                        }
                    case "HR":
                        {
                            List<HR> listObjectTmp = db.HRs.ToList();
                            return listObjectTmp;
                        }
                    case "Log":
                        {
                            List<Log> listObjectTmp = db.Logs
                                .Include(log => log.Lead)
                                .ToList();
                            return listObjectTmp;
                        }
                            case "Skills":
                        {
                            List<Skills> listObjectTmp = db.Skills.ToList();
                            return listObjectTmp;
                        }
                    case "Status":
                        {
                            List<Status> listObjectTmp = db.Statuss.ToList();
                            return listObjectTmp;
                        }
                    case "SkillsLead":
                        {
                            List<SkillsLead> listObjectTmp = db.SkillsLeads
                                .Include(s => s.Lead)
                                .Include(s => s.Skill)
                                .ToList();
                            return listObjectTmp;
                        }
                    case "Teacher":
                        {
                            List<Teacher> listObjectTmp = db.Teacherss.ToList();
                            return listObjectTmp;
                        }
                    case "Group":
                        {
                            List<Group> listObjectTmp = db.Groups
                                .Include(gr => gr.Teacher)
                                .Include(gr => gr.Course)
                                .ToList();
                            return listObjectTmp;
                        }
                    default:
                        return null;
                }
                
            }
        }

        public void Execute(IEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
