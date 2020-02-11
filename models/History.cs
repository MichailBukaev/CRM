using System;

namespace models
{
    public class History: IEntity
    {
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public string HistoryText { get; set; }

        public enum Fields
        {
            LeadId,
            HistoryText
        }
    }
}
