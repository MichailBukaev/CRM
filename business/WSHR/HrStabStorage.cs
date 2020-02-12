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
        

        public IEnumerable<IEntity> GetAll<T>() where T : IEntity, new()
        {
            T proverka = new T();   
            if (proverka is Group) { return new List<Group>() { new Group() { TeacherId = 1, Id = 1, NameGroup = "BASE_C#_KMN№1" } }; }
            else if (proverka is Lead) { return new List<Lead>() { new Lead() { GroupId = 1, Group = new Group() { TeacherId = 1 } } }; }
            else if (proverka is HistoryGroup) { return new List<HistoryGroup> { new HistoryGroup { GroupId = 1 } }; }
            else if (proverka is History) { return new List<History> { new History { LeadId = 1 } }; }
            else if (proverka is Log) { return new List<Log> { new Log { LeadId = 1, Lead = new Lead { GroupId = 1 } } }; }
            else if (proverka is SkillsLead) { return new List<SkillsLead> { new SkillsLead { LeadId = 1 } }; }
            else if (proverka is Skills) { return new List<Skills> { new Skills() }; }
            else if (proverka is Status) { return new List<Status> { new Status() { Id = 1, Name = "В работе" } }; }
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

        public IEnumerable<IEntity> GetAll<T>(string Tkey, string TValue) where T : IEntity, new()
        {
            T proverka = new T();
            if (proverka is Group) {
                if ((Tkey == "TeacherId" && TValue == "1") ||
                    (Tkey == "Id" && TValue == "1") ||
                    (Tkey == "NameGroup" && TValue == "BASE_C#_KMN№1"))
                {
                    return new List<Group>() 
                    {
                        new Group() { TeacherId = 1, Id = 1, NameGroup = "BASE_C#_KMN№1" }
                    };
                }
            }
            else if (proverka is Lead) {
                if (Tkey == "GroupId" && TValue == "1")
                {
                    return new List<Lead>()
                    { 
                        new Lead() { GroupId = 1, Group = new Group() { TeacherId = 1 } } 
                    };
                }
            }
            else if (proverka is HistoryGroup) {
                if (Tkey == "GroupId" && TValue == "1")
                {
                    return new List<HistoryGroup>
                    {
                        new HistoryGroup { GroupId = 1 }
                    };
                }
            }
            else if (proverka is History) {
                if (Tkey == "LeadId" && TValue == "1")
                {
                    return new List<History>
                    {
                        new History { LeadId = 1 }
                    };
                }
            }
            else if (proverka is Log) {
                if (Tkey == "LeadId" && TValue == "1")
                {
                    return new List<Log> 
                    {
                        new Log { LeadId = 1, Lead = new Lead { GroupId = 1 } }
                    }; 
                }
            }
            else if (proverka is SkillsLead) {
                if (Tkey == "LeadId" && TValue == "1")
                {
                    return new List<SkillsLead> 
                    {
                        new SkillsLead { LeadId = 1 }
                    };

                }
            }
            else if (proverka is Skills) {
                if (Tkey == "1" && TValue == "Skill")
                {
                    return new List<Skills>
                    {
                        new Skills{ Id = 1, NameSkills = "Skill" }
                    };
                }
            }
            else if (proverka is Status) {
                if (Tkey == "1" && TValue == "В работе")
                {
                    return new List<Status> 
                    {
                        new Status() { Id = 1, Name = "В работе" } 
                    }; 
                }
            }
            else if (proverka is Course)
            {
                if ((Tkey == "Id" && TValue == "1")||
                    (Tkey == "Name" && TValue == "C#") ||
                    (Tkey == "CourseInfo" && TValue == "C# Information"))
                {
                    return new List<Course>
                    {
                        new Course()  { Id = 1, Name = "C#", CourseInfo = "C# Information" }  
                    };
                } else 
                if ((Tkey == "Id" && TValue == "2") ||
                    (Tkey == "Name" && TValue == "Web") ||
                    (Tkey == "CourseInfo" && TValue == "Web Information"))
                {
                    return new List<Course>
                    {
                        new Course()  { Id = 2, Name = "Web", CourseInfo = "Web Information" }   
                    };
                } else 
                if ((Tkey == "Id" && TValue == "3") ||
                    (Tkey == "Name" && TValue == "QA") ||
                    (Tkey == "CourseInfo" && TValue == "QA Information"))
                {
                    return new List<Course>
                    {
                        new Course()  { Id = 3, Name = "QA", CourseInfo = "QA Information" }
                    };
                }

            }
            else if (proverka is HR)
            {
                if ((Tkey == "Id" && TValue == "1") ||
                    (Tkey == "FName" && TValue == "HR Name") ||
                    (Tkey == "SName" && TValue == "HR Second Name")
                    )
                {
                    return new List<HR>
                    {
                        new HR()  { Id = 1,FName = "HR Name", SName = "HR Second Name"  } 
                    };

                }else 
                if ((Tkey == "Id" && TValue == "1") ||
                  (Tkey == "FName" && TValue == "HR2 Name") ||
                  (Tkey == "SName" && TValue == "HR2 Second Name")
                  )
                {
                    return new List<HR>
                    {
                        new HR()  { Id = 2,FName = "HR2 Name", SName = "HR2 Second Name" }
                    };

                }
            }
            else if (proverka is Teacher)
            {
                if ((Tkey == "Id" && TValue == "1") ||
                   (Tkey == "SName" && TValue == "Teacher Second Name") ||
                   (Tkey == "FName" && TValue == "Teacher Name")
                   )
                {
                    return new List<Teacher>
                    {
                        new Teacher()  { Id = 1, SName = "Teacher Second Name", FName = "Teacher Name"  }
                    };

                }
                if ((Tkey == "Id" && TValue == "2") ||
                  (Tkey == "SName" && TValue == "Teacher2 Second Name") ||
                  (Tkey == "FName" && TValue == "Teacher2 Name")
                  )
                {
                    return new List<Teacher>
                    {

                        new Teacher()  { Id = 2, SName = "Teacher2 Second Name", FName = "Teacher2 Name"  }
                    };

                }

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
