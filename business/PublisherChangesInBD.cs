using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
    public delegate void ObserverChangeInBD(IEntity _entity);
    public class PublisherChangesInBD
    {
        private static PublisherChangesInBD publisher = null;
        private ObserverChangeInBD observers = null;

        public event ObserverChangeInBD Event
        {
            add { observers += value; }
            remove { observers -= value; }
        }

        private PublisherChangesInBD() { }

        public static PublisherChangesInBD GetPublisher()
        {
            if (publisher == null)
                publisher = new PublisherChangesInBD();
            return publisher;
        }

        public void Notify(IEntity _entity)
        {
            observers.Invoke(_entity);
        }
    }
}
