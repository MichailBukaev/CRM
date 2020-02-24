using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheSkills
    {
        private PublishingHouse publishingHouse;
        public bool FlagActual { get; set; }
        public List<SkillBusinessModel> Skills { get; set; }

        public CacheSkills()
        {
            Skills = new List<SkillBusinessModel>();
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
