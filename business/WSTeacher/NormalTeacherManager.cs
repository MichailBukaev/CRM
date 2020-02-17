using business.Models;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSTeacher
{
    public class NormalTeacherManager : TeacherManager
    {
        public NormalTeacherManager(int teacherId)
        {
            _storage = new StorageTeacher();
            List<Teacher> teachers = (List<Teacher>)_storage.GetAll();
            _teacher = teachers.FirstOrDefault(p => p.Id == teacherId);
            _cache = new TeacherCache();
            if (!_teacher.Head)
            {
                SetCache();
            }
        }

        public override bool AddSkillsForLead(SkillsForLeadBusinessModel model)
        {
            PublisherChangesInBD publisher = PublisherChangesInBD.GetPublisher();
            _storage = new StorageSkillsLead();
            bool ok = true;
            for (int i = 0; i < model.IdSkills.Length; i++)
            {
                IEntity skillsLead = new SkillsLead()
                {
                    LeadId = model.IdLead,
                    SkillsId = model.IdSkills[i]
                };
                if (!_storage.Add(ref skillsLead))
                    ok = false;
                else
                    publisher.Notify(skillsLead);
            }
            return ok;
        }

        public override List<GroupBusinessModel> GetAllGroupe()
        {
            _storage = new StorageTeacher();
            _cache.Teachers.Add(_teacher);
            List<GroupBusinessModel> groups = new List<GroupBusinessModel>();
            foreach (Group item in _cache.Groups)
            {
                List<LeadBusinessModel> leadsbusines = new List<LeadBusinessModel>();
                if (_cache.Leads != null)
                {
                    List<Lead> leads = (List<Lead>)_cache.Leads.Where(p => p.GroupId == item.Id);
                    foreach (Lead itemLead in leads)
                    {
                        leadsbusines.Add(new LeadBusinessModel()
                        {
                            Id = itemLead.Id,
                            FName = itemLead.FName,
                            SName = itemLead.SName,
                            DateBirthday = itemLead.DateBirthday,
                            EMail = itemLead.EMail,
                            Status = itemLead.Status.Name,
                            Numder = itemLead.Numder
                        });
                    }
                }
                groups.Add(new GroupBusinessModel()
                {
                    Id = item.Id,
                    Name = item.NameGroup,
                    CourseId = item.CourseId,
                    CourseName = item.Course.Name,
                    TeacherId = (int)item.TeacherId,
                    StartDate = item.StartDate,
                    Leads = leadsbusines
                });
            }
            return groups;
        }

        public override bool SetAttendence(DayInLogBusinessModel dayLog)
        {
            PublisherChangesInBD publisher = PublisherChangesInBD.GetPublisher();
            _storage = new StorageLog();
            bool ok = true;
            for (int i = 0; i < dayLog.StudentsInLog.Count; i++)
            {
                IEntity log = new Log()
                {
                    Date = dayLog.Date,
                    LeadId = dayLog.StudentsInLog[i].LeadId
                };
                if (!_storage.Add(ref log))
                    ok = false;
                else
                    publisher.Notify(new Lead() { Id = dayLog.StudentsInLog[i].LeadId });
            }
            return ok;
        }

        protected override void SetCache()
        {
            if (!_cache.FlagActual)
            {
                _storage = new StorageTeacher();
                _cache.Teachers.Add(_teacher);
                _storage = new StorageGroup();
                _cache.Groups = (List<Group>)_storage.GetAll(Group.Fields.TeacherId.ToString(), _teacher.Id.ToString());



                if (_cache.Groups != null)
                {
                    _storage = new StorageLead();
                    foreach (Group item in _cache.Groups)
                    {
                        List<Lead> leads = ((List<Lead>)_storage.GetAll(Lead.Fields.Id.ToString(), item.Id.ToString()));
                        foreach (Lead itemLeads in leads)
                        {
                            _cache.Leads.Add(itemLeads);
                        }
                    }

                    _storage = new StorageHistoryGroup();
                    foreach (Group item in _cache.Groups)
                    {
                        List<HistoryGroup> historyGroups = ((List<HistoryGroup>)_storage.GetAll(HistoryGroup.Fields.GroupId.ToString(), item.Id.ToString()));
                        foreach (HistoryGroup itemhistoryGroups in historyGroups)
                        {
                            _cache.HistoryGroups.Add(itemhistoryGroups);
                        }
                    }
                }



                if (_cache.Leads != null)
                {
                    _storage = new StorageHistory();
                    foreach (Lead item in _cache.Leads)
                    {
                        List<History> histories = ((List<History>)_storage.GetAll(History.Fields.LeadId.ToString(), item.Id.ToString()));
                        foreach (History itemHistory in histories)
                        {
                            _cache.Histories.Add(itemHistory);
                        }
                    }

                    _storage = new StorageLog();
                    foreach (Lead item in _cache.Leads)
                    {
                        List<Log> logs = ((List<Log>)_storage.GetAll(Log.Fields.LeadId.ToString(), item.Id.ToString()));
                        foreach (Log itemLeads in logs)
                        {
                            _cache.Logs.Add(itemLeads);
                        }
                    }

                    _storage = new StorageSkillsLead();
                    foreach (Lead item in _cache.Leads)
                    {
                        List<SkillsLead> leads = ((List<SkillsLead>)_storage.GetAll(SkillsLead.Fields.LeadId.ToString(), item.Id.ToString()));
                        foreach (SkillsLead itemLeads in leads)
                        {
                            _cache.SkillsLeads.Add(itemLeads);
                        }
                    }
                }






                _storage = new StorageSkills();
                _cache.Skills = (List<Skills>)_storage.GetAll();



                _storage = new StorageLinkTeacherCourse();
                _cache.LinkTeacherCourses = (List<LinkTeacherCourse>)_storage.GetAll(LinkTeacherCourse.Fields.TeacherId.ToString(), _teacher.Id.ToString());

                if (_cache.LinkTeacherCourses != null)
                {
                    _storage = new StorageCourse();
                    foreach (LinkTeacherCourse item in _cache.LinkTeacherCourses)
                    {
                        List<Course> course = ((List<Course>)_storage.GetAll(Course.Fields.Id.ToString(), item.CourseId.ToString()));
                        foreach (Course itemCourse in course)
                        {
                            _cache.Courses.Add(itemCourse);
                        }
                    }
                }


                _cache.FlagActual = true;
            }
        }
    }
}
