using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
    public delegate void ObserverChangeInTasks(string loginAuthor);
    public class PublisherChangesInTasks
    {
        private ObserverChangeInTasks observers = null;
        
        public event ObserverChangeInTasks Event
        {
            add { observers += value; }
            remove { observers -= value; }
        }

        public void Notify(string loginAuthor)
        {
            if (observers != null)
                observers.Invoke(loginAuthor);
        }

    }
}
