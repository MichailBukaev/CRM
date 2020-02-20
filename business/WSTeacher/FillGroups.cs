using business.Models;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSTeacher
{
    public class FillGroups : HandlerTeacher
    {
        public override void FillUp(TeacherManagerCache teacherManagerCache, int? id )
        {
            storage = new StorageGroup();
            GroupBusinessModel gr;
            List<Group> groups = (List<Group>)storage.GetAll(Group.Fields.TeacherId.ToString(), id.ToString());
            storage = new StorageHistoryGroup();
            List<HistoryGroup> historyGroups = (List<HistoryGroup>)storage.GetAll(HistoryGroup.Fields.GroupId.ToString(), item.Id.ToString());

            List<Lead> leads = (List<Lead>)storage.GetAll();
            storage = new StorageLog();

            foreach (Group item in groups)
            {                
                gr = new GroupBusinessModel() {
                    Id = item.Id,
                    Name = item.NameGroup,
                    CourseId = item.CourseId,
                    StartDate = item.StartDate,
                    TeacherId = item.TeacherId,
                };

                foreach (HistoryGroup historyItem in historyGroups.Where(p=>p.GroupId == item.Id))
                {
                    gr.HistoryGroup.Add(historyItem.HistoryText + "\n");
                }
                storage = new StorageLead();
                List<Log> logs = new List<Log>();
                foreach (Lead leadItem in leads.Where(p => p.GroupId == item.Id))
                {
                    gr.LeadsId.Add(leadItem.Id);
                    logs.AddRange((List<Log>)storage.GetAll(Log.Fields.LeadId.ToString(), item.Id.ToString()));
                }

                gr.LogOfGroup = new LogBusinessModel()
                {
                    GroupId = item.Id,
                    GroupName = item.NameGroup
                };
                var logGroups = logs.GroupBy(p => p.Date);
                foreach(IGrouping<DateTime, Log> g in logGroups)
                {
                    DayInLogBusinessModel dayInLog = new DayInLogBusinessModel() {
                    Date = g.Key
                    };
                    foreach (var t in g)
                    {
                        dayInLog.StudentsInLog.Add(new StudentInLogBusinessModel()
                        {
                            LeadId = t.LeadId,
                            Visit = t.Visit
                        });
                    }
                    gr.LogOfGroup.Days.Add(dayInLog);
                }
            }
        }
    }
}
