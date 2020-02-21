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
                    Lead = new CutLeadOutputModel()
                    {
                        Id = item.Lead.Id,
                        FName = item.Lead.FName,
                        SName = item.Lead.SName
                    },
                    Visit = item.Visit
                });
            }
            return studentsInLog;
        }
    }
}