﻿using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.Cache
{
    public class CacheSkills
    {
        public bool FlagActual { get; private set; }
        public List<SkillBusinessModel> Skills { get; set; }

        public CacheSkills()
        {
            FlagActual = false;
        }

        public void ReadChange()
        {
            FlagActual = false;
        }
    }
}
