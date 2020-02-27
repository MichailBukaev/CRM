using data.Storage;
using models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace data.StorageEntity.Mock
{
    public class StorageLog : IStorage
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
            return new List<Log>();
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return new List<Log>();
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
