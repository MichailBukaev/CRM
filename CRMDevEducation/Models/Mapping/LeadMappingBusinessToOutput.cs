using CRMDevEducation.Models.Output;
using business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace CRMDevEducation.Models.Mapping
{
    public class LeadMappingBusinessToOutput
    {
        public static OutputLeadModel Map(LeadBusinessModel models)
        {
            string history = "";
            foreach (string item in models.History)
            {
                history += JsonSerializer.Deserialize<OutputLeadModel>(item);
            }
            return new OutputLeadModel
            {
                Id = models.Id,
                FName = models.FName,
                SName = models.SName,
                DateBirthday = models.DateBirthday,
                Numder = models.Numder,
                EMail = models.EMail,
                Status = models.Status.Name,
                History = history,
                Login = models.Login,
                Password = models.Password
            };         
        }
    }
}
