using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.Storage
{
    public interface IStorage
    {
        IEnumerable<IEntity> GetAll();
        IEnumerable<IEntity> GetAll(string Tkey, string TValue);
        bool Update(IEntity obj);
        bool Add(ref IEntity obj);
        bool Delete(IEntity obj);


    }
}
