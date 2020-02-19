using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheSkills
    {
        private PublishingHouse publishingHouse;
        public bool FlagActual { get; private set; }
        public List<SkillBusinessModel> Skills { get; set; }

        public CacheSkills()
        {
            FlagActual = false;
            publishingHouse = PublishingHouse.Create();
            publishingHouse.Skills.Event += this.ReadChange;
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
