using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheLeadsCombineByStatus
    {
        public bool FlagActual { get; private set; }
        public int StatusId { get; set; }
        public List<LeadBusinessModel> Leads { get; set; }
        private PublishingHouse publishingHouse;
        private PublisherChangesInDB publisher;
        
        
        public CacheLeadsCombineByStatus()
        {
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publisher = new PublisherChangesInDB();
            publisher.Event += this.ReadChange;
            publishingHouse.CombineByStatus.Add(StatusId, publisher);
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
