using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class TaskWork : IEntity
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string LoginAutor { get; set; }
        public string LoginExecuter { get; set; }
        public string Text { get; set; }

        public int TasksStatusId { get; set; }
        public TasksStatus TasksStatus { get; set; }
    }
}
