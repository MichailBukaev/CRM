using business.WSUser.interfaces;
using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace business
{
    public class HistoryWriter
    {
        IStorage _storage;
        public HistoryWriter()
        {
            _storage = new StorageHistory();
        }
        public bool CreateLead(ref Lead lead)
        {
           
            IEntity history = new History
            {
                LeadId = lead.Id,
                HistoryText = "Создан пользователь в " +
                Convert.ToString(DateTime.UtcNow) + "c ID:" +
                lead.Id + "с состоянием: " + JsonSerializer.Serialize<Lead>(lead),
                Lead = lead
            };
            return _storage.Add(ref history);
                
        }

        public bool UpdateLead(Lead lead)
        {
            List<History> histories = (List<History>)_storage.GetAll(History.Fields.LeadId.ToString(), lead.Id.ToString());

        }
    }
}
