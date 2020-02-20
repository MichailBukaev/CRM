using business.Models;
using business.WSUser.interfaces;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSTeacher.HeadTeacher
{
    public class MaxHeadTeacherManager : TeacherManagerDecorater
    {
        public MaxHeadTeacherManager(TeacherManager teacherManager)
            : base(teacherManager)
        {
            _cache = teacherManager.Cache;
            SetCache();
        }
        public override bool AddSkillsForLead(SkillsForLeadBusinessModel model)
        {
            return base.AddSkillsForLead(model);
        }

        public override bool SetAttendence(DayInLogBusinessModel dayLog)
        {
            return base.SetAttendence(dayLog);
        }

        protected override void SetCache()
        {
          
            if (!_cache.FlagActual)
            {
                _cache.Teachers = (List<Teacher>)new StorageTeacher().GetAll();

                _storage = new StorageGroup();
                _cache.Groups = (List<Group>)_storage.GetAll();

                _storage = new StorageCourse();
                _cache.Courses = (List<Course>)_storage.GetAll();

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
                }
                else if (_cache.Leads != null)
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
                }
                else if (_cache.Groups != null)
                {
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
                else if (_cache.Leads != null)
                {
                    _storage = new StorageLog();
                    foreach (Lead item in _cache.Leads)
                    {
                        List<Log> logs = ((List<Log>)_storage.GetAll(Log.Fields.LeadId.ToString(), item.Id.ToString()));
                        foreach (Log itemLeads in logs)
                        {
                            _cache.Logs.Add(itemLeads);
                        }
                    }
                }
                else if (_cache.Leads != null)
                {
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
                
                _storage = new StorageLinkTeacherCourse();
                _cache.LinkTeacherCourses = (List<LinkTeacherCourse>)_storage.GetAll();

                _storage = new StorageSkills();
                _cache.Skills = (List<Skills>)_storage.GetAll();

                _cache.FlagActual = true;
            }
        }

        public int? AddNewSkill(SkillBusinessModel skill)
        {
            _storage = new StorageSkills();
            PublisherChangesInDB publisher = PublisherChangesInDB.GetPublisher();
            IEntity skills = new Skills() { 
                NameSkills = skill.NameSkill
            };
            if (_storage.Add(ref skills))
            {
                publisher.Notify(skills);
                Skills newSkills = (Skills)skills;
                return newSkills.Id;
            }
            else
            {
                return null;
            }
                
        }

        public bool AssignTeacherForGroup(UpdateGroupeTecherModelBusinessModel model)
        {
            bool ok = false;
            PublisherChangesInDB publisher = PublisherChangesInDB.GetPublisher();
            Group group = _cache.Groups.FirstOrDefault(p => p.Id == model.GroupId);
            group.TeacherId = model.TeaherId;
            _storage = new StorageGroup();
            if (_storage.Update(group))
            {
                publisher.Notify(group);
                ok = true;
            }
            return ok;
        }
        public int? AddNewCourse(CourseBusinessModel model)
        {
            PublisherChangesInDB publisher = PublisherChangesInDB.GetPublisher();
            _storage = new StorageCourse();
            IEntity course = new Course
            {
                Name = model.Name,
                CourseInfo = model.CourseInfo
            };
            ;
            if (_storage.Add(ref course))
            {
                publisher.Notify(course);
                Course newCourse = (Course)course;
                return newCourse.Id;
            }
            else
            {
                return null;
            }
                
        }
        public override List<GroupBusinessModel> GetAllGroupe()
        {
            return base.GetAllGroupe();
        }

        public override List<LinkTeacherCourseBusinessModel> GetAllCourse()
        {
            return base.GetAllCourse();
        }
    }
}
