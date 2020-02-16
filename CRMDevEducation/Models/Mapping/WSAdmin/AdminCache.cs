using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSAdmin
{
    class AdminCache
    {
        public List<Teacher> Teachers { get; set; }
        public List<HR> Hrs { get; set; }

        public bool FlagActual { get; set; }
        public AdminCache()
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
