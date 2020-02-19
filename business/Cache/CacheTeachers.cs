using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheTeachers
    {
        public bool FlagActual { get; private set; }
        public List<TeacherBusinessModel> Teachers { get; set; }

        public CacheTeachers()
        {
            FlagActual = false;
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
