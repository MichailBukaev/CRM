using System;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class HR: IEntity
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public enum Fields
        {
            Id,
            FName,
            SName,
            Login,
            Password
        }
    }
}
