using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheGroup
    {
        private PublishingHouse publishingHouse;
        public List<GroupBusinessModel> Groups { get; set; }
        public bool FlagActual { get; set; }
        public CacheGroup()
        {
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.Group.Event += this.ReadChange;
        }
        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
