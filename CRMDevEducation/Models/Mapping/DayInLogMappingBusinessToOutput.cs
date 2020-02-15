using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;

namespace CRMDevEducation.Models.Mapping
{
    public class DayInLogMappingBusinessToOutput
    {
        public static List<OutputDayInLogModel> Map(List<DayInLogBusinessModel> _days)
        {
            List<OutputDayInLogModel> days = new List<OutputDayInLogModel>();
            foreach(DayInLogBusinessModel item in _days)
            {
                days.Add(new OutputDayInLogModel { Date = item.Date, StudentsInLog = StudentInLogBusinessToOutput.Map(item.StudentsInLog) });
            }
            return days;

        }
    }
}