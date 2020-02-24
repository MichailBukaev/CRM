using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class TasksStatus: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public enum Fields
        {
            Id,
            Name
        }
    }
}
