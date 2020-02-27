using business.Models;
using data.Storage;
using data.StorageEntity.Mock;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business
{
    public class Identifier
    {
        static IStorage _storage;
        public static User Check(string _login, string _password)
        {
            if (_login == "admin" && _password == "qqq1")
            {
                return new User() { Id = 1, Login = _login, Password = _password, Role = "Admin" };
            }
            else
            {
                _storage = new StorageHR();
                List<HR> hrs = (List<HR>)_storage.GetAll();
                HR hr = hrs.FirstOrDefault(x => x.Login == _login && x.Password == _password);
                if (hr != null)
                {
                    if (hr.Head)
                        return new User() { Id = hr.Id, Login = hr.Login, Password = hr.Password, Role = "HeadHR" };
                    else
                        return new User() { Id = hr.Id, Login = hr.Login, Password = hr.Password, Role = "HR" };
                }
                else
                {
                    _storage = new StorageTeacher();
                    List<Teacher> teachers = (List<Teacher>)_storage.GetAll();
                    Teacher teacher = teachers.FirstOrDefault(x => x.Login == _login && x.Password == _password);
                    if (teacher != null)
                    {
                        if (teacher.Head)
                            return new User() { Id = teacher.Id, Login = teacher.Login, Password = teacher.Password, Role = "HeadTeacher" };
                        else
                            return new User() { Id = teacher.Id, Login = teacher.Login, Password = teacher.Password, Role = "Teacher" };
                    }
                }

            }
            return null;
        }

    }
}
