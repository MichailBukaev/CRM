using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
    public delegate void ObserverChangeInDB();
    public class PublisherChangesInDB
    {
        private static PublisherChangesInDB publisher = null;
        private ObserverChangeInDB observers = null;

        public event ObserverChangeInDB Event
        {
            add { observers += value; }
            remove { observers -= value; }
        }

        public void Notify()
        {
            observers.Invoke();
        }
    }
}
