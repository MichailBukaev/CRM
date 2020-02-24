using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class TasksStatusBusinessModel: IModelsBusiness
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
