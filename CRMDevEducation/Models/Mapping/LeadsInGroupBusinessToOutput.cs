using CRMDevEducation.Models.Output;
using business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class LeadsInGroupBusinessToOutput
    {
        public static List<OutputLeadsInGroupModel> Map(List<LeadsInGroupBusinessModel> models)
        {
            List<OutputLeadsInGroupModel> output = new List<OutputLeadsInGroupModel>();
            foreach (LeadsInGroupBusinessModel item in models)
	        {
                output.Add(new OutputLeadsInGroupModel()
                {
                    Id = item.Id,
                    FName = item.FName,
                    SName = item.SName
                });
	        }
            return output;            
        }
    }
}
