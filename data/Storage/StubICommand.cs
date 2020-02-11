using models;
using System;
using System.Collections.Generic;

namespace data.Storage
{
    public interface StubICommand
    {

    }
    public class Read : StubICommand
    {
        public IEnumerable<IEntity> Execute<T>() where T : IEntity, new()
        {
            T obj = new T();
            if (obj is Lead)
            {
                return new List<Lead>() { new Lead { Id = 1, GroupId = 1 }, new Lead { Id = 2, GroupId = 1 }, new Lead { Id = 3, GroupId = 2 } };
            }
            else if (obj is Course)
            {
                return new List<Course>() { new Course { Id = 1, Name = "1" }, new Course { Id = 2, Name = "1" }, new Course { Id = 3, Name = "2" } };
            }
            else if (obj is Group)
            {
                return new List<Group>() { new Group { Id = 1, NameGroup = "C#123", TeacherId = 1 }, new Group { Id = 2, NameGroup = "C#123" , TeacherId=2}, new Group { Id = 3, NameGroup = "frontend", TeacherId=1 } };
            }
            else if (obj is History)
            {
                return new List<History>() { new History { LeadId = 1 }, new History { LeadId = 1 },new History { LeadId = 2 }, new History { LeadId = 1 }, new History { LeadId = 3 } };
            }
            else if (obj is HistoryGroup)
            {
                return new List<HistoryGroup>() { new HistoryGroup { GroupId = 1 }, new HistoryGroup { GroupId = 1 }, new HistoryGroup { GroupId = 2 }, new HistoryGroup { GroupId = 1 }, new HistoryGroup { GroupId = 3 } };
            }
            else if(obj is HR)
            {
                return new List<HR>() { new HR { FName = "Pol", Id = 1 }, new HR { FName = "Ivan", Id = 2 }, new HR { FName = "Petya", Id = 3 } };
            }
            else if(obj is Log)
            {
                return new List<Log>() { 
                    new Log { LeadId = 1, Date = DateTime.Parse("12.02.2020") }, 
                    new Log { LeadId = 2, Date = DateTime.Parse("12.02.2020") }, 
                    new Log { LeadId = 1, Date = DateTime.Parse("13.02.2020") } 
                };
            }
            else if(obj is SkillsLead)
            {
                return new List<SkillsLead>() {
                    new SkillsLead{LeadId = 1, SkillsId = 1},
                    new SkillsLead{LeadId = 1, SkillsId = 2},
                    new SkillsLead{LeadId = 2, SkillsId = 1},
                    new SkillsLead{LeadId = 3, SkillsId = 2},
                };
            }
            else if(obj is Skills)
            {
                return new List<Skills>(){
                    new Skills{Id=1, NameSkills = "API" },
                    new Skills{Id=2, NameSkills = "SQL" },
                    new Skills{Id=3, NameSkills = "TDD" },
                };
            }
            else if (obj is Status)
            {
                return new List<Status>(){
                    new Status{Id=1, Name = "lead" },
                    new Status{Id=2, Name = "student" },
                    new Status{Id=3, Name = "tupoy" },
                };
            }
            else if(obj is Teacher)
            {
                return new List<Teacher>()
                {
                    new Teacher{Id = 1, FName = "Ivan", SName= "Ivanov", PhoneNumber = 123, Login = "loginIvan", Password = "123Ivan"},
                    new Teacher{Id = 2, FName = "Petr", SName= "Petrov", PhoneNumber = 321, Login = "loginPetr", Password = "123Petr"},
                };
            }
            else { return null; }
        }
    }
    public class Create : StubICommand
    {
        public void Execute(IEntity obj)
        {
            
        }
    }
    public class Update : StubICommand
    {
        public void Execute(IEntity obj)
        {

        }
    }
    public class Delete : StubICommand
    {
        public void Execute(IEntity obj)
        {

        }
    }

}
        
