using data.Storage;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity.Mock
{
    public class StorageGroup : IStorage
    {
        public static List<Group> Groups = new List<Group>();
        public bool Add(ref IEntity obj)
        {
           Groups.Add((Group)obj);
            return true;
        }

        public bool Delete(IEntity obj)
        {
            var g = Groups.First(g => g.NameGroup == ((Group)obj).NameGroup);
            Groups.Remove(g);
            return true;
        }

        public IEnumerable<IEntity> GetAll()
        {
            return Groups;
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return new List<Group>();
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
