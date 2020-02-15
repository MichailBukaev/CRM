using System;
using System.Collections.Generic;
using System.Text;

namespace business.Models
{
    public class LeadsInGroupBusinessModel : IModelsBusiness
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
    }
}
