using data.Storage;
using models;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestStorage
{
    //public class Tests
    //{
    //    Storage _storage;
    //    [SetUp]
    //    public void Setup()
    //    {
    //        _storage = new Storage();
    //    }
    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 2, 3 })]
    //    [TestCase(Lead.Fields.Id, "1", ExpectedResult = new int[] { 1 })]
    //    [TestCase(Lead.Fields.GroupId, "1", ExpectedResult = new int[] { 1, 2 })]
    //    public int[] TestGetAllLead(Lead.Fields? fields, string TValue)
    //    {
    //        List<Lead> list = (List<Lead>)_storage.GetAll<Lead>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].Id; }
    //        return arrresult;
    //    }

    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 2, 3 })]
    //    [TestCase(Course.Fields.Id, "1", ExpectedResult = new int[] { 1 })]
    //    [TestCase(Course.Fields.Name, "1", ExpectedResult = new int[] { 1, 2 })]

    //    public int[] TestGetAllCourse(Course.Fields? fields, string TValue)
    //    {
    //        List<Course> list = (List<Course>)_storage.GetAll<Course>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].Id; }
    //        return arrresult;
    //    }
    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 2, 3 })]
    //    [TestCase(Group.Fields.TeacherId, "1", ExpectedResult = new int[] { 1,3 })]
    //    [TestCase(Group.Fields.NameGroup, "C#123", ExpectedResult = new int[] { 1,2 })]
    //    public int[] TestGetAllGroup(Group.Fields? fields, string TValue)
    //    {
    //        List<Group> list = (List<Group>)_storage.GetAll<Group>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].Id; }
    //        return arrresult;
    //    }
    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 1,2, 1,3 })]
    //    [TestCase(History.Fields.LeadId, "1", ExpectedResult = new int[] { 1, 1,1 })]
    //    public int[] TestGetAllHistory(History.Fields? fields, string TValue)
    //    {
    //        List<History> list = (List<History>)_storage.GetAll<History>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].LeadId; }
    //        return arrresult;
    //    }
    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 1, 2, 1, 3 })]
    //    [TestCase(HistoryGroup.Fields.GroupId, "1", ExpectedResult = new int[] { 1, 1, 1 })]
    //    public int[] TestGetAllHistoryGroup(HistoryGroup.Fields? fields, string TValue)
    //    {
    //        List<HistoryGroup> list = (List<HistoryGroup>)_storage.GetAll<HistoryGroup>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].GroupId; }
    //        return arrresult;
    //    }
    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 2, 3 })]
    //    [TestCase(HR.Fields.FName, "Ivan", ExpectedResult = new int[] { 2 })]
    //    public int[] TestGetAllHR(HR.Fields? fields, string TValue)
    //    {
    //        List<HR> list = (List<HR>)_storage.GetAll<HR>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].Id; }
    //        return arrresult;
    //    }
    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 2, 1 })]
    //    [TestCase(Log.Fields.Date, "12.02.2020", ExpectedResult = new int[] { 1,2 })]
    //    [TestCase(Log.Fields.LeadId, "1", ExpectedResult = new int[] { 1, 1 })]
    //    public int[] TestGetAllLog(Log.Fields? fields, string TValue)
    //    {
    //        List<Log> list = (List<Log>)_storage.GetAll<Log>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].LeadId; }
    //        return arrresult;
    //    }

    //    [TestCase(null, null, ExpectedResult = new int[] {1,1,2,3,1,2,1,2  })]
    //    [TestCase(SkillsLead.Fields.SkillsId, "2", ExpectedResult = new int[] { 1, 3,2,2 })]
    //    [TestCase(SkillsLead.Fields.LeadId, "1", ExpectedResult = new int[] { 1, 1, 1,2 })]
    //    public int[] TestGetAllSkillsLead(SkillsLead.Fields? fields, string TValue)
    //    {
    //        List<SkillsLead> list = (List<SkillsLead>)_storage.GetAll<SkillsLead>(fields.ToString(), TValue);
    //        int[] arrresult = new int[(list.Count)*2];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].LeadId; }
    //        int j = 0;
    //        for (int i = list.Count; i < list.Count*2; i++) { arrresult[i] = list[j].SkillsId;j++; }
    //        return arrresult;
    //    }
    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 2, 3 })]
    //    [TestCase(Skills.Fields.NameSkills, "SQL", ExpectedResult = new int[] {2})]
    //    public int[] TestGetAllSkills(Skills.Fields? fields, string TValue)
    //    {
    //        List<Skills> list = (List<Skills>)_storage.GetAll<Skills>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].Id; }
    //        return arrresult;
    //    }
    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 2, 3 })]
    //    [TestCase(Status.Fields.Name, "student", ExpectedResult = new int[] {2})]
    //    public int[] TestGetAllStatus(Status.Fields? fields, string TValue)
    //    {
    //        List<Status> list = (List<Status>)_storage.GetAll<Status>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].Id; }
    //        return arrresult;
    //    }
    //    [TestCase(null, null, ExpectedResult = new int[] { 1, 2 })]
    //    [TestCase(Teacher.Fields.Id, "1", ExpectedResult = new int[] { 1 })]
    //    [TestCase(Teacher.Fields.FName, "Ivan", ExpectedResult = new int[] { 1 })]
    //    [TestCase(Teacher.Fields.SName, "Petrov", ExpectedResult = new int[] { 2 })]
    //    [TestCase(Teacher.Fields.PhoneNumber, "123", ExpectedResult = new int[] { 1 })]
    //    [TestCase(Teacher.Fields.Password, "123Ivan", ExpectedResult = new int[] { 1 })]
    //    [TestCase(Teacher.Fields.Login, "loginPetr", ExpectedResult = new int[] { 2 })]

    //    public int[] TestGetAllTeacher(Teacher.Fields? fields, string TValue)
    //    {
    //        List<Teacher> list = (List<Teacher>)_storage.GetAll<Teacher>(fields.ToString(), TValue);
    //        int[] arrresult = new int[list.Count];
    //        for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].Id; }
    //        return arrresult;
    //    }



    //}
}