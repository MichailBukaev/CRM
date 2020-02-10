using business.WSTeacher;
using models;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestWSTeacher
{
    [TestFixture(0)]
    [TestFixture(1)]
    [TestFixture(2)]
    [TestFixture(3)]
    [TestFixture(4)]
    [TestFixture(5)]
    [TestFixture(6)]
    [TestFixture(7)]
    
    public class TestADD
    {
        TeacherManager manager;
        List<Lead> leads;
        List<Group> groups;
        List<Course> courses;
        List<HistoryGroup> historyGroups;
        List<History> histories;
        List<Skills> skills;
        List<SkillsLead> skillsLeads;
        List<Log> logs;

        [SetUp]
        public void Setup(int a)
        {
            if (a == 0)
            {
                leads = new List<Lead>();

            }
            else if (a == 1)
            {
                groups = new List<Group>();
            }
            else if (a == 2)
            {
                courses = new List<Course>();
            }
            else if (a == 3)
            {
                historyGroups = new List<HistoryGroup>();

            }
            else if (a == 4)
            {
                histories = new List<History>();
            }
            else if (a == 5)
            {
                skills = new List<Skills>();

            }
            else if(a == 6)
            {
                skillsLeads = new List<SkillsLead>();

            }
            else if(a==7)
            {
                logs = new List<Log>();
            }

        }

        #region
        [Test]
        
        
        public void TestGetEntity()
        {
            manager.SetCache();
        }
        #endregion
       
        
    }
}