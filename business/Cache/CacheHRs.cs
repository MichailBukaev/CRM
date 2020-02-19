using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheHRs
    {
        public bool FlagActual { get; private set; }
        public List<HRBusinessModel> HRs { get; set; }

        public CacheHRs()
        {
            FlagActual = false;
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
