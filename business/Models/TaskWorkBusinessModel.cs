using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class TaskWorkBusinessModel: IModelsBusiness
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string LoginAuthor { get; set; }
        public string LoginExecuter { get; set; }
        public string Text { get; set; }
        public int TasksStatusId { get; set; }
    }
}
