using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.Storage;

namespace data.StorageEntity.Mock
{

    public class StorageTeacher : IStorage
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
            return new List<Teacher>();
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return new List<Teacher>();
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
