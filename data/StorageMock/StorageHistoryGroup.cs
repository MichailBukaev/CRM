using data.Storage;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity.Mock
{
    public class StorageHistoryGroup : IStorage
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
            return new List<HistoryGroup>();
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return new List<HistoryGroup>();
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
