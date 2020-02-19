using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheCourse
    {
        public List<CourseBusinessModel> Courses { get; set; }
        public bool FlagActual { get; set; }
        public CacheCourse()
        {
            FlagActual = false;
        }
        public void ReadChange()
        {
            FlagActual = false;
        }


    }
}
