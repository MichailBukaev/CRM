using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.Storage;

namespace data.StorageEntity.Mock
{
    public class StorageStatus : IStorage
    {
        public static List<Status> Statuses = new List<Status>() { new Status { Id = 1, Name = "status 1" } };

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
            return Statuses;
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return Statuses;
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
