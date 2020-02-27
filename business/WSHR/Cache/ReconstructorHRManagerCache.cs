using business.Cache;
using business.Models;
using business.Models.CutModel;
using data.Storage;
using data.StorageEntity.Mock;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSHR.Cache
{
    public static class ReconstructorHRManagerCache
    {
        static IStorage storage;

        public static CacheLeadsCombineByStatus UpdateCacheLeads(CacheLeadsCombineByStatus cache)
        {
            storage = new StorageLead();
            List<LeadBusinessModel> leads = new List<LeadBusinessModel>();
            List<Lead> leadsEntity = (List<Lead>)storage.GetAll(Lead.Fields.StatusId.ToString(), cache.StatusId.ToString());
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

        public static CacheGroup UpdateCacheGroup(CacheGroup cache)
        {
            storage = new StorageGroup();
            List<GroupBusinessModel> groups = new List<GroupBusinessModel>();
            List<Group> entityGroups = new List<Group>();

            entityGroups = (List<Group>)storage.GetAll();

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

        public static CacheTeachers UpdateCacheTeachers(CacheTeachers cache)
        {
            storage = new StorageTeacher();
            List<TeacherBusinessModel> teachersCache = new List<TeacherBusinessModel>();
            List<Teacher> teachers = new List<Teacher>();

            teachers = (List<Teacher>)storage.GetAll();

            if (teachers != null)
            {
                foreach (Teacher item in teachers)
                {
                    storage = new StorageLinkTeacherCourse();
                    List<LinkTeacherCourse> courses = (List<LinkTeacherCourse>)storage.GetAll(LinkTeacherCourse.Fields.TeacherId.ToString(), item.Id.ToString());
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
                    List<Group> groups = (List<Group>)storage.GetAll(Group.Fields.TeacherId.ToString(), item.Id.ToString());
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

        public static CacheCourse UpdateCacheCourses(CacheCourse cache)
        {
            storage = new StorageCourse();
            List<Course> courses = new List<Course>();

            courses = (List<Course>)storage.GetAll();
            List<CourseBusinessModel> resultCourses = new List<CourseBusinessModel>();
            storage = new StorageLinkTeacherCourse();
            List<LinkTeacherCourse> courseWithteacher = (List<LinkTeacherCourse>)storage.GetAll();

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
            cache.Skills = skillsB;
            return cache;
        }

        public static CacheHRs UpdateCacheHRs(CacheHRs cache, HR hr)
        {
            storage = new StorageHR();
            List<HRBusinessModel> hrsCache = new List<HRBusinessModel>();
            List<HR> hrs = new List<HR>();
            if (hr.Head)
            {
                hrs = (List<HR>)storage.GetAll();
            }
            else
            {
                hrs = (List<HR>)storage.GetAll(HR.Fields.Id.ToString(), hr.Id.ToString());
            }
            if (hrs != null)
            {
                foreach (HR item in hrs)
                {
                    HRBusinessModel hrBusiness = new HRBusinessModel()
                    {
                        Id = item.Id,
                        FName = item.FName,
                        SName = item.SName,
                        Head = item.Head,
                        Login = item.Login,
                        Password = item.Password
                    };
                    hrsCache.Add(hrBusiness);
                }
            }
            cache.HRs = hrsCache;
            cache.FlagActual = true;
            return cache;
        }

        public static CacheTasksStatus UpdateCacheTasksStatus(CacheTasksStatus cache)
        {
            storage = new StorageTasksStatus();
            List<TasksStatus> taskStatuses = (List<TasksStatus>)storage.GetAll();
            List<TasksStatusBusinessModel> tasks = new List<TasksStatusBusinessModel>();
            foreach (TasksStatus item in taskStatuses)
            {
                tasks.Add(new TasksStatusBusinessModel()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            cache.TasksStatus = tasks;
            cache.FlagActual = true;
            return cache;
        }

        public static CacheTaskWorkMyself UpdateCacheTaskWorkMyself(CacheTaskWorkMyself cache, HR hr)
        {
            storage = new StorageTaskWork();
            List<TaskWork> tasks = (List<TaskWork>)storage.GetAll();
            tasks = tasks.Where(x => x.LoginExecuter == hr.Login).ToList();
            List<TaskWorkBusinessModel> tasksB = new List<TaskWorkBusinessModel>();
            foreach (TaskWork item in tasks)
            {
                tasksB.Add(new TaskWorkBusinessModel()
                {
                    Id = item.Id,
                    LoginAuthor = item.LoginAuthor,
                    LoginExecuter = item.LoginExecuter,
                    DateStart = item.DateStart,
                    DateEnd = item.DateEnd,
                    TasksStatusId = item.TasksStatusId,
                    Text = item.Text
                });
            }
            cache.TasksWork = tasksB;
            cache.FlagActual = true;
            return cache;
        }

        public static CacheTaskWorkForSlavesCombineByExecuter UpdateCacheTaskWorkForSlaves(CacheTaskWorkForSlavesCombineByExecuter cache, HR hr)//???хзшка
        {
            storage = new StorageTaskWork();
            List<TaskWork> taskWorks = (List<TaskWork>)storage.GetAll();
            List<TaskWorkBusinessModel> tasksB = new List<TaskWorkBusinessModel>();
            taskWorks = taskWorks.Where(x => x.LoginExecuter == cache.LoginExecuter).ToList();

            foreach (TaskWork item in taskWorks)
            {
                tasksB.Add(new TaskWorkBusinessModel()
                {
                    Id = item.Id,
                    LoginAuthor = item.LoginAuthor,
                    LoginExecuter = item.LoginExecuter,
                    DateStart = item.DateStart,
                    DateEnd = item.DateEnd,
                    TasksStatusId = item.TasksStatusId,
                    Text = item.Text
                });
            }
            cache.TasksWork = tasksB;
            cache.FlagActual = true;
            return cache;
        }
    }
}
