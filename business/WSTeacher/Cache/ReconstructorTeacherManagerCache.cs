using business.Cache;
using business.Models;
using business.Models.CutModel;
using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSTeacher.Cache
{
    public static class ReconstructorTeacherManagerCache
    {
        static IStorage storage;
        public static CacheLeadsCombineByGroup UpdateCacheLeads(CacheLeadsCombineByGroup cache)
        {
            storage = new StorageLead();
            List<LeadBusinessModel> leads = new List<LeadBusinessModel>();
            List<Lead> leadsEntity = (List<Lead>)storage.GetAll(Lead.Fields.GroupId.ToString(), cache.GroupId.ToString());
            if (leadsEntity != null)
            {
                foreach (Lead itemLead in leadsEntity)
                {
                    List<SkillBusinessModel> skillsList = new List<SkillBusinessModel>();
                    storage = new StorageSkillsLead();
                    List<SkillsLead> skillsleads = (List<SkillsLead>)storage.GetAll(SkillsLead.Fields.LeadId.ToString(), itemLead.Id.ToString());
                    if (skillsleads != null)
                    {
                        foreach (SkillsLead itemSkillLead in skillsleads)
                        {
                            skillsList.Add(new SkillBusinessModel()
                            {
                                IdSkill = itemSkillLead.SkillsId,
                                NameSkill = itemSkillLead.Skill.NameSkills
                            });
                        }
                    }

                    List<string> histories = new List<string>();
                    storage = new StorageHistory();
                    List<History> historiesEntity = (List<History>)storage.GetAll(History.Fields.LeadId.ToString(), itemLead.Id.ToString());
                    if (historiesEntity != null)
                    {
                        foreach (History itemHistory in historiesEntity)
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
                        {
                            Id = itemLead.Status.Id,
                            Name = itemLead.Status.Name
                        },
                        Skills = skillsList,
                        History = histories
                    });
                }
            }
            cache.Leads = leads;
            cache.FlagActual = true;
            return cache;
        }
        public static CacheGroup UpdateCacheGroup(CacheGroup cache, Teacher teacher)
        {
            storage = new StorageGroup();
            List<GroupBusinessModel> groups = new List<GroupBusinessModel>();
            List<Group> entityGroups = new List<Group>();
            if (teacher.Head)
            {
                entityGroups = (List<Group>)storage.GetAll();
            }
            else
            {
                entityGroups = (List<Group>)storage.GetAll(Group.Fields.TeacherId.ToString(), teacher.Id.ToString());
            }

            if (entityGroups != null)
            {
                foreach (Group item in entityGroups)
                {
                    CutTeacherBusinessModel cutTeacher = null;
                    CutCourseBusinessModel cutCourse = null;
                    if (item.Teacher != null)
                        cutTeacher = new CutTeacherBusinessModel() { Id = item.TeacherId, FName = item.Teacher.FName, SName = item.Teacher.SName };
                    if (item.Course != null)
                        cutCourse = new CutCourseBusinessModel() { Id = item.CourseId, Name = item.Course.Name };

                    storage = new StorageHistoryGroup();

                    List<HistoryGroup> _history = (List<HistoryGroup>)storage.GetAll(HistoryGroup.Fields.GroupId.ToString(), item.Id.ToString());
                    List<string> history = new List<string>();
                    if (_history != null)
                    {
                        foreach (HistoryGroup historyItem in _history)
                        {
                            history.Add(historyItem.HistoryText);
                        }
                    }

                    storage = new StorageLead();

                    List<Lead> leads = (List<Lead>)storage.GetAll(Lead.Fields.GroupId.ToString(), item.Id.ToString());
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

                    storage = new StorageLog();

                    List<Log> logs = new List<Log>();
                    if (leads != null)
                    {
                        foreach (var itemLead in leads)
                        {
                            logs.AddRange((List<Log>)storage.GetAll(Log.Fields.LeadId.ToString(), itemLead.Id.ToString()));
                        }
                    }

                    
                    List<DayInLogBusinessModel> days = new List<DayInLogBusinessModel>();
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
            cache.Groups = groups;
            cache.FlagActual = true;
            return cache;
        }
        public static CacheTeachers UpdateCacheTeachers(CacheTeachers cache, Teacher teacher)
        {
            storage = new StorageTeacher();
            List<TeacherBusinessModel> teachersCache = new List<TeacherBusinessModel>();
            List<Teacher> teachers = new List<Teacher>();
            if (teacher.Head)
            {
                teachers = (List<Teacher>)storage.GetAll();  
            }
            else
            {
                teachers = (List<Teacher>)storage.GetAll(Teacher.Fields.Id.ToString(), teacher.Id.ToString());
            }
            if (teachers != null)
            {
                foreach (Teacher item in teachers)
                {
                    storage = new StorageLinkTeacherCourse();
                    List<LinkTeacherCourse> courses = (List<LinkTeacherCourse>)storage.GetAll(LinkTeacherCourse.Fields.TeacherId.ToString(), teacher.Id.ToString());
                    List<CutCourseBusinessModel> cutCourses = new List<CutCourseBusinessModel>();
                    foreach (LinkTeacherCourse itemCourse in courses)
                    {
                        cutCourses.Add(new CutCourseBusinessModel()
                        {
                            Id = itemCourse.CourseId,
                            Name = itemCourse.Course.Name
                        });
                    }

                    storage = new StorageGroup();
                    List<Group> groups = (List<Group>)storage.GetAll(Group.Fields.TeacherId.ToString(), teacher.Id.ToString());
                    List<CutGroupBusinessModel> cutGroup = new List<CutGroupBusinessModel>();
                    foreach (Group itemGroup in groups)
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
                    teachersCache.Add(teacherBusiness);
                }
            }
            cache.Teachers = teachersCache;
            cache.FlagActual = true;
            return cache;
        }
        public static CacheCourse UpdateCacheCourses(CacheCourse cache, Teacher teacher)
        {
            storage = new StorageCourse();
            List<Course> courses = new List<Course>();
            
            courses = (List<Course>)storage.GetAll();
            List<CourseBusinessModel> resultCourses = new List<CourseBusinessModel>();
            storage = new StorageLinkTeacherCourse();
            List<LinkTeacherCourse> courseWithteacher = (List<LinkTeacherCourse>)storage.GetAll();
            if (!teacher.Head)
            {
                List<Course> coursestmp = new List<Course>();
                List<LinkTeacherCourse> courseWithCurrentteacher = (List<LinkTeacherCourse>)courseWithteacher.Where(p => p.TeacherId == teacher.Id);
                foreach (LinkTeacherCourse item in courseWithCurrentteacher)
                {
                    coursestmp.Add(courses.FirstOrDefault(p => p.Id == item.CourseId));
                }
                courses = coursestmp;
            }
            foreach (Course item in courses)
            {
                List<CutTeacherBusinessModel> teachers = new List<CutTeacherBusinessModel>();
                foreach (LinkTeacherCourse itemTeacher in courseWithteacher.Where(x => x.CourseId == item.Id))
                {
                    teachers.Add(new CutTeacherBusinessModel()
                    {
                        Id = itemTeacher.TeacherId,
                        FName = itemTeacher.Teacher.FName,
                        SName = itemTeacher.Teacher.SName
                    });
                }
                resultCourses.Add(new CourseBusinessModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Teachers = teachers,
                    CourseInfo = item.CourseInfo
                });
            }
            cache.Courses = resultCourses;
            cache.FlagActual = true;
            return cache;
        }
        public static CacheStatus UpdateCacheStatus(CacheStatus cache)
        {
            storage = new StorageStatus();
            List<Status> statuses = (List<Status>)storage.GetAll();
            List<StatusBusinessModel> statusesB = new List<StatusBusinessModel>();
            foreach (Status item in statuses)
            {
                statusesB.Add(new StatusBusinessModel { Id = item.Id, Name = item.Name });
            }
            cache.Statuses = statusesB;
            cache.FlagActual = true;
            return cache;
        }
        public static CacheSkills UpdateCacheSkills(CacheSkills cache)
        {
            storage = new StorageSkills();
            List<Skills> skills = (List<Skills>)storage.GetAll();
            List<SkillBusinessModel> skillsB = new List<SkillBusinessModel>();
            foreach (Skills item in skills)
            {
                skillsB.Add(new SkillBusinessModel()
                {
                    IdSkill = item.Id,
                    NameSkill = item.NameSkills
                });
            }
            cache.FlagActual = true;
            cache.Skills= skillsB;
            return cache;
        }
        public static CacheTaskWorkMyself UpdateCacheMyselfTask(CacheTaskWorkMyself cache, string loginExecuter)
        {
            storage = new StorageTaskWork();
            List<TaskWork> tasks = (List<TaskWork>)storage.GetAll(TaskWork.Fields.LoginExecuter.ToString(), loginExecuter); 
            List<TaskWorkBusinessModel> taskBM = new List<TaskWorkBusinessModel>();
            foreach(TaskWork item in tasks)
            { 
                taskBM.Add(new TaskWorkBusinessModel()
                {
                    Id = item.Id,
                    DateStart = item.DateStart,
                    DateEnd = item.DateEnd,
                    LoginAuthor = item.LoginAuthor,
                    LoginExecuter = item.LoginExecuter,
                    TasksStatusId = item.TasksStatusId,
                    Text = item.Text
                    
                });
            }
            cache.FlagActual = true;
            cache.TasksWork = taskBM;
            return cache;

        }
        public static CacheTaskWorkForSlavesCombineByExecuter UpdateCacheTaskForSlaves(CacheTaskWorkForSlavesCombineByExecuter cache, string loginAuthor)
        {
            storage = new StorageTaskWork();
            List<TaskWork> tasks = (List<TaskWork>)storage.GetAll(TaskWork.Fields.LoginAuthor.ToString(), loginAuthor);
            List<TaskWorkBusinessModel> taskBM = new List<TaskWorkBusinessModel>();
            foreach (TaskWork item in tasks)
            {
                taskBM.Add(new TaskWorkBusinessModel()
                {
                    Id = item.Id,
                    DateStart = item.DateStart,
                    DateEnd = item.DateEnd,
                    LoginAuthor = item.LoginAuthor,
                    LoginExecuter = item.LoginExecuter,
                    TasksStatusId = item.TasksStatusId,
                    Text = item.Text

                });
            }
            cache.FlagActual = true;
            cache.TasksWork = taskBM;
            return cache;

        }

    }
}
