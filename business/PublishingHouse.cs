using data.Storage;
using data.StorageEntity.Mock;
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
        private Dictionary<string, PublisherChangesInTasks> combineByExecuter;

        private IStorage storage;


        public PublisherChangesInDB Courses { get; set; }
        public PublisherChangesInDB Group { get; set; }
        public PublisherChangesInDB HR { get; set; }
        public PublisherChangesInDB Skills { get; set; }
        public PublisherChangesInDB Status { get; set; }
        public PublisherChangesInDB Teacher { get; set; }
        public PublisherChangesInDB TasksStatus { get; set; }



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

        public Dictionary<string, PublisherChangesInTasks> CombineByExecuter
        {
            get { return combineByExecuter; }
            set { combineByExecuter = value; }
        }

        
        private PublishingHouse() {
            combineByGroup = new Dictionary<int, PublisherChangesInDB>();
            combineByStatus = new Dictionary<int, PublisherChangesInDB>();
            combineByExecuter = new Dictionary<string, PublisherChangesInTasks>();
            Courses = new PublisherChangesInDB();
            Group = new PublisherChangesInDB();
            HR = new PublisherChangesInDB();
            Skills = new PublisherChangesInDB();
            Status= new PublisherChangesInDB();
            Teacher = new PublisherChangesInDB();
            TasksStatus = new PublisherChangesInDB();
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


            storage = new StorageTeacher();
            List<Teacher> teachers = (List<Teacher>)storage.GetAll();
            foreach(Teacher item in teachers)
            {
                combineByExecuter.Add(item.Login, new PublisherChangesInTasks());
            }
            storage = new StorageHR();
            List<HR> hrs = (List<HR>)storage.GetAll();
            foreach (HR item in hrs)
            {
                combineByExecuter.Add(item.Login, new PublisherChangesInTasks());
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
