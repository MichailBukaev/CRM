using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.MockStorageForTeacher
{
    public class StorageCourse : IStorage
    {
        public string Add(ref IEntity obj)
        {
            if (obj is Course)
                return "StorageCourse.Add()";
            else
                return "StorageCourse error type obj";
        }

        public string Delete(IEntity obj)
        {
            throw new NotImplementedException();
        }

        public string GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetAll(string Tkey, string TValue)
        {
            throw new NotImplementedException();
        }

        public string Update(IEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
