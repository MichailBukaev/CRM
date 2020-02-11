using System;

namespace models
{
    public class Status : IEntity
    {
        public int Id  { get; set; }
        public string Name { get; set; }

        public enum Fields
        {
            Id,
            Name
        }
    }
}
