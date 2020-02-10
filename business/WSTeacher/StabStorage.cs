using models;
using System;
using System.Collections.Generic;
using System.Text;


namespace NUnitTestWSTeacher
{
    public class StabStorage
    {
        object _user;
        public StabStorage(object user)
        {
            _user = user;
        }

        public IEnumerable<IEntity> GetAll<T>(params object[] arg) where T : new()
        {
            T proverka = new T();
            if (proverka is Group) { return new List<Group>() { new Group() { TeacherId = 1, Id = 1 } }; }
            else if (proverka is Lead) { return new List<Lead>() { new Lead() { GroupId = 1, Group = new Group() { TeacherId = 1 } } }; }
            else if (proverka is HistoryGroup) { return new List<HistoryGroup> { new HistoryGroup { GroupId = 1 } }; }
            else if (proverka is History) { return new List<History> { new History { LeadId = 1 } }; }
            else if (proverka is Log) { return new List<Log> { new Log { LeadId = 1, Lead = new Lead { GroupId = 1 } } }; }
            else if (proverka is SkillsLead) { return new List<SkillsLead> { new SkillsLead { LeadId = 1 } }; }
            else if (proverka is Skills) { return new List<Skills> { new Skills() }; }
            else if (proverka is Course)
            {
                return new List<Course>
                {
                    new Course()  { Id = 1, Name = "C#", CourseInfo = "C# Information" },
                    new Course()  { Id = 2, Name = "Web", CourseInfo = "Web Information" },
                    new Course()  { Id = 3, Name = "QA", CourseInfo = "QA Information" },
                };
            }
            else if (proverka is HR)
            {
                return new List<HR>
                {
                    new HR()  { Id = 1,FName = "HR Name", SName = "HR Second Name"  },
                    new HR()  { Id = 2,FName = "HR2 Name", SName = "HR2 Second Name" },
                };
            }
            else if (proverka is Teacher)
            {
                return new List<Teacher>
                {
                    new Teacher()  { Id = 1, SName = "Teacher Second Name", FName = "Teacher Name"  },
                    new Teacher()  { Id = 2, SName = "Teacher2 Second Name", FName = "Teacher2 Name"  },
                };
            }
            return new List<IEntity>();
        }
        public bool Update(IEntity obj)
        {
            return true;
        }
        internal bool Delete(IEntity obj)
        {
            return true;
        }
        public bool Add(IEntity obj)
        {
            return true;
        }


    }
}
