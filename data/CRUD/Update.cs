using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.CRUD
{
    public class Update : ICommand
    {
        public ApplicationContext db { get; set; }

        public void Execute(Lead objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {                       
                    db.Leads.Update(objForUpdate);
                    db.SaveChanges();
                }               
            }
        }
        public void Execute(Course objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.Courses.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(History objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.Historys.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(HistoryGroup objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.HistoryGroups.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(HR objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.HRs.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Log objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.Logs.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Skills objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.Skills.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Status objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.Statuss.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(SkillsLead objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.SkillsLeads.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Teacher objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.Teacherss.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
        public void Execute(Group objForUpdate)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (objForUpdate != null)
                {
                    db.Groups.Update(objForUpdate);
                    db.SaveChanges();
                }
            }
        }
    }
}
