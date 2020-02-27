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
        static IStorage storage;
        static IEntity modelAdd;
        static bool flagContain;
        public static void SetStatusTaskInDB()
        {
            List<TasksStatus> modelsInDB;
            storage = new StorageTasksStatus();
            flagContain = false;



            modelsInDB = (List<TasksStatus>)storage.GetAll();
            modelAdd = new TasksStatus()
            {
                Name = StatusTask.ToDo.ToString()
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
                Name = StatusTask.InProgress.ToString()
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
                Name = StatusTask.Urgently.ToString()
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
                Name = StatusTask.Done.ToString()
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
        public static void SetStatusLeadInDB()
        {
            List<Status> modelsInDB;
            storage = new StorageStatus();
            modelsInDB = (List<Status>)storage.GetAll();

            flagContain = false;
            modelAdd = new Status()
            {
                Name = "Новый лид"
            };

            foreach(Status item in modelsInDB)
            {
                if(item.Name == ((Status)modelAdd).Name)
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
            modelAdd = new Status()
            {
                Name = "Интервью назначено"
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


            flagContain = false;
            modelAdd = new Status()
            {
                Name = "Интервью пройдено"
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


            flagContain = false;
            modelAdd = new Status()
            {
                Name = "Интервью не пройдено"
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

            flagContain = false;
            modelAdd = new Status()
            {
                Name = "Готов начать обучение"
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

            flagContain = false;
            modelAdd = new Status()
            {
                Name = "Студент"
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

            flagContain = false;
            modelAdd = new Status()
            {
                Name = "Закончил обучение"
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


            flagContain = false;
            modelAdd = new Status()
            {
                Name = "Отчислен"
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
        public enum StatusTask
        {
            ToDo,
            Urgently,
            InProgress,
            Done
        }


    }
}
