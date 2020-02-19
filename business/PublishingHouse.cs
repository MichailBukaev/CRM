using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
    public class PublishingHouse
    {

        private static PublishingHouse publisherHouse = null;
        private Dictionary<int, PublisherChangesInDB> combineByGroup;
        private Dictionary<int, PublisherChangesInDB> combineByStatus;
        private IStorage storage;

        public PublisherChangesInDB Courses { get; set; }
        public PublisherChangesInDB Group { get; set; }
        public PublisherChangesInDB HR { get; set; }
        public PublisherChangesInDB Skills { get; set; }
        public PublisherChangesInDB Status { get; set; }
        public PublisherChangesInDB Teacher { get; set; }


        public Dictionary<int, PublisherChangesInDB> CombineByGroup
        {
            get { return combineByGroup; }
            set { combineByGroup = value; }
        }

        public Dictionary<int, PublisherChangesInDB> CombineByStatus
        {
            get { return combineByStatus; }
            set { combineByStatus = value; }
        }

        
        private PublishingHouse() {
            SetDictionaries();
        }

        private void SetDictionaries()
        {
            storage = new StorageGroup();
            List<Group> groups = (List<Group>)storage.GetAll();
            foreach(Group item in groups)
            {
                CombineByGroup.Add(item.Id, new PublisherChangesInDB());
            }
            storage = new StorageStatus();
            List<Status> statuses = (List<Status>)storage.GetAll();
            foreach(Status item in statuses)
            {
                CombineByStatus.Add(item.Id, new PublisherChangesInDB());
            }
        }

        public static PublishingHouse Create()
        {
            if (publisherHouse == null)
            {
                publisherHouse = new PublishingHouse();
            }
            return publisherHouse;
        }



    }
}
