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
        public override bool AddSkillsForLead(int skillId, int LeadId)
        {
            return _teacherManager.AddSkillsForLead(skillId, LeadId);
        }

        public override List<GroupBusinessModel> GetAllGroupe()
        {
            return _teacherManager.GetAllGroupe();
        }

        public override List<CourseBusinessModel> GetAllCourse()
        {
            return _teacherManager.GetAllCourse();
        }
        public override bool SetAttendence(DayInLogBusinessModel dayLog)
        {
            return _teacherManager.SetAttendence(dayLog);
        }

        public override IEnumerable<IModelsBusiness> GetLeads()
        {
            //todo get All teacher students
            throw new NotImplementedException();
        }
    }
}
