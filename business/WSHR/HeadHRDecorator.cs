﻿using business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    public abstract class HeadHRDecorator : HRManager
    {
        HRManager defaultHR;
        public void SetHR(HRManager defaultHR) 
        {
            this.defaultHR = defaultHR;
        }

        public abstract bool DeleteLead(LeadBusinessModel _model);
        public abstract bool DeleteGroup(GroupBusinessModel _model);
        public abstract bool CreateGroup(GroupBusinessModel _model);


    }
}
