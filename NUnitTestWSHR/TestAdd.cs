using business.Models;
using business.WSHR;
using data.StorageEntity.Mock;
using models;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace NUnitTestWSHR
{
    [TestFixture]
    public class HRManager_Test
    {
        [Test]
        public void HRManager_CreateLead_Sucessful()
        {
            var hrManager = new HRManager(1);

            var leadBusinessModel = new LeadBusinessModel()
            {
                FName = "Ivan",
                EMail = "aaa",
                Status = new StatusBusinessModel
                {
                    Id = 1,
                    Name = "status 1"
                }
            };
            hrManager.CreateLead(leadBusinessModel);

            var lead = StorageLead.Leads.First();
            Assert.AreEqual(lead.EMail, "aaa");
            Assert.AreEqual(lead.FName, "Ivan");
            Assert.AreEqual(lead.StatusId, 1);
        }

        [Test]
        public void HeadHR_CreateGroup_Sucessful()
        {

            var headhr = new HeadHR(1);
            

            var groupBusinessModel = new GroupBusinessModel()
            {
             Name = "GroupName",
             StartDate = "12.09.2020",         
           };
            groupBusinessModel.Teacher = new CutTeacherBusinessModel();
            groupBusinessModel.Course = new business.Models.CutModel.CutCourseBusinessModel();



            headhr.CreateGroup(groupBusinessModel);
            var group = StorageGroup.Groups.First();
            Assert.AreEqual(group.NameGroup ,"GroupName");
            Assert.AreEqual(group.StartDate, "12.09.2020");
        }



    }
}