using business.Cache;
using business.Models;
using business.WSTeacher.Cache;
using business.WSUser.interfaces;
//using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using business.MockStorageForTeacher;

namespace business.WSTeacher.HeadTeacher
{
    public class MaxHeadTeacherManager : NormalTeacherManager
    {
        HistoryWriter historyWriter;
        public MaxHeadTeacherManager(int teacherId)
            : base(teacherId)
        {
            historyWriter = new HistoryWriter();

        }
        public int? AddNewSkill(SkillBusinessModel skill)
        {
            _storage = new StorageSkills();
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.Skills;
            IEntity skills = new Skills()
            {
                NameSkills = skill.NameSkill
            };
            if (_storage.Add(ref skills))
            {
                publisher.Notify();
                Skills newSkills = (Skills)skills;
                return newSkills.Id;
            }
            else
            {
                return null;
            }

        }

        public bool AssignTeacherForGroup(int teacherId, int groupeId)
        {
            bool ok = false;
            if (!_cache.Group.FlagActual)
            {
                ReconstructorTeacherManagerCache.UpdateCacheGroup(_cache.Group, _teacher);
            }
            GroupBusinessModel group = _cache.Group.Groups.FirstOrDefault(x => x.Id == groupeId);

            if (!_cache.Teachers.FlagActual)
            {
                ReconstructorTeacherManagerCache.UpdateCacheTeachers(_cache.Teachers, _teacher);
            }
            TeacherBusinessModel teacherLocal = _cache.Teachers.Teachers.FirstOrDefault(p => p.Id == teacherId);

            if (teacherLocal != null && group != null)
            {
                bool flag = false;
                for (int i = 0; i < teacherLocal.Courses.Count; i++)
                {
                    if (group.Course.Id == teacherLocal.Courses[i].Id)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    throw new Exception($"Этот преподаватель не может вести группу с курсом {group.Course.Name}");
                }

                Group currentGroup = new Group()
                {
                    Id = group.Id,
                    CourseId = group.Course.Id,
                    StartDate = group.StartDate,
                    NameGroup = group.Name,
                    TeacherId = teacherLocal.Id

                };

                _storage = new StorageGroup();
                ok = _storage.Update(currentGroup);
                PublishingHouse publishingHouse = PublishingHouse.Create();

                PublisherChangesInDB publisherGroupe = publishingHouse.Group,
                                     publisherTeacher = publishingHouse.Teacher;
                if (ok)
                {
                    historyWriter.AddTeacherToGroup(group.Id, teacherLocal.Id);
                    publisherGroupe.Notify();
                    publisherTeacher.Notify();

                }
            }
            return ok;
        }
        public int? AddNewCourse(CourseBusinessModel model)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.Courses;
            _storage = new StorageCourse();
            IEntity course = new Course
            {
                Name = model.Name,
                CourseInfo = model.CourseInfo
            };
            ;
            if (_storage.Add(ref course))
            {
                publisher.Notify();
                Course newCourse = (Course)course;
                return newCourse.Id;
            }
            else
            {
                return null;
            }

        }
        public bool AssignTeacherForCourse(int teacherId, int courseId)
        {
            bool result = false;
            if (!_cache.Teachers.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheTeachers(_cache.Teachers, _teacher);
            TeacherBusinessModel currentTeacher = _cache.Teachers.Teachers.FirstOrDefault(p => p.Id == teacherId);
            if (!_cache.Course.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheCourses(_cache.Course, _teacher);
            CourseBusinessModel currentCourse = _cache.Course.Courses.FirstOrDefault(p => p.Id == courseId);
            _storage = new StorageLinkTeacherCourse();
            LinkTeacherCourse linkTeacherCourse = new LinkTeacherCourse() { CourseId = currentCourse.Id, TeacherId = currentTeacher.Id};
            IEntity entityNew = linkTeacherCourse;
            result = _storage.Add(ref entityNew);
            if (result)
            {
                PublishingHouse publishingHouse = PublishingHouse.Create();
                publishingHouse.Teacher.Notify();
                publishingHouse.Courses.Notify();
            }
            return result;
        }

        public int? SetTasksForSlaves(string task, DateTime deadLine, int tasksStatusId, string loginExecuter)
        {
            
            PublishingHouse publishingHouse = PublishingHouse.Create();
            _storage = new StorageTaskWork();
            IEntity slavesTask = new TaskWork()
            {
                DateStart = DateTime.Now,
                DateEnd = deadLine,
                Text = task,
                LoginAuthor = _teacher.Login,
                LoginExecuter = loginExecuter,
                TasksStatusId = tasksStatusId
            };
            if (_storage.Add(ref slavesTask))
            {

                publishingHouse.CombineByExecuter[loginExecuter].Notify(_teacher.Login);
                TaskWork taskSet = (TaskWork)slavesTask;
                return taskSet.Id;
            }
            else
                return null;
        }
       
        public List<TaskWorkBusinessModel> GetAllTasksForSlaves()
        {
            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();
            
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheTaskForSlaves(item, _teacher.Login);
                if(item.TasksWork.Count>0)
                {
                    tasks.AddRange(item.TasksWork);
                }
                
            }
            return tasks;
        }
        
        public List<TaskWorkBusinessModel> GetAllTasksForSlaves(int idStatusTask)
        {
            
            if (!_cache.TasksStatus.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheMyselfTask(_cache.TaskWorkMyself, _teacher.Login);
            TasksStatusBusinessModel tasksStatuses = _cache.TasksStatus.TasksStatus.FirstOrDefault(x => x.Id == idStatusTask);

            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheTaskForSlaves(item, _teacher.Login);
                if (item.TasksWork.Count > 0)
                {
                    tasks.AddRange(item.TasksWork.Where(x => x.TasksStatusId == tasksStatuses.Id).ToList());
                }

            }
            return tasks;
        }
        
        public List<TaskWorkBusinessModel> GetAllTasksForSlaves(DateTime dateStart)
        {
            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();

            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheTaskForSlaves(item, _teacher.Login);
                if (item.TasksWork.Count > 0)
                {
                    tasks.AddRange(item.TasksWork.Where(x => x.DateStart.CompareTo(dateStart) > 0).ToList());
                }

            }
            return tasks;

        }

