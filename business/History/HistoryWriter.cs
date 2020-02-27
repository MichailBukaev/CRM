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
        public bool CreateLead(ref Lead lead, string status)
        {
           
            IEntity history = new History
            {
                LeadId = lead.Id,
                HistoryText = "Add User at " +
                Convert.ToString(DateTime.UtcNow) + "with ID:" +
                lead.Id + "Status: " + status + ". "
            };
            return _storageHistory.Add(ref history);
                
        }

        public bool UpdateLead(Lead lead)
        {
            IEntity result = new History()
            {      
                LeadId = lead.Id,
                HistoryText = "Update user " +
                Convert.ToString(DateTime.UtcNow) + ". " 
            };
            return _storageHistory.Add(ref result);
        }

        public bool AddSkills(int idLead, string skill)
        {
            
            IEntity result = new History()
            {
                LeadId = idLead,
                HistoryText = "Add Skill " +
                skill + " " + Convert.ToString(DateTime.UtcNow)
            };
            return _storageHistory.Add(ref result);
        }

        public bool ChangeStatus(int idLead, string status)
        {
            IEntity result = new History()
            {
                LeadId = idLead,
                HistoryText = "Change status " + status  + " " +
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


        public bool AddTeacherToGroup(int groupId, int teacherId)
        {
            IEntity result = new HistoryGroup()
            {
                GroupId = groupId,
                HistoryText = "Teacher added to group " +
                 Convert.ToString(DateTime.UtcNow) + " with ID:" +
                 teacherId  + ". "
            };
            return _storageHistoryGroup.Add(ref result);
        }

        public bool DeleteTeacherToGroup(int groupId, int teacherId)
        {
            IEntity result = new HistoryGroup()
            {
                GroupId = groupId,
                HistoryText =  $"Teacher with ID: {teacherId} removed " +
                 Convert.ToString(DateTime.UtcNow) +  ". "   
            };
            return _storageHistoryGroup.Add(ref result);
        }
    }
}
