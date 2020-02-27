using data.Storage;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity.Mock
{
    public class StorageLead : IStorage
    {
        public static List<Lead> Leads = new List<Lead>();

        public bool Add(ref IEntity obj)
        {
            Leads.Add((Lead)obj);
            return true;
        }

        public bool Delete(IEntity obj)
        {
            return true;
        }

        public IEnumerable<IEntity> GetAll()
        {
            return Leads;
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            return Leads;
        }

        public bool Update(IEntity obj)
        {
            return true;
        }
    }
}
