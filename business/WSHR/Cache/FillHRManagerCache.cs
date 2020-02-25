using business.Cache;
using business.Models;
using business.Models.CutModel;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSHR.Headhr.Cache
{
    public class FillHRManagerCache
    {
        private HREntityCache entityCache;
        private HRManagerCache cache;
        private HR hr;
        public FillHRManagerCache(HREntityCache entityCache, HR hr)
        {
            this.entityCache = entityCache;
            cache = new HRManagerCache(hr);
            this.hr = hr;
        }
        public HRManagerCache Fill()
        {
            SetHRs();
            SetStatus();
            SetLeads();
            SetCourse();
            SetGroups();
            SetSkills();
            SetTeachers();
            SetTaskWorkMyself();
            SetTaskWorkForSlaves();
            SetTasksStatus();
            return cache;
        }

        
        private void SetStatus()
        {
            List<StatusBusinessModel> statuses = new List<StatusBusinessModel>();
            foreach (Status item in entityCache.Statuses)
            {
                statuses.Add(new StatusBusinessModel() { Id = item.Id, Name = item.Name });
            }
            cache.Statuses.Statuses = statuses;
            cache.Statuses.FlagActual = true;
        } 
        private void SetLeads()
        {
            foreach (StatusBusinessModel item in cache.Statuses.Statuses)
            {
                List<LeadBusinessModel> leads = new List<LeadBusinessModel>();
                foreach (Lead itemLead in entityCache.Leads.Where(p => p.StatusId == item.Id))
                {
                    List<SkillBusinessModel> skillsList = new List<SkillBusinessModel>();
                    List<SkillsLead> skills = entityCache.SkillsLeads.Where(p => p.LeadId == itemLead.Id).ToList();
                    foreach (SkillsLead itemSkill in skills)
                    {
                        skillsList.Add(new SkillBusinessModel() { IdSkill = itemSkill.SkillsId, NameSkill = itemSkill.Skill.NameSkills });
                    }

                    List<string> histories = new List<string>();
                    List<History> historyEntity = entityCache.Histories.Where(p => p.LeadId == itemLead.Id).ToList();
                    foreach (History itemHistory in historyEntity)
                    {
                        histories.Add(itemHistory.HistoryText);
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
                        Status = item,
                        Skills = skillsList,
                        History = histories
                    });
                }
                CacheLeadsCombineByStatus cacheLeads = new CacheLeadsCombineByStatus(item.Id) { Leads = leads };
                cacheLeads.FlagActual = true;
                cache.Leads.Add(cacheLeads);
            }

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

            List<GroupBusinessModel> groups = new List<GroupBusinessModel>();

            foreach (Group item in entityCache.Groups)
            {
                CutTeacherBusinessModel cutTeacher = null;
                CutCourseBusinessModel cutCourse = null;
                if (item.Teacher != null)
                    cutTeacher = new CutTeacherBusinessModel() { Id = item.TeacherId, FName = item.Teacher.FName, SName = item.Teacher.SName };
                if (item.Course != null)
                    cutCourse = new CutCourseBusinessModel() { Id = item.CourseId, Name = item.Course.Name };

                List<HistoryGroup> _history = (List<HistoryGroup>)entityCache.HistoryGroups.Where(x => x.GroupId == item.Id).ToList();
                List<string> history = new List<string>();

                foreach (HistoryGroup historyItem in _history)
                {
                    history.Add(historyItem.HistoryText);
                }

                List<Lead> leads = (List<Lead>)entityCache.Leads.Where(x => x.GroupId == item.Id).ToList();
                List<CutLeadBusinessModel> cutLeads = new List<CutLeadBusinessModel>();

                foreach (Lead itemLeads in leads)
                {
                    cutLeads.Add(new CutLeadBusinessModel()
                    {
                        Id = itemLeads.Id,
                        FName = itemLeads.FName,
                        SName = itemLeads.SName
                    });
                }

                List<Log> logs = new List<Log>();

                foreach (var itemLead in leads)
                {
                    logs.AddRange(entityCache.Logs.Where(p => p.LeadId == itemLead.Id));
                }

                List<DayInLogBusinessModel> days = new List<DayInLogBusinessModel>();

                var groupedLogByDay = logs.GroupBy(p => p.Date);

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

            cache.Groups.Groups = groups;
            cache.Groups.FlagActual = true;

        } 
        private void SetSkills()
        {
            if (entityCache.Leads != null)
            {
                List<SkillBusinessModel> skills = new List<SkillBusinessModel>();
                foreach (Skills item in entityCache.Skills)
                {
                    skills.Add(new SkillBusinessModel()
                    {
                        IdSkill = item.Id,
                        NameSkill = item.NameSkills
                    });
                }
                if (skills.Count != 0)
                    cache.Skills.Skills.AddRange(skills);
                cache.Skills.FlagActual = true;
                
            }
        } 
        private void SetCourse()
        {
            List<CourseBusinessModel> courses = new List<CourseBusinessModel>();
            foreach (Course item in entityCache.Courses)
            {
                List<CutTeacherBusinessModel> teachers = new List<CutTeacherBusinessModel>();
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
            cache.Courses.Courses.AddRange(courses);
            cache.Courses.FlagActual = true;

        }
        private void SetHRs()
        {
            foreach (HR item in entityCache.HRs)
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
                cache.HRs.HRs.Add(hrBusiness);
            }
            cache.HRs.FlagActual = true;
        }
        private void SetTaskWorkForSlaves()
        {
            List<TaskWork> taskWorks = entityCache.TaskWorks.Where(x => x.LoginExecuter != hr.Login).ToList();
            var taskWorkGroupedByExecuter = taskWorks.GroupBy(x => x.LoginExecuter);
            foreach (IGrouping<string, TaskWork> item in taskWorkGroupedByExecuter)
            {
                CacheTaskWorkForSlavesCombineByExecuter TasksForSlaves = new CacheTaskWorkForSlavesCombineByExecuter(item.Key, hr.Login);
                foreach (var task in item)
                {
                    TasksForSlaves.TasksWork.Add(new TaskWorkBusinessModel()
                    {
                        Id = task.Id,
                        LoginAuthor = task.LoginAuthor,
                        LoginExecuter = task.LoginExecuter,
                        DateStart = task.DateStart,
                        DateEnd = task.DateEnd,
                        TasksStatusId = task.TasksStatusId,
                        Text = task.Text
                    });
                }
                TasksForSlaves.FlagActual = true;
                cache.TaskWorkForSlavesCombineByExecuters.Add(TasksForSlaves);
            }
        }
        private void SetTasksStatus()
        {
            List<TasksStatus> tasksStatuses = entityCache.TasksStatuses;
            List<TasksStatusBusinessModel> tasks = new List<TasksStatusBusinessModel>();
            foreach (TasksStatus item in tasksStatuses)
            {
                tasks.Add(new TasksStatusBusinessModel()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            cache.TasksStatus.TasksStatus = tasks;
        }
        private void SetTaskWorkMyself()
        {
            List<TaskWork> taskWorks = entityCache.TaskWorks.Where(x => x.LoginExecuter == hr.Login).ToList();
            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();
            foreach (TaskWork item in taskWorks)
            {
                tasks.Add(new TaskWorkBusinessModel()
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
            cache.TaskWorkMyself.TasksWork = tasks;
            cache.TaskWorkMyself.FlagActual = true;
        }

    }
}
