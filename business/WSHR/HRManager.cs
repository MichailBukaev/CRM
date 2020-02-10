using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    public class HRManager
    {
        HR hR;
        HRCache _cache;
        StabStorage storage;
        PublisherChangesInBD _publisher;
        public HRManager()
        {
            hR = new HR();
            _cache = new HRCache();
            storage = new StabStorage(this);
            _publisher = PublisherChangesInBD.GetPublisher();
        }

        //метод заполнения
        public IEnumerable<IEntity> SetData(IEntity entities)
        {
            return storage.GetAll(entities);
        }


        
    }
}
