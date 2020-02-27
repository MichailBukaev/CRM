using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.MockStorageForTeacher
{
    public interface IStorage
    {
        string GetAll();
        string GetAll(string Tkey, string TValue);
        string Update(IEntity obj);
        string Add(ref IEntity obj);
        string Delete(IEntity obj);
    }
}
