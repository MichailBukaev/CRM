using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheLeadsCombineByGroup
    {
        public bool FlagActual { get; set; }
        public int GroupId { get; set; }
        public List<LeadBusinessModel> Leads { get; set; }
        private PublishingHouse publishingHouse;
        private PublisherChangesInDB publisher;

        public CacheLeadsCombineByGroup(int groupId)
        {
            Leads = new List<LeadBusinessModel>();
            GroupId = groupId;
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.CombineByGroup[GroupId].Event += this.ReadChange;
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
