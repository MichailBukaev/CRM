using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheTeachers
    {
        private PublishingHouse publishingHouse;
        public bool FlagActual { get; private set; }
        public List<TeacherBusinessModel> Teachers { get; set; }

        public CacheTeachers()
        {
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.Teacher.Event += this.ReadChange;
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
