using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.Storage
{
    public interface IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities);

    }

}
