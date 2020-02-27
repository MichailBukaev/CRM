using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity.Mock
{
    public class StorageCourse : IStorage
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
            return new List<Course>();
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return new List<Course>();
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
