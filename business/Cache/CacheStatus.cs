using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheStatus
    {
        private PublishingHouse publishingHouse;
        public List<StatusBusinessModel> Statuses { get; set; }
        public bool FlagActual { get; set; }
        public CacheStatus()
        {
            Statuses = new List<StatusBusinessModel>();
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.Status.Event += this.ReadChange;
        }
        public void ReadChange()
        {
            FlagActual = false;
        }

    }
}
