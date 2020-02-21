using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheLeadsCombineByGroup
    {
        public bool FlagActual { get; private set; }
        public int StatusId { get; set; }
        public List<LeadBusinessModel> Leads { get; set; }
        private PublishingHouse publishingHouse;
        private PublisherChangesInDB publisher;

        public CacheLeadsCombineByGroup()
        {
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publisher = new PublisherChangesInDB();
            publisher.Event += this.ReadChange;
            publishingHouse.CombineByGroup.Add(StatusId, publisher);
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
