﻿using business.Models;
using business.Models.CutModel;
using CRMDevEducation.Models.Mapping.MappingCutModel;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class GroupMappingBusinessToOutput
    {
        public static OutputGroupModel Map(GroupBusinessModel model)
        {
            List<CutLeadOutputModel> leads = new List<CutLeadOutputModel>();
            string history = "";
            foreach (string item in model.HistoryGroup)
            {
                history += item;
            }
            foreach (CutLeadBusinessModel item in model.Leads)
            {
                leads.Add(CutLeadMappingBusinessToOutput.Map(item));
            }
            CutCourseOutputModel course = null;
            if (model.Course!=null)
                course = CutCourseMappingCutBusinessToOutput.Map(model.Course);
            CutTeacherOutputModel teacher = null;
            if (model.Teacher != null)
                teacher = CutTeacherMappingBusinessToOutput.Map(model.Teacher);

            return new OutputGroupModel()
            {
                Id = model.Id,
                NameGroup = model.Name,                
                Teacher = teacher,
                Course = course,
                StartData = model.StartDate,
                Leads = leads,
                Log = LogMappingBusinessToOutput.Map(model.LogOfGroup),
                History = history
            };
        }
    }
}
