using System;
using System.Collections.Generic;
using System.Text;
using models;

namespace data.CRUD
{
    public class Create : ICommand
    {
        public ApplicationContext db { get; set; }
        public void Execute(Lead newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.Leads.Add(newObject);
                    db.SaveChanges();
                }
            }
            
        }

        public void Execute(Course newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {                
                if (newObject != null)
                {
                    db.Courses.Add(newObject);
                    db.SaveChanges();
                }
            }

        }
        public void Execute(History newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.Historys.Add(newObject);
                    db.SaveChanges();
                }
            }
        }

        public void Execute(HistoryGroup newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.HistoryGroups.Add(newObject);
                    db.SaveChanges();
                }
            }

        }
        public void Execute(HR newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.HRs.Add(newObject);
                    db.SaveChanges();
                }
            }
        }

        public void Execute(Log newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.Logs.Add(newObject);
                    db.SaveChanges();
                }
            }

        }
        public void Execute(Skills newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.Skills.Add(newObject);
                    db.SaveChanges();
                }
            }
        }

        public void Execute(Status newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.Statuss.Add(newObject);
                    db.SaveChanges();
                }
            }

        }
        public void Execute(SkillsLead newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.SkillsLeads.Add(newObject);
                    db.SaveChanges();
                }
            }
        }

        public void Execute(Teacher newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.Teacherss.Add(newObject);
                    db.SaveChanges();
                }
            }

        }
        public void Execute(Group newObject)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newObject != null)
                {
                    db.Groups.Add(newObject);
                    db.SaveChanges();
                }
            }

        }




    }
}
