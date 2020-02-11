using models;
using System;
using System.Collections.Generic;

namespace data.Storage
{
    public interface StubICommand
    {

    }
    public class Read : StubICommand
    {
        public IEnumerable<IEntity> Execute<T>() where T : IEntity, new()
        {
            T obj = new T();
            if (obj is Lead)
            {
                return new List<Lead>() { new Lead { Id=1, GroupId = 1 }, new Lead { Id=2, GroupId = 1}, new Lead { Id = 3, GroupId = 2 } };
            }
            else { return null; }

            //добавить для др сущностей
        }
    }
}