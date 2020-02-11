using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.CRUD
{
    public class Delete : ICommand
    {
        public ApplicationContext db { get; set; }

        public void Execute(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    switch (obj.GetType().Name)
                    {
                        case "Lead":
                            db.Leads.Remove((Lead)obj);
                            break;
                        case "Course":
                            db.Courses.Remove((Course)obj);
                            break;
                        case "History":
                            db.Historys.Remove((History)obj);
                            break;
                        case "HistoryGroup":
                            db.HistoryGroups.Remove((HistoryGroup)obj);
                            break;
                        case "HR":
                            db.HRs.Remove((HR)obj);
                            break;
                        case "Log":
                            db.Logs.Remove((Log)obj);
                            break;
                        case "Skills":
                            db.Skills.Remove((Skills)obj);
                            break;
                        case "Status":
                            db.Statuss.Remove((Status)obj);
                            break;
                        case "SkillsLead":
                            db.SkillsLeads.Remove((SkillsLead)obj);
                            break;
                        case "Teacher":
                            db.Teacherss.Remove((Teacher)obj);
                            break;
                        case "Group":
                            db.Groups.Remove((Group)obj);
                            break;
                        default:
                            break;
                    }
                    db.SaveChanges();
                }                    
            }            
        }

        public IEnumerable<IEntity> Execute<T>() where T : IEntity, new()
        {
            return null;
        }
    }
}
