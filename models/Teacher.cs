﻿using System;

namespace models
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public int PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
