using data.CRUD;
using models;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestCRUD
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreate()
        {
            Create create = new Create();
            Read read = new Read();
            
            Lead _lead = new Lead()
            {
                Id = 1,
                FName = "AAA",
                SName = "B",
                DateBirthday = "2000-08-11",
                DateRegistration = "2000-09-11",
                Numder = 89516,
                EMail = "asya",
                AccessStatus = true,
                GroupId = 2,
                Group = new Group(),
                StatusId = 3,
                Status = new Status(),
                CourseId = 4,
                Course = new Course()
            };
            create.Execute(_lead);
            IEnumerable<IEntity> list = read.Execute<Lead>();
            List<Lead> list1 = new List<Lead>();
            list1.Add(_lead);
            Assert.AreEqual(list1, list);

        }

        [Test]
        public void TestRead()
        {
            Create create = new Create();
            Read read = new Read();

            Lead _lead = new Lead()
            {
                Id = 1,
                FName = "AAA",
                SName = "B",
                DateBirthday = "2000-08-11",
                DateRegistration = "2000-09-11",
                Numder = 89516,
                EMail = "asya",
                AccessStatus = true,
                GroupId = 0,
                Group = new Group(),
                StatusId = 0,
                Status = new Status(),
                CourseId = 0,
                Course = new Course()
            };
            create.Execute(_lead);
            IEnumerable<IEntity> list = read.Execute<Lead>();
            List<Lead> list1 = new List<Lead>();
            list1.Add(_lead);
            Assert.AreEqual(list1, list);
        }

        [Test]
        public void TestDelete()
        {
            Create create = new Create();
            Read read = new Read();
            Delete delete = new Delete();
            MockLead mock = new MockLead();
            List<IEntity> leads = (List<IEntity>) mock.Leads;
            foreach (Lead item in leads)
            {
                create.Execute(item);
            }
            delete.Execute(leads[1]);
            IEnumerable<IEntity> list = read.Execute<Lead>();
            leads.Remove(leads[1]);
            Assert.AreEqual(leads, list);

        }
    }
}