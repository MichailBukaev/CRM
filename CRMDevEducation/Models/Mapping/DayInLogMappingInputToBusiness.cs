using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class DayInLogMappingInputToBusiness
    {
        public static DayInLogBusinessModel Map(InputDayInLogModel model)
        {
            List<StudentInLogBusinessModel> students = new List<StudentInLogBusinessModel>();
            foreach(var item in model.LeadsVisit)
            {
                students.Add(new StudentInLogBusinessModel
                {
                    LeadId = item.Key,
                    Visit = item.Value
                });
            }
            return new DayInLogBusinessModel()
            {
                  Date = model.Date,
                  StudentsInLog = students
            };
        }
    }
}
