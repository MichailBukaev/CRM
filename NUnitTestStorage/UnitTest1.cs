using data.Storage;
using models;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestStorage
{
    public class Tests
    {
        Storage _storage;
        [SetUp]
        public void Setup()
        {
            _storage = new Storage();
        }

        [TestCase(Lead.Fields.Id, "1", ExpectedResult = new int[] { 1 })]
        [TestCase(Lead.Fields.GroupId, "1", ExpectedResult = new int[] { 1, 2 })]
        public  int[] TestGetAllLead(Lead.Fields fields, string TValue)
        {
            List<Lead> list = (List < Lead > )_storage.GetAll<Lead>(fields.ToString(), TValue);
            int[] arrresult = new int[list.Count];
            for(int i = 0; i<list.Count; i++) { arrresult[i] = list[i].Id; }
            return arrresult;
        }
        [TestCase(ExpectedResult = new int[] { 1, 2, 3 })]
        public int[] TestGetAllLead()
        {
            List<Lead> list = (List<Lead>)_storage.GetAll<Lead>();
            int[] arrresult = new int[list.Count];
            for (int i = 0; i < list.Count; i++) { arrresult[i] = list[i].Id; }
            return arrresult;
        }
    }
}