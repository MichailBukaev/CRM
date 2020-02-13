using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity
{
    public class StorageHistoryGroup : IStorage
    {
        IReader _reader;
        public StorageHistoryGroup()
        {
            _reader = new ReaderHistoryGroup();
        }

        public bool Add(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {

                    db.HistoryGroups.Add((HistoryGroup)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool Delete(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {

                    db.HistoryGroups.Remove((HistoryGroup)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
        {
            using (ApplicationContext db = new ApplicationContext())
            { 
                var historyGroup = db.HistoryGroups.ToList();
                return _reader.Read(Tkey, TValue, historyGroup);

            }
               
        }
    

        public IEnumerable<IEntity> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var historyGroup = db.HistoryGroups.ToList();
                return _reader.Read(null, null, historyGroup);
            }

        }
                

        public bool Update(IEntity obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (obj != null)
                {

                    db.HistoryGroups.Update((HistoryGroup)obj);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
