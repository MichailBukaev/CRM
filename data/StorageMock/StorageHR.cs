using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity.Mock
{

    public class StorageHR : IStorage
    {

        public bool Add(ref IEntity obj)
        {
            return true;
        }

        public bool Delete(IEntity obj)
        {
            return true;
        }

        public IEnumerable<IEntity> GetAll()
        {
            return new List<HR>() { new HR { Id = 1, Login ="login1"} };
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return new List<HR>();
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
