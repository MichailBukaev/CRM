using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSHR.Headhr.Cache
{
    public class FillEntityCache
    {
        HREntityCache entityCache;
        HR hr;
        IStorage _storage;
        public FillEntityCache(HR _hr)
        {
            this.hr = _hr;
            entityCache = new HREntityCache();
        }

        public HREntityCache Fill()
        {
            SetEntityHR();
            SetEntityTeachers();
            SetEntityGroup();
            SetEntityHistoryGroup();
            SetEntityLeads();
            SetEntityHistories();
            SetEntityLinkTeacherCourse();
            SetEntityCourse();
            SetEntityLog();
            SetEntitySkills();
            SetEntitySkillsLead();
            SetEntityStatuses();
            SetEntityTaskWork();
            SetEntityTaskStatus();
            return entityCache;
        }
        private void SetEntityHR()
        {
            _storage = new StorageHR();
            if (hr.Head)
                entityCache.HRs = (List<HR>)_storage.GetAll();
            entityCache.HRs.Add(hr);
        }
        private void SetEntityTeachers()
        {
            _storage = new StorageTeacher();
            entityCache.Teachers = (List<Teacher>)_storage.GetAll();
        }
        private void SetEntityGroup()
        {
            _storage = new StorageGroup();
            entityCache.Groups = (List<Group>)_storage.GetAll();
        }
        private void SetEntityHistoryGroup()
        {
            _storage = new StorageHistoryGroup();
            entityCache.HistoryGroups = (List<HistoryGroup>)_storage.GetAll();
        }
        private void SetEntityLeads()
        {
            _storage = new StorageLead();
            entityCache.Leads = (List<Lead>)_storage.GetAll();
        }
        private void SetEntityHistories()
        {
            _storage = new StorageHistory();
            entityCache.Histories = (List<History>)_storage.GetAll();
        }
        private void SetEntityLinkTeacherCourse()
        {
            _storage = new StorageLinkTeacherCourse();
            entityCache.LinkTeacherCourses = (List<LinkTeacherCourse>)_storage.GetAll();
        }
        private void SetEntityCourse()
        {
            _storage = new StorageCourse();
            entityCache.Courses = (List<Course>)_storage.GetAll();
        }
        private void SetEntityLog()
        {
            _storage = new StorageLog();
            entityCache.Logs = (List<Log>)_storage.GetAll();
        }
        private void SetEntitySkills()
        {
            _storage = new StorageSkills();
            entityCache.Skills = (List<Skills>)_storage.GetAll();
        }
        private void SetEntitySkillsLead()
        {
            _storage = new StorageSkillsLead();
            entityCache.SkillsLeads = (List<SkillsLead>)_storage.GetAll();
        }
        private void SetEntityStatuses()
        {
            _storage = new StorageStatus();
            entityCache.Statuses = (List<Status>)_storage.GetAll();
        }
        private void SetEntityTaskWork()
        {
            _storage = new StorageTaskWork();
            List<TaskWork> tasks = new List<TaskWork>();
            if (!hr.Head)
            {
                tasks = (List<TaskWork>)_storage.GetAll(TaskWork.Fields.LoginExecuter.ToString(), hr.Login);
            }
            else
            {
                tasks = (List<TaskWork>)_storage.GetAll();
                tasks = tasks.Where(p => p.LoginAuthor == hr.Login || p.LoginExecuter == hr.Login).ToList();
            }
            entityCache.TaskWorks = tasks;
        }
        private void SetEntityTaskStatus()
        {
            _storage = new StorageTasksStatus();
            List<TasksStatus> taskStatuses = (List<TasksStatus>)_storage.GetAll();
            entityCache.TasksStatuses = taskStatuses;
        }
    }
}
