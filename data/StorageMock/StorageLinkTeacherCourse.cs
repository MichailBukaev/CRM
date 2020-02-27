using data.Storage;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.StorageEntity.Mock
{
    public class StorageLinkTeacherCourse : IStorage
    {
       
        
            public bool Add(ref IEntity obj)
            {
                
                return true;
            }

            public bool Delete(IEntity obj)
            {
                return true;
            }

            public IEnumerable<IEntity> GetAll()
            {
                return new List<LinkTeacherCourse>();
            }

            public IEnumerable<IEntity> GetAll(string Tkey, string TValue)
            {
                return new List<LinkTeacherCourse>();
            }

            public bool Update(IEntity obj)
            {
                return true;
            }
        }
    
}
