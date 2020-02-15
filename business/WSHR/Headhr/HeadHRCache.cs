﻿using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    public class HeadHRCache
    {
        public List<Lead> Leads { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Group> Groups { get; set; }
      

        public bool FlagActual { get; set; }

        public HeadHRCache()
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
