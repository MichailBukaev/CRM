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
        public string LoginAuthor { get; set; }
        public string LoginExecuter { get; set; }
        public string Text { get; set; }

        public int TasksStatusId { get; set; }
        public TasksStatus TasksStatus { get; set; }
<<<<<<< HEAD

        public enum Fields
        {

            Id,
            DateStart,
            DateEnd,
            LoginAuthor,
=======
        public enum Fields
        {
            Id,
            DateStart,
            DateEnd,
            LoginAutor,
>>>>>>> 6a1d71cab29169f5471efc096a5f27976ddb5947
            LoginExecuter,
            Text,
            TasksStatusId
        }
    }
}
