using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderTaskWork : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<TaskWork> primariTasks = (List<TaskWork>)entities;
            List<TaskWork> tasks;
            if (TaskWork.Fields.Id.ToString() == TKey) { tasks = primariTasks.Where(p => p.Id == Convert.ToInt32(TValue)).ToList(); }
            else if (TaskWork.Fields.DateStart.ToString() == TKey) { tasks = primariTasks.Where(p => p.DateStart.ToString() == TValue).ToList(); }
            else if (TaskWork.Fields.DateEnd.ToString() == TKey) { tasks = primariTasks.Where(p => p.DateEnd.ToString() == TValue).ToList(); }
            else if (TaskWork.Fields.LoginAuthor.ToString() == TKey) { tasks = primariTasks.Where(p => p.LoginAuthor == TValue).ToList(); }
            else if (TaskWork.Fields.LoginExecuter.ToString() == TKey) { tasks = primariTasks.Where(p => p.LoginExecuter == TValue).ToList(); }
            else if (TaskWork.Fields.Text.ToString() == TKey) { tasks = primariTasks.Where(p => p.Text == TValue).ToList(); }
            else if (TaskWork.Fields.TasksStatusId.ToString() == TKey) { tasks = primariTasks.Where(p => p.TasksStatusId.ToString() == TValue).ToList(); }
            else { tasks = primariTasks; }
            return tasks;
        }
    }
}
