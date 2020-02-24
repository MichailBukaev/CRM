using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderTasksStatus : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<TasksStatus> primariTasksStatus = (List<TasksStatus>)entities;
            List<TasksStatus> tasksStatuses;

            if (TasksStatus.Fields.Id.ToString() == TKey) { tasksStatuses = primariTasksStatus.Where(p => p.Id == Convert.ToInt32(TValue)).ToList(); }
            else if (TasksStatus.Fields.Name.ToString() == TKey) { tasksStatuses = primariTasksStatus.Where(p => p.Name == TValue).ToList(); }

            else { tasksStatuses = primariTasksStatus; }
            return tasksStatuses;
        }
    }
}
