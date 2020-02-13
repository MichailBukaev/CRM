using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.Storage
{
    public interface IStorage
    {
        IEnumerable<IEntity> GetAll(string Tkey, string TValue);
        IEnumerable<IEntity> GetAll();
        bool Update(IEntity obj);
        bool Add(IEntity obj);
        bool Delete(IEntity obj);


    }
}
