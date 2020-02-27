using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace data.StorageEntity.Mock
{
    public class StorageHistory : IStorage
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
            return new List<History>();
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return new List<History>();
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
