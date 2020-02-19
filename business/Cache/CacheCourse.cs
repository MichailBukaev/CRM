using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheCourse
    {
        private PublishingHouse publishingHouse;
        public List<CourseBusinessModel> Courses { get; set; }
        public bool FlagActual { get; set; }
        public CacheCourse()
        {
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.Courses.Event += this.ReadChange;
        }
        public void ReadChange()
        {
            FlagActual = false;
        }


    }
}
