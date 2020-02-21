using business.Models;
using business.Models.CutModel;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping.MappingCutModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class TeacherMappingInputToBusiness
    {
        public static TeacherBusinessModel Map(InputTeacherModel model)
        {
            List<CutGroupBusinessModel> groups = new List<CutGroupBusinessModel>();
            foreach (var item in model.Groups)
            {
                groups.Add(CutGroupMappingInputToBusiness.Map(item));
            }

            List<CutCourseBusinessModel> courses = new List<CutCourseBusinessModel>();
            foreach (var item in model.Courses)
            {
                courses.Add(CutCourseMappingInputToBusiness.Map(item));
            }

            return new TeacherBusinessModel()
            {   
                Id = model.Id,
                SName = model.SName,
                FName = model.FName,
                PhoneNumber = model.PhoneNumber,
                Login = model.Login,
                Password = model.Password,
                Head = model.Head,
                Groups = groups,
                Courses = courses
            };
        }
    }
}
