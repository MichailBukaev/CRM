using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCRUD
{
    public class MockLead
    {
        public IEnumerable<IEntity> Leads
        {
            get
            {
                return new List<IEntity>
                {
                    new Lead
                    {
                        Id = 1,
                        FName = "AAA",
                        SName = "B",
                        DateBirthday = "2000-08-11",
                        DateRegistration = "2019-09-11",
                        Numder = 89516,
                        EMail = "asya",
                        AccessStatus = true,
                        GroupId = 2,
                        //Group = new Group() { Id = 2},
                        StatusId = 5,
                        Status = new Status() {Id = 3},
                        CourseId = 1,
                        //Course = new Course() {Id = 4}
                    },
                    new Lead
                    {
                        Id = 2,
                        FName = "CCC",
                        SName = "BBB",
                        DateBirthday = "1999-07-30",
                        DateRegistration = "2019-10-21",
                        Numder = 8975716,
                        EMail = "asya",
                        AccessStatus = true,
                        GroupId = 2,
                        //Group = new Group() { Id = 2},
                        StatusId = 3,
                        //Status = new Status() {Id = 3},
                        CourseId = 4,
                        //Course = new Course() {Id = 4}
                    },
                    new Lead
                    {
                        Id = 3,
                        FName = "QQQ",
                        SName = "YYY",
                        DateBirthday = "1998-03-21",
                        DateRegistration = "2019-09-18",
                        Numder = 8975716,
                        EMail = "asya",
                        AccessStatus = true,
                        GroupId = 1,
                        //Group = new Group() { Id = 2},
                        StatusId = 6,
                        //Status = new Status() {Id = 3},
                        CourseId = 3,
                        //Course = new Course() {Id = 4}
                    },
                    new Lead
                    {
                        Id = 4,
                        FName = "UUU",
                        SName = "HHH",
                        DateBirthday = "1997-09-15",
                        DateRegistration = "2019-09-28",
                        Numder = 8975716,
                        EMail = "asya",
                        AccessStatus = true,
                        GroupId = 2,
                        //Group = new Group() { Id = 2},
                        StatusId = 8,
                        //Status = new Status() {Id = 3},
                        CourseId = 7,
                        //Course = new Course() {Id = 4}
                    }
                };
            }
        }

    }
}
