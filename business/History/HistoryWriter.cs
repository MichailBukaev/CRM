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
        IStorage _storageHistory;
        IStorage _storageHistoryGroup;
        public HistoryWriter()
        {
            _storageHistory = new StorageHistory();
            _storageHistoryGroup = new StorageHistoryGroup();
        }
        public bool CreateLead(ref Lead lead)
        {
           
            IEntity history = new History
            {
                LeadId = lead.Id,
                HistoryText = "Создан пользователь в " +
                Convert.ToString(DateTime.UtcNow) + "c ID:" +
                lead.Id + ". "
            };
            return _storageHistory.Add(ref history);
                
        }

        public bool UpdateLead(Lead lead)
        {
            IEntity result = new History()
            {      
                LeadId = lead.Id,
                HistoryText = "Обновлен в " +
                Convert.ToString(DateTime.UtcNow) 
            };
            return _storageHistory.Add(ref result);
        }

        public bool AddSkills(int idLead, string skill)
        {
            
            IEntity result = new History()
            {
                LeadId = idLead,
                HistoryText = "Добавлен скилл " +
                skill + " " + Convert.ToString(DateTime.UtcNow)
            };
            return _storageHistory.Add(ref result);
        }

        public bool ChangeStatus(int idLead, string status)
        {
            IEntity result = new History()
            {
                LeadId = idLead,
                HistoryText = "Изменен статус на " + status  + 
                Convert.ToString(DateTime.UtcNow)
            };
            return _storageHistory.Add(ref result);
        }

        public bool CreateGroup(int Id)
        {
            IEntity result = new HistoryGroup()
            {
                GroupId = Id,
                HistoryText = "Создана группа " +
                 Convert.ToString(DateTime.UtcNow) + " c ID:" +
                 Id
            };
            return _storageHistoryGroup.Add(ref result);
        }

        public bool DeleteGroup(int id)
        {
            IEntity result = new HistoryGroup()
            {
                GroupId = id,
                HistoryText = "Группа удалена " +
                 Convert.ToString(DateTime.UtcNow) 
            };
            return _storageHistoryGroup.Add(ref result);
        }

        public bool DeleteLead(int id)
        {
            IEntity history = new History
            {
                LeadId = id,
                HistoryText = "Удален пользователь " +
               Convert.ToString(DateTime.UtcNow) 
            };
            return _storageHistory.Add(ref history);
        }

        public bool AddTeacherToGroup(int groupId, int teacherId)
        {
            IEntity result = new HistoryGroup()
            {
                GroupId = groupId,
                HistoryText = "Добавлен преподаватель в группу " +
                 Convert.ToString(DateTime.UtcNow) + " c ID:" +
                 teacherId
            };
            return _storageHistoryGroup.Add(ref result);
        }

        public bool DeleteTeacherToGroup(int groupId, int teacherId)
        {
            IEntity result = new HistoryGroup()
            {
                GroupId = groupId,
                HistoryText =  $"Удален преподаватель c ID: {teacherId} из группы " +
                 Convert.ToString(DateTime.UtcNow)                  
            };
            return _storageHistoryGroup.Add(ref result);
        }
    }
}
