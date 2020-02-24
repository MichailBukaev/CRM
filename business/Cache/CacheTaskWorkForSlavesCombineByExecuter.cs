using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheTaskWorkForSlavesCombineByExecuter
    {
        private PublishingHouse publishingHouse;
        public string LoginExecuter { set; get; }
        public string LoginAuthor { get; set; }
        public List<TaskWorkBusinessModel> TasksWork { get; set; }
        public bool FlagActual { get; set; }
        public CacheTaskWorkForSlavesCombineByExecuter(string loginExecuter, string loginAuthor)
        {
            TasksWork = new List<TaskWorkBusinessModel>();
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.CombineByExecuter[loginExecuter].Event += ReadChange;
            this.LoginExecuter = loginExecuter;
            this.LoginAuthor = loginAuthor;
        }
        public void ReadChange(string loginAuthor)
        {
            if (this.LoginAuthor == loginAuthor)
            FlagActual = false;
        }
    }
}
