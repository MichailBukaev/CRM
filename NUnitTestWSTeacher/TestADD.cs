using business.WSTeacher;
using models;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestWSTeacher
{
    public class TestAdd
    {
        TeacherManager manager;
        IEnumerable<IEntity> entitys;
        Teacher concreatTeacher;


        [SetUp]
        public void SetUp()
        {
           concreatTeacher = new Teacher() { Id = 1, FName = "Teacher Second Name", SName = "Teacher Name" };
           manager = new TeacherManager(concreatTeacher);

        }
        #region GetCache
        [Test]
        public void TestGetLeads()
        {
            Lead test = new Lead() { GroupId = 1, Group = new Group() { TeacherId = 1 } };
            entitys = manager.GetLeads();
            foreach (Lead item in entitys)
            {
                Assert.AreEqual(test.GroupId, item.GroupId);
                Assert.AreEqual(test.Group.TeacherId, item.Group.TeacherId);

            }

        }
        #endregion


    }
}