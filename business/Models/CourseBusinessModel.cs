﻿using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class CourseBusinessModel: IModelsBusiness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseInfo { get; set; }
        public List<TeacherBusinessModel> Teachers { get; set; }
    }
}