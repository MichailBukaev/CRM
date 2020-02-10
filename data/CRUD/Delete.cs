using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.CRUD
{
    public class Delete : ICommand
    {
        public ApplicationContext db { get; set; }

        public void Execute(Lead obj) 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {                
                if (obj != null)
                {
                    db.Leads.Remove(obj);
                    db.SaveChanges();
                }
            } 
        }
        public void Execute(Course obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Courses.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(History obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Historys.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(HistoryGroup obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.HistoryGroups.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(HR obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.HRs.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Log obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Logs.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Skills obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Skills.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Status obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Statuss.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(SkillsLead obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.SkillsLeads.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Teacher obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Teacherss.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Group obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {
                    db.Groups.Remove(obj);
                    db.SaveChanges();
                }
            }
        }        
    }
}
