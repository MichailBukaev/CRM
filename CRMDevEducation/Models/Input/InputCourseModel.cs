﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Input
{
    public class InputCourseModel: IModelInput
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CourseInfo { get; set; }

    }
}
