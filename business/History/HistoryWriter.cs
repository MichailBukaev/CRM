using business.WSUser.interfaces;
using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                lead.Id + "с состоянием: " + JsonSerializer.Serialize<Lead>(lead) + ". "
            };
            return _storage.Add(ref history);
                
        }

        public bool UpdateLead(Lead lead)
        {
            IEntity result = new History()
            {      
                LeadId = lead.Id,
                HistoryText = "Обновлен " +
                Convert.ToString(DateTime.UtcNow) +
                " с состоянием: " + JsonSerializer.Serialize<Lead>(lead),
            };
            return _storage.Add(ref result);
        }

        public bool AddSkills(int idLead, string skill)
        {
            
            IEntity result = new History()
            {
                LeadId = idLead,
                HistoryText = "Добавлен скилл " +
                skill 
            };
            return _storage.Add(ref result);
        }



    }
}
