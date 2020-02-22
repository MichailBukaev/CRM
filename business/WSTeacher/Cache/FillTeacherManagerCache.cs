using business.Cache;
using business.Models;
using business.Models.CutModel;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSTeacher.Cache
{
    public class FillTeacherManagerCache
    {
        private TeacherEntityCache entityCache;
        private TeacherManagerCache cache;

        public FillTeacherManagerCache(TeacherEntityCache entityCache)
        {
            this.entityCache = entityCache;
            cache = new TeacherManagerCache();
        }

        public TeacherManagerCache Fill()
        {
            SetTeachers();
            SetGroups();
            SetLeads();
            SetSkills();
            SetCourse();
            SetStatus();
            return cache;
        }
        private void SetTeachers()
        {
            foreach (Teacher item in entityCache.Teachers)
            {
                List<CutCourseBusinessModel> cutCourses = new List<CutCourseBusinessModel>();
                foreach (Course itemCourse in entityCache.Courses)
                {
                    cutCourses.Add(new CutCourseBusinessModel()
                    {
                        Id = itemCourse.Id,
                        Name = itemCourse.Name
                    });
                }
                List<CutGroupBusinessModel> cutGroup = new List<CutGroupBusinessModel>();
                foreach (Group itemGroup in entityCache.Groups)
                {
                    cutGroup.Add(new CutGroupBusinessModel()
                    {
                        Id = itemGroup.Id,
                        Name = itemGroup.NameGroup
                    });
                }
                TeacherBusinessModel teacherBusiness = new TeacherBusinessModel()
                {
                    Id = item.Id,
                    FName = item.FName,
                    SName = item.SName,
                    Head = item.Head,
                    Login = item.Login,
                    Password = item.Password,
                    PhoneNumber = item.PhoneNumber,
                    Courses = cutCourses,
                    Groups = cutGroup
                };
                cache.Teachers.Teachers.Add(teacherBusiness);
            }
            cache.Teachers.FlagActual = true;
        }
        private void SetGroups()
        {
            if (entityCache.Groups != null)
            {
                List<GroupBusinessModel> groups = new List<GroupBusinessModel>();
                if (entityCache.Groups != null)
                {
                    foreach (Group item in entityCache.Groups)
                    {
                        CutTeacherBusinessModel cutTeacher = null;
                        CutCourseBusinessModel cutCourse = null;
                        if (item.Teacher != null)
                            cutTeacher = new CutTeacherBusinessModel() { Id = item.TeacherId, FName = item.Teacher.FName, SName = item.Teacher.SName };
                        if (item.Course != null)
                            cutCourse = new CutCourseBusinessModel() { Id = item.CourseId, Name = item.Course.Name };


                        List<HistoryGroup> _history = (List<HistoryGroup>)entityCache.HistoryGroups.Where(x => x.GroupId == item.Id);
                        List<string> history = null;
                        if (_history != null)
                        {
                            foreach (HistoryGroup historyItem in _history)
                            {
                                history.Add(historyItem.HistoryText);
                            }
                        }


                        List<Lead> leads = (List<Lead>)entityCache.Leads.Where(x => x.GroupId == item.Id);
                        List<CutLeadBusinessModel> cutLeads = new List<CutLeadBusinessModel>();
                        if (leads != null)
                        {
                            foreach (Lead itemLeads in leads)
                            {
                                cutLeads.Add(new CutLeadBusinessModel()
                                {
                                    Id = itemLeads.Id,
                                    FName = itemLeads.FName,
                                    SName = itemLeads.SName
                                });
                            }
                        }


                        List<Log> logs = null;
                        if (leads != null)
                        {
                            foreach (var itemLead in leads)
                            {
                                logs.AddRange(entityCache.Logs.Where(p => p.LeadId == itemLead.Id));
                            }
                        }


                        List<DayInLogBusinessModel> days = null;
                        if (logs != null)
                        {
                            var groupedLogByDay = logs.GroupBy(p => p.Date);
                            if (groupedLogByDay != null)
                            {
                                foreach (IGrouping<DateTime, Log> g in groupedLogByDay)
                                {
                                    DayInLogBusinessModel dayInLog = new DayInLogBusinessModel()
                                    {
                                        Date = g.Key
                                    };
                                    foreach (var t in g)
                                    {
                                        dayInLog.StudentsInLog.Add(new StudentInLogBusinessModel()
                                        {
                                            Lead = new CutLeadBusinessModel() { Id = t.LeadId, FName = t.Lead.FName, SName = t.Lead.SName },
                                            Visit = t.Visit
                                        });
                                    }
                                    days.Add(dayInLog);
                                }
                            }
                        }


                        LogBusinessModel logBusiness = new LogBusinessModel()
                        {
                            Days = days,
                            GroupName = item.NameGroup,
                            GroupId = item.Id
                        };


                        groups.Add(
                            new GroupBusinessModel()
                            {
                                Id = item.Id,
                                Name = item.NameGroup,
                                StartDate = item.StartDate,
                                Teacher = cutTeacher,
                                Course = cutCourse,
                                HistoryGroup = history,
                                Leads = cutLeads,
                                LogOfGroup = logBusiness
                            });

                    }
                }
                cache.Group.Groups = groups;
                cache.Group.FlagActual = true;
            }
        }
        private void SetLeads()
        {
            if (cache.Group != null)
            {
                foreach (GroupBusinessModel item in cache.Group.Groups)
                {
                    List<LeadBusinessModel> leads = new List<LeadBusinessModel>();
                    if(entityCache.Leads != null)
                    {
                        foreach(Lead itemLead in entityCache.Leads.Where(p => p.GroupId == item.Id))
                        {
                            List<SkillBusinessModel> skillsList = null;
                            List<SkillsLead> skillsleads = entityCache.SkillsLeads.Where(x => x.LeadId == itemLead.Id).ToList();
                            if(skillsleads != null)
                            {
                                foreach(SkillsLead itemSkillLead in skillsleads)
                                {
                                    skillsList.Add(new SkillBusinessModel()
                                    {
                                        IdSkill = itemSkillLead.SkillsId,
                                        NameSkill = itemSkillLead.Skill.NameSkills
                                    });
                                }
                            }


                            List<string> histories = null;
                            List<History> historiesEntity = entityCache.Histories.Where(p => p.LeadId == itemLead.Id).ToList();
                            if (historiesEntity != null)
                            {
                                foreach(History itemHistory in historiesEntity)
                                {
                                    histories.Add(itemHistory.HistoryText);
                                }
                            }


                            leads.Add(new LeadBusinessModel()
                            {
                                Id = itemLead.Id,
                                FName = itemLead.FName,
                                SName = itemLead.SName,
                                DateBirthday = itemLead.DateBirthday,
                                EMail = itemLead.EMail,
                                Numder = itemLead.Numder,
                                Login = itemLead.Login,
                                Password = itemLead.Password,
                                Status = new StatusBusinessModel() 
                                  { Id = itemLead.Status.Id,
                                    Name = itemLead.Status.Name
                                   },
                                Skills = skillsList,
                                History = histories
                            }) ;
                        }
                    }
                    CacheLeadsCombineByGroup cacheLeads = new CacheLeadsCombineByGroup(item.Id) { Leads = leads};
                    cacheLeads.FlagActual = true;
                    cache.Leads.Add(cacheLeads);
                }
            }
        }
        private void SetSkills()
        {
            if (entityCache.Leads != null)
            {
                List<SkillBusinessModel> skills = null;
                foreach (Skills item in entityCache.Skills)
                {
                    skills.Add(new SkillBusinessModel()
                    {
                        IdSkill = item.Id,
                        NameSkill = item.NameSkills
                    });
                }
                cache.Skills.FlagActual = true;
                cache.Skills.Skills.AddRange(skills);
            }
        }
        private void SetCourse()
        {
            if (entityCache.Teachers != null)
            {
                List<CourseBusinessModel> courses = null;
                
                foreach (Course item in entityCache.Courses)
                {
                    List<CutTeacherBusinessModel> teachers = null;
                    foreach (LinkTeacherCourse itemTeacher in entityCache.LinkTeacherCourses.Where(x => x.CourseId == item.Id))
                    {
                        teachers.Add(new CutTeacherBusinessModel()
                        {
                            Id = itemTeacher.TeacherId,
                            FName = itemTeacher.Teacher.FName,
                            SName = itemTeacher.Teacher.SName
                        });
                    }
                    courses.Add(new CourseBusinessModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Teachers = teachers,
                        CourseInfo = item.CourseInfo
                    });
                }
                cache.Course.Courses.AddRange(courses);
                cache.Course.FlagActual = true;
            }
        }
        private void SetStatus()
        {
            if (entityCache.Statuses != null)
            {
                List<StatusBusinessModel> statuses = null;
                foreach (Status item in entityCache.Statuses)
                {
                    statuses.Add(new StatusBusinessModel { Id = item.Id, Name = item.Name });
                }
                cache.Status.Statuses = statuses;
                cache.Status.FlagActual = true;
            }

        }
    }
}
