using data.Storage;
using data.StorageEntity.Mock;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
    public class Settings
    {
        static IStorage storage;
        static IEntity modelAdd;
        static bool flagContain;
        public static void SetStatusTaskInDB()
        {
            List<TasksStatus> modelsInDB;
            storage = new StorageTasksStatus();
            flagContain = false;

            modelsInDB = (List<TasksStatus>)storage.GetAll();

            foreach (string value in Enum.GetNames(typeof(StatusTask)))
            {
                flagContain = false;
                modelAdd = new TasksStatus()
                {
                    Name = value
                };
                foreach (TasksStatus item in modelsInDB)
                {
                    if (item.Name == ((TasksStatus)modelAdd).Name)
                    {
                        flagContain = true;
                        break;
                    }

                }
                if (!flagContain)
                {
                    storage.Add(ref modelAdd);
                }
            }
        }
        public static void SetStatusLeadInDB()
        {
            List<Status> modelsInDB;
            storage = new StorageStatus();
            flagContain = false;

            modelsInDB = (List<Status>)storage.GetAll();

            foreach (string value in Enum.GetNames(typeof(StatusLead)))
            {
                flagContain = false;
                modelAdd = new Status()
                {
                    Name = value
                };
                foreach (Status item in modelsInDB)
                {
                    if (item.Name == ((Status)modelAdd).Name)
                    {
                        flagContain = true;
                        break;
                    }

                }
                if (!flagContain)
                {
                    storage.Add(ref modelAdd);
                }
            }
        }
        public enum StatusTask
        {
            ToDo,
            Urgently,
            InProgress,
            Done
        }

        public enum StatusLead
        {
            NewLead, 
            AssignedInterview, // интервью назначено
            InterviewSuccess, // интервью пройдено 
            InterviewFailed, // интервью не пройдено
            ReadyToStart, // готов начать обучение
            Student,
            Finish, //закончил обучение
            Expelled // отчислен, не закончил обучение


        }


    }
}
