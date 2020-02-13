using business.Models;
using data.Storage;
using data.StorageEntity;
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
            if (_login=="admin"&&_password=="qqq1")
            {
                return new User() { Login = _login, Password = _password, Role = "Admin" };
            }
            else
            {
                _storage = new StorageHR();
                List<HR> hrs = (List<HR>)_storage.GetAll();
                HR hr = hrs.FirstOrDefault(x => x.Login == _login && x.Password == _password);
                if (hr != null)
                {
                    return new User() { Login = hr.Login, Password = hr.Password, Role = "HR" };
                }
                else
                {
                    _storage = new StorageTeacher();
                    List<Teacher> teachers = (List<Teacher>)_storage.GetAll();
                    Teacher teacher = teachers.FirstOrDefault(x => x.Login == _login && x.Password == _password);
                    if (teacher != null)
                    {
                        return new User() { Login = teacher.Login, Password = teacher.Password, Role = "Teacher" };
                    }
                }

            }
            return null;
        }
    }
}
