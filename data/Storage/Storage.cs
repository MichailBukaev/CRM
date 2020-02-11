using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.Storage
{
    public class Storage
    {
        public StubICommand crudCommand;
        public IEnumerable<IEntity> GetAll<T>(string Tkey, string TValue) where T: IEntity, new()
        {
            crudCommand = new Read();
            T obj = new T();
            IReader reader = modelsReader[obj.GetType().ToString()];
            return reader.Read(Tkey, TValue, (Read)crudCommand);
        }
        public IEnumerable<IEntity> GetAll<T>() where T : IEntity, new()
        {
            crudCommand = new Read();
            T obj = new T();
            IReader reader = modelsReader[obj.GetType().ToString()];
            return reader.Read(null, null, (Read)crudCommand);
        }

        private Dictionary<string, IReader> modelsReader = new Dictionary<string, IReader>()
        {
            {new Lead().GetType().ToString(), new ReaderLead() },
            {new Course().GetType().ToString(), new ReaderCourse() },
            {new Group().GetType().ToString(), new ReaderGroup() },
            {new History().GetType().ToString(), new ReaderHistory() },
            {new HistoryGroup().GetType().ToString(), new ReaderHistoryGroup() },
            {new HR().GetType().ToString(), new ReaderHR() },
            {new Log().GetType().ToString(), new ReaderLog() },
            {new Skills().GetType().ToString(), new ReaderSkills() },
            {new SkillsLead().GetType().ToString(), new ReaderSkillsLead() },
            {new Status().GetType().ToString(), new ReaderStatus() },
            {new Teacher().GetType().ToString(), new ReaderTeacher() },
        };
    }
}
