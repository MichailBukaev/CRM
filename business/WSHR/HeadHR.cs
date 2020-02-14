using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    public class HeadHR : HeadHRDecorator
    {
      
        
        public override bool CreateGroup(GroupBusinessModel _model)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteGroup(GroupBusinessModel _model)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteLead(LeadBusinessModel _model)
        {
            throw new NotImplementedException();
        }
    }
}
