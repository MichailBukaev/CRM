using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class DayInLogBusinessModel: IModelsBusiness
    {
        public DateTime Date { get; set; }
        public List<StudentInLogBusinessModel> StudentsInLog{ get; set; } 
        public DayInLogBusinessModel()
        {
            StudentsInLog = new List<StudentInLogBusinessModel>();
        }
    }
}
