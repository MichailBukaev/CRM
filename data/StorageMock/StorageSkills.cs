using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.Storage;
namespace data.StorageEntity.Mock
{
    public class StorageSkills : IStorage
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
            return new List<Skills>();
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return new List<Skills>();
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
