using business.Models;
using CRMDevEducation.Models.Input;

namespace CRMDevEducation.Models.Mapping
{
    public class StatusMappingInputToBusiness
    {
        public static StatusBusinessModel Map(InputStatusModel model)
        {
            return new StatusBusinessModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}