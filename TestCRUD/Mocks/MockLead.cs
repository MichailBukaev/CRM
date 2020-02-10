using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCRUD
{
    public class MockLead
    {
        public IEnumerable<Lead> Leads
        {
            get
            {
                return new List<Lead>
                {
                    new Lead
                    {
                        Id = 1,
                        FName = "AAA",
                        SName = "B",
                        DateBirthday = "2000-08-11",
                        DateRegistration = "2000-09-11",
                        Numder = 89516,
                        EMail = "asya",
                        AccessStatus = true,
                        GroupId = 0,
                        Group = new Group() { Id = 2},
                        StatusId = 0,
                        Status = new Status() {Id = 3},
                        CourseId = 0,
                        Course = new Course() {Id = 4}
                    },
                    new Lead
                    {
                        Id = 2,
                        FName = "CCC",
                        SName = "BBB",
                        DateBirthday = "2000-08-11",
                        DateRegistration = "2000-09-11",
                        Numder = 8975716,
                        EMail = "asya",
                        AccessStatus = true,
                        GroupId = 2,
                        Group = new Group() { Id = 2},
                        StatusId = 3,
                        Status = new Status() {Id = 3},
                        CourseId = 4,
                        Course = new Course() {Id = 4}
                    }
                };
            }
        }

    }
}
