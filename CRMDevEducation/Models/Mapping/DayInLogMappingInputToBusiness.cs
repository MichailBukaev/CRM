using business.Models;
using business.Models.CutModel;
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
                    Lead = new CutLeadBusinessModel(){ Id = item.IdLead },
                    Visit = item.Visit
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
