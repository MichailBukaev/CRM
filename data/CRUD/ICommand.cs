using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.CRUD
{
    public interface ICommand
    {
        public void Execute(IEntity obj);

        public IEnumerable<IEntity> Execute<T>() where T : IEntity, new();
    }
}
