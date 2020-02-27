using business.Models.CutModel;

namespace business.Models
{
    public class StudentInLogBusinessModel : IModelsBusiness
    {
        public CutLeadBusinessModel Lead { get; set; }
        public bool Visit { get; set; }
    }
}