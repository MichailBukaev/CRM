﻿using business.Models;
using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSUser.interfaces
{
    public abstract class IUserManager
    {
        public abstract IModelsBusiness GetLead(int id);
    }
}