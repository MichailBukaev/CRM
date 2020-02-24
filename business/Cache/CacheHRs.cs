using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheHRs
    {
        private PublishingHouse publishingHouse;
        public bool FlagActual { get; set; }
        public List<HRBusinessModel> HRs { get; set; }

        public CacheHRs()
        {
            HRs = new List<HRBusinessModel>();
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.HR.Event += this.ReadChange;
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
