using business.Models;
using business.Models.CutModel;
using CRMDevEducation.Models.Mapping.MappingCutModel;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class TeacherMappingBusinessToOutput
    {
        public static OutputTeacherModel Map(TeacherBusinessModel model)
        {
            List<CutCourseOutputModel> cutCourses = new List<CutCourseOutputModel>();
            List<CutCourseBusinessModel> cutCourseBusinesses = model.Courses;
            if (cutCourseBusinesses != null)
            {
                foreach(CutCourseBusinessModel item in cutCourseBusinesses)
                {
                    cutCourses.Add(CutCourseMappingCutBusinessToOutput.Map(item));
                }
            }

            List<CutGroupOutputModel> cutGroups = new List<CutGroupOutputModel>();
            List<CutGroupBusinessModel> cutGroupBusinesses = model.Groups;
            if (cutGroupBusinesses != null)
            {
                foreach(CutGroupBusinessModel item in cutGroupBusinesses)
                {
                    cutGroups.Add(CutGroupMappingBusinessToOutput.Map(item));
                }
            }

            return new OutputTeacherModel()
            {
                Id = model.Id,
                FName = model.FName,
                SName = model.SName,
                PhoneNumber = model.PhoneNumber,
                Head = model.Head,
                Login = model.Login,
                Courses = cutCourses,
                Groups = cutGroups
            };
        }
    }
}
