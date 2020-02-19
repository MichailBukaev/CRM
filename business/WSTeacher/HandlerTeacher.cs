using data.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSTeacher
{
    public abstract class HandlerTeacher
    {

       protected IStorage storage;
        public HandlerTeacher Next { get; set; }

        public abstract void FillUp(TeacherManagerCache teacherManagerCache, int? id);



    }
}
