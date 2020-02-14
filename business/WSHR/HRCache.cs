using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    class HRCache
    {
        public List<Lead> Leads { get; set; }
        public List<Teacher> Teachers { get; set; } 
        
        public bool FlagActual { get; set; }

        public HRCache()
        {
            FlagActual = false;
            PublisherChangesInBD publisher = PublisherChangesInBD.GetPublisher();
            publisher.Event += this.ReadChange;
        }

        public void ReadChange(IEntity entity)
        {
            FlagActual = false;
        }



    }
}
