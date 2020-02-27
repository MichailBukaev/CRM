using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.Storage;
using Microsoft.EntityFrameworkCore;

namespace data.StorageEntity.Mock
{
   public class StorageSkillsLead : IStorage
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
            return new List<SkillsLead>();
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return new List<SkillsLead>();
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
