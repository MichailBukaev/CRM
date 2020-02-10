using business.WSHR;
using models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTestWSHR
{
    [TestFixture(0)]
    [TestFixture(1)]
    [TestFixture(2)]
    [TestFixture(3)]
    [TestFixture(4)]
    [TestFixture(5)]
    [TestFixture(6)]
    [TestFixture(7)]
    [TestFixture(8)]
    public class TestAdd
    {
        HRManager manager;
        IEnumerable<IEntity> entitys;
        IEntity model;
        int a;
        public TestAdd(int a)
        {
            this.a = a;
            manager = new HRManager();
        }
        [SetUp]
        public void Setup()
        {
            if (a == 0)
            {
                model = new Lead();
                entitys = new List<IEntity>{ new Lead() { GroupId = 1, Group = new Group() { TeacherId = 1 } } };
            }
            else if (a == 1)
            {
                model = new Teacher();
                entitys = new List<IEntity>
                {
                    new Teacher()  { Id = 1, SName = "Teacher Second Name", FName = "Teacher Name"  },
                    new Teacher()  { Id = 2, SName = "Teacher2 Second Name", FName = "Teacher2 Name"  },
                };
            } else if(a == 2)
            {
                model = new History();
                entitys = new List<IEntity> { new History { LeadId = 1 } };
            } else if(a == 3)
            {
                model = new HistoryGroup();
                entitys = new List<IEntity> { new HistoryGroup { GroupId = 1 } };
            } else if(a == 4)
            {
                model = new Group();
                entitys = new List<IEntity> { new Group() { TeacherId = 1, Id = 1, NameGroup = "BASE_C#_KMN№1" } };
            } else if(a == 5)
            {
                model = new Status();
                entitys = new List<IEntity> { new Status() { Id = 1, Name = "В работе" } };
            }
            else if (a == 6)
            {
                model = new SkillsLead();
                entitys = new List<IEntity> { new SkillsLead { LeadId = 1 } };
            }
            else if (a == 7)
            {
                model = new Skills();
                entitys = new List<IEntity> { new Skills() };
            }
            else if (a == 8)
            {
                model = new Course();
                entitys = new List<IEntity>
                {
                    new Course()  { Id = 1, Name = "C#", CourseInfo = "C# Information" },
                    new Course()  { Id = 2, Name = "Web", CourseInfo = "Web Information" },
                    new Course()  { Id = 3, Name = "QA", CourseInfo = "QA Information" },
                };
            }
        }

        #region GetTest
        
        
        [Test]
        public void TGetEntity()
        {
            bool flag = true;
            IEnumerable <IEntity> result = manager.SetCache(model);
            for (int i = 0; i < entitys.Count(); i++)
            {
                if (!(entitys.ElementAt(i).Equals(result.ElementAt(i))))
                {
                    flag = false;
                    break;
                }
            }
           
            Assert.IsTrue(flag); 
        }
       
        #endregion


    }
}