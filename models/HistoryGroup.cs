using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class HistoryGroup: IEntity
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string HistoryText { get; set; }

        public enum Fields 
        {
            GroupId,
            HistoryText
        }

    }
}
