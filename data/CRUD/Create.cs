using System;
using System.Collections.Generic;
using System.Text;
using models;

namespace data.CRUD
{
    public class Create : ICommand
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
                            db.Leads.Add((Lead)obj);
                            break;
                        case "Course":
                            db.Courses.Add((Course)obj);
                            break;
                        case "History":
                            db.Historys.Add((History)obj);
                            break;
                        case "HistoryGroup":
                            db.HistoryGroups.Add((HistoryGroup)obj);
                            break;
                        case "HR":
                            db.HRs.Add((HR)obj);
                            break;
                        case "Log":
                            db.Logs.Add((Log)obj);
                            break;
                        case "Skills":
                            db.Skills.Add((Skills)obj);
                            break;
                        case "Status":
                            db.Statuss.Add((Status)obj);
                            break;
                        case "SkillsLead":
                            db.SkillsLeads.Add((SkillsLead)obj);
                            break;
                        case "Teacher":
                            db.Teacherss.Add((Teacher)obj);
                            break;
                        case "Group":
                            db.Groups.Add((Group)obj);
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
