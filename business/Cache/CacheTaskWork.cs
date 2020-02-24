using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheTaskWork
    {
        private PublishingHouse publishingHouse;
        public List<TaskWorkBusinessModel> TasksWork { get; set; }
        public bool FlagActual { get; set; }
        public CacheTaskWork()
        {
            TasksWork = new List<TaskWorkBusinessModel>();
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.TaskWork.Event += this.ReadChange;
        }
        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
