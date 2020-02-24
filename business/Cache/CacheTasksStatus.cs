using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheTasksStatus
    {
        private PublishingHouse publishingHouse;
        public List<TasksStatusBusinessModel> TasksStatus { get; set; }
        public bool FlagActual { get; set; }
        public CacheTasksStatus()
        {
            TasksStatus = new List<TasksStatusBusinessModel>();
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.TasksStatus.Event += this.ReadChange;
        }
        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
