using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheLeadsCombineByStatus
    {
        public bool FlagActual { get; set; }
        public int StatusId { get; set; }
        public List<LeadBusinessModel> Leads { get; set; }
        private PublishingHouse publishingHouse;
        private PublisherChangesInDB publisher;
        
        
        public CacheLeadsCombineByStatus(int statusId)
        {
            Leads = new List<LeadBusinessModel>();
            StatusId = statusId;
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.CombineByStatus[StatusId].Event += this.ReadChange;
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
