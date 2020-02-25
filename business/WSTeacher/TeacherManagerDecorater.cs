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
        public override List<TaskWorkBusinessModel> GetMyselfTask()
        {
            return _teacherManager.GetMyselfTask();
        }
        public override IModelsBusiness GetLead(int id)
        {
            return _teacherManager.GetLead(id);
        }
        public override IModelsBusiness GetTacher(int teacherId)
        {
            return _teacherManager.GetTacher(teacherId);
        }
    }
}
