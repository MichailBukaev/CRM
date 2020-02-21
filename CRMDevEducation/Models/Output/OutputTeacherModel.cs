﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputTeacherModel : IModelOutput
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public int PhoneNumber { get; set; }
        public bool Head { get; set; }
        public List<CutGroupOutputModel> Groups { get; set; }
        public List<CutCourseOutputModel> Courses { get; set; }
    }
}
