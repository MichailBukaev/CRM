using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheTaskWorkMyself
    {
        private PublishingHouse publishingHouse;
        public string LoginExecuter { set; get; }
        public List<TaskWorkBusinessModel> TasksWork { get; set; }
        public bool FlagActual { get; set; }
        public CacheTaskWorkMyself(string loginExecuter)
        {
            TasksWork = new List<TaskWorkBusinessModel>();
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.CombineByExecuter[loginExecuter].Event += ReadChange;
            this.LoginExecuter = loginExecuter;
        }
        public void ReadChange(string loginAuthor)
        {
            FlagActual = false;
        }
    }
}
