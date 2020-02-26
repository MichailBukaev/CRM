using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
    public class Settings
    {
        IStorage storage = new StorageTasksStatus();
        List<TasksStatus> modelsInDB;
        IEntity modelAdd;
        public static void SetStatusInDB()
        {
            bool flagContain = false;


            modelsInDB = (List<TasksStatus>)storage.GetAll();
            modelAdd = new TasksStatus()
            {
                Name = "To do"
            };
            foreach(TasksStatus item in modelsInDB)
            {
                if (item.Name == ((TasksStatus)modelAdd).Name)
                {
                    flagContain = true;
                    break;
                }
                    
            }
            if(!flagContain)
            {
                storage.Add(ref modelAdd);
            }



            flagContain = false;
            modelAdd = new TasksStatus()
            {
                Name = "In progress"
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


            flagContain = false;
            modelAdd = new TasksStatus()
            {
                Name = "Urgently"
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


            flagContain = false;
            modelAdd = new TasksStatus()
            {
                Name = "Done"
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
}
