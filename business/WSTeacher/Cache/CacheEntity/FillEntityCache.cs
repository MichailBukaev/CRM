using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSTeacher.Cache.CacheEntity
{
    public class FillEntityCache
    {
        TeacherEntityCache entityCache;
        Teacher teacher;
        IStorage _storage;
        public FillEntityCache(Teacher _teacher)
        {
            entityCache = new TeacherEntityCache();
            teacher = _teacher;
        }

        public TeacherEntityCache Fill()
        {
            SetEntityTeachers();
            SetEntityGroup();
            SetEntityHistoryGroup();
            SetEntityLeads();
            SetEntityHistoryLead();
            SetEntityLinkTeacherCourse();
            SetEntityCourse();
            SetEntityLog();
            SetEntitySkill();
            SetEntitySkillsLead();
            SetEntityStatus();
            return entityCache;
        }

        private void SetEntityTeachers()
        {
            _storage = new StorageTeacher();
            if (teacher.Head)
                entityCache.Teachers = (List<Teacher>)_storage.GetAll();
            entityCache.Teachers.Add(teacher);
           
        }
        private void SetEntityGroup()
        {
            _storage = new StorageGroup();
            if (teacher.Head)
                entityCache.Groups = (List<Group>)_storage.GetAll();
            else
                entityCache.Groups = (List<Group>)_storage.GetAll(Group.Fields.TeacherId.ToString(), teacher.Id.ToString());
           
        }
        private void SetEntityHistoryGroup()
        {
            _storage = new StorageHistoryGroup();
            if (entityCache.Groups != null)
            {
                List<HistoryGroup> historyGroups;
                foreach (Group item in entityCache.Groups)
                {
                    historyGroups = (List<HistoryGroup>)_storage.GetAll(HistoryGroup.Fields.GroupId.ToString(), item.Id.ToString());
                    if(historyGroups.Count>0)
                    entityCache.HistoryGroups.AddRange(historyGroups);
                }
            }
        }
        private void SetEntityLeads()
        {
            _storage = new StorageLead();
            List<Lead> leads;
            if (entityCache.Groups != null)
            {
                foreach (Group item in entityCache.Groups)
                {
                    leads = (List<Lead>)_storage.GetAll(Lead.Fields.GroupId.ToString(), item.Id.ToString());
                    if(leads.Count>0)
                    entityCache.Leads.AddRange(leads);
                }
            }
        }
        private void SetEntityHistoryLead()
        {
            _storage = new StorageHistory();
            List<History> historys = new List<History>();
            if (entityCache.Leads != null)
            {
                foreach (Lead item in entityCache.Leads)
                {
                    historys = (List<History>)_storage.GetAll(History.Fields.LeadId.ToString(), item.Id.ToString());
                    if(historys.Count>0)
                    entityCache.Histories.AddRange(historys);
                }
            }
        }
        private void SetEntityLinkTeacherCourse()
        {
            _storage = new StorageLinkTeacherCourse();
            entityCache.LinkTeacherCourses = (List<LinkTeacherCourse>)_storage.GetAll();
        }
        private void SetEntityCourse()
        {
            _storage = new StorageCourse();
            if (teacher.Head)
                entityCache.Courses = (List<Course>)_storage.GetAll();
            else
            {
                List<LinkTeacherCourse> linkTeacherCourses = entityCache.LinkTeacherCourses.Where(p => p.TeacherId == teacher.Id).ToList();
                if (linkTeacherCourses != null)
                {
                    foreach (LinkTeacherCourse item in linkTeacherCourses)
                    {
                        entityCache.Courses.AddRange((List<Course>)_storage.GetAll(Course.Fields.Id.ToString(), item.CourseId.ToString()));
                    }
                }
            }
        }
        private void SetEntityLog()
        {
            _storage = new StorageLog();
            if (entityCache.Leads != null)
            {
                foreach (Lead item in entityCache.Leads)
                {
                    entityCache.Logs.AddRange((List<Log>)_storage.GetAll(Log.Fields.LeadId.ToString(), item.Id.ToString()));
                }

            }
        }
        private void SetEntitySkill()
        {
            _storage = new StorageSkills();
            entityCache.Skills = (List<Skills>)_storage.GetAll();
        }
        private void SetEntitySkillsLead()
        {
            _storage = new StorageSkillsLead();
            if (entityCache.Leads != null)
            {
                foreach (Lead item in entityCache.Leads)
                {
                    entityCache.SkillsLeads.AddRange((List<SkillsLead>)_storage.GetAll(SkillsLead.Fields.LeadId.ToString(), item.Id.ToString()));
                }
            }
        }
        private void SetEntityStatus()
        {
            _storage = new StorageStatus();
            entityCache.Statuses = (List<Status>)_storage.GetAll();
        }
    }
}
