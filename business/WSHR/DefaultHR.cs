using business.Models;
using business.WSUser.interfaces;
using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    public abstract class DefaultHR : IUserManager
    {
        protected IStorage _storage;
        protected HRManagerCache _cache;
        protected HR _hr;
        public HRManagerCache Cache { get { return _cache; } }
        public HR HR { get { return _hr; } }
        public abstract IEnumerable<IModelsBusiness> GetTeacher();
        public abstract int? CreateLead(LeadBusinessModel _model);

        public abstract bool UpdateLead(LeadBusinessModel _model);

        public abstract bool ChangeStatus(LeadBusinessModel lead, int statusId);

        public abstract IEnumerable<IModelsBusiness> GetTasksMyself(int taskStatusId);
        public abstract IEnumerable<IModelsBusiness> GetTasksMyself(DateTime taskStartDate);
        public abstract IEnumerable<IModelsBusiness> GetTasksMyself();
        public abstract int SetTaskMyself(string taskText, DateTime deadline, int statusId);
    }
}
