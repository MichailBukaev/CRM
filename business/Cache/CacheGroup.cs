using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheGroup
    {
        public List <GroupBusinessModel> Groups { get; set; }
        public bool FlagActual { get; set; }
        public CacheGroup() {
            FlagActual = false;
        }
        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
