using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.CRUD
{
    public class Update : ICommand
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
                            db.Leads.Update((Lead)obj);
                            break;
                        case "Course":
                            db.Courses.Update((Course)obj);
                            break;
                        case "History":
                            db.Historys.Update((History)obj);
                            break;
                        case "HistoryGroup":
                            db.HistoryGroups.Update((HistoryGroup)obj);
                            break;
                        case "HR":
                            db.HRs.Update((HR)obj);
                            break;
                        case "Log":
                            db.Logs.Update((Log)obj);
                            break;
                        case "Skills":
                            db.Skills.Update((Skills)obj);
                            break;
                        case "Status":
                            db.Statuss.Update((Status)obj);
                            break;
                        case "SkillsLead":
                            db.SkillsLeads.Update((SkillsLead)obj);
                            break;
                        case "Teacher":
                            db.Teacherss.Update((Teacher)obj);
                            break;
                        case "Group":
                            db.Groups.Update((Group)obj);
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
