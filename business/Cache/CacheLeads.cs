using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheLeads
    {
        public bool FlagActual { get; private set; }
        public int GroupById { get; set; }
        public List<LeadBusinessModel> Leads { get; set; }

        public CacheLeads()
        {
            FlagActual = false;
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
