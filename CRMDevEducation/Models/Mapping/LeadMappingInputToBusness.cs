﻿using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class LeadMappingInputToBusness 
    {
        public static LeadBusinessModel Map(InputLeadModel model)
        {
            StatusBusinessModel status = new StatusBusinessModel();
            if (model.Status != null)
            {
                status = StatusMappingInputToBusiness.Map(model.Status);
            }
            
            List<SkillBusinessModel> skills = new List<SkillBusinessModel>();
            if (model.Skills != null)
            {
                foreach (InputSkillModel item in model.Skills)
                {
                    skills.Add(SkillMappingInputToBusiness.Map(item));
                }
            }
            

            List<string> history = new List<string>();
            history.Add(model.History);

            return new LeadBusinessModel()
            {
                Id = model.Id,
                FName = model.FName,
                SName = model.SName,
                Numder = model.Numder,
                DateBirthday = model.DateBirthday,
                EMail = model.EMail,
                Status = status,
                Login = model.Login,
                Password = model.Password,
                Skills = skills,
                History = history
            };
        }
    }
}
