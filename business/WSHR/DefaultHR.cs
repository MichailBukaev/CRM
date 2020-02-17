using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    public abstract class DefaultHR
    {
        public abstract IEnumerable<IModelsBusiness> GetLead();
        public abstract IEnumerable<IModelsBusiness> GetTeacher();
        public abstract int? CreateLead(LeadBusinessModel _model);

        public abstract bool UpdateLead(LeadBusinessModel _model);

        public abstract void SetCache();

    }
}