        public List<TaskWorkBusinessModel> GetAllTasksForSlaves(string loginExecuter)
        {
            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheTaskForSlaves(item, _teacher.Login);
                if (item.TasksWork.Count > 0)
                {
                    tasks.AddRange(item.TasksWork.Where(x => x.LoginExecuter == loginExecuter).ToList());
                }

            }
            return tasks;
        }
        public List<TaskWorkBusinessModel> GetAllTasksForSlaves(string loginExecuter, int idStatusTask)
        {
            if (!_cache.TasksStatus.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheMyselfTask(_cache.TaskWorkMyself, _teacher.Login);
            TasksStatusBusinessModel tasksStatuses = _cache.TasksStatus.TasksStatus.FirstOrDefault(x => x.Id == idStatusTask);

            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();
            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheTaskForSlaves(item, _teacher.Login);
                if (item.TasksWork.Count > 0)
                {
                    tasks.AddRange(item.TasksWork.Where(x => x.TasksStatusId == tasksStatuses.Id && x.LoginExecuter == loginExecuter).ToList());
                }

            }
            return tasks;
        }
        public List<TaskWorkBusinessModel> GetAllTasksForSlaves(string loginExecuter, DateTime dateStart)
        {
            List<TaskWorkBusinessModel> tasks = new List<TaskWorkBusinessModel>();

            foreach (CacheTaskWorkForSlavesCombineByExecuter item in _cache.TaskWorkForSlavesCombineByExecuters)
            {
                if (!item.FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheTaskForSlaves(item, _teacher.Login);
                if (item.TasksWork.Count > 0)
                {
                    tasks.AddRange(item.TasksWork.Where(x => x.DateStart.CompareTo(dateStart) > 0 && x.LoginExecuter == loginExecuter).ToList());
                }

            }
            return tasks;
        }

        public int GetIdStatusTask(string nameStatus)
        {
            if (!_cache.TasksStatus.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheMyselfTask(_cache.TaskWorkMyself, _teacher.Login);
            int tasksStatusesId = _cache.TasksStatus.TasksStatus.FirstOrDefault(x => x.Name == nameStatus).Id;
            return tasksStatusesId;
        }
    }
}
