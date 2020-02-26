using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class FiltrLeadMappingInputToBusiness
    {
        public static FiltrLeadBusinessModel Map(InputFiltrLeadModel model)
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

            return new FiltrLeadBusinessModel()
            {
               
                FName = model.FName,
                SName = model.SName,
                Numder = model.Numder,
                DateBirthday = model.DateBirthday,
                EMail = model.EMail,
                Status = status,
                Skills = skills
            };
        }
    }
}
