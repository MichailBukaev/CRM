﻿using business.Models.CutModel;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutGroupMappingBusinessToOutput
    {
        public static CutGroupOutputModel Map(CutGroupBusinessModel model)
        {
            return new CutGroupOutputModel()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}