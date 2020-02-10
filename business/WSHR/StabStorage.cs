using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    class StabStorage
    {
        object _user;
        public StabStorage(object user)
        {
            _user = user;
        }
       
        public IEnumerable<IEntity> GetAll(IEntity entity) 
        {

            if (entity is Group) { return new List<Group>() { new Group() { TeacherId = 1, Id = 1, NameGroup = "BASE_C#_KMN№1" } }; }
            else if (entity is Lead) { return new List<Lead>() { new Lead() { GroupId = 1, Group = new Group() { TeacherId = 1 } } }; }
            else if (entity is HistoryGroup) { return new List<HistoryGroup> { new HistoryGroup { GroupId = 1 } }; }
            else if (entity is History) { return new List<History> { new History { LeadId = 1 } }; }
            else if (entity is Log) { return new List<Log> { new Log { LeadId = 1, Lead = new Lead { GroupId = 1 } } }; }
            else if (entity is SkillsLead) { return new List<SkillsLead> { new SkillsLead { LeadId = 1 } }; }
            else if (entity is Skills) { return new List<Skills> { new Skills() }; }
            else if (entity is Status) { return new List<Status> { new Status() { Id = 1, Name = "В работе" } }; }
            else if (entity is Course)
            {
                return new List<Course>
                {
                    new Course()  { Id = 1, Name = "C#", CourseInfo = "C# Information" },
                    new Course()  { Id = 2, Name = "Web", CourseInfo = "Web Information" },
                    new Course()  { Id = 3, Name = "QA", CourseInfo = "QA Information" },
                };
            }
            else if (entity is HR)
            {
                return new List<HR>
                {
                    new HR()  { Id = 1,FName = "HR Name", SName = "HR Second Name"  },
                    new HR()  { Id = 2,FName = "HR2 Name", SName = "HR2 Second Name" },
                };
            }
            else if (entity is Teacher)
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
