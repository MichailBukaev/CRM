using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSTeacher
{
    public abstract class TeacherManagerDecorater : TeacherManager
    {
        protected TeacherManager _teacherManager;
        public TeacherManagerDecorater(TeacherManager teacher)
        {
            _teacherManager = teacher;
        }
        public override LeadBusinessModel AddSkillsForLead(SkillsForLeadBusinessModel model)
        {
            return _teacherManager.AddSkillsForLead(model);
        }

        public override List<GroupBusinessModel> GetAllGroupe()
        {
            return _teacherManager.GetAllGroupe();
        }

        public override LogBusinessModel SetAttendence(DayInLogBusinessModel dayLog)
        {
            _teacherManager.SetAttendence(dayLog);
        }

        protected override void SetCache()
        {
            
        }
    }
}
