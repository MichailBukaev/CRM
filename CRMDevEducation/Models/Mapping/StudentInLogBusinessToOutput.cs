using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;

namespace CRMDevEducation.Models.Mapping
{
    internal class StudentInLogBusinessToOutput
    {
        internal static List<OutputStudentInLog> Map(List<StudentInLogBusinessModel> _studentsInLog)
        {
            List<OutputStudentInLog> studentsInLog = new List<OutputStudentInLog>();
            foreach(StudentInLogBusinessModel item in _studentsInLog)
            {
                studentsInLog.Add(new OutputStudentInLog { 
                    LeadId = item.LeadId, 
                    LeadFName = item.LeadFName, 
                    LeadSName = item.LeadSName, 
                    Vist = item.Visit 
                });
            }
            return studentsInLog;
        }
    }
}