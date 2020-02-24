using data.Storage;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business
{
    public static class InspectorLogin
    {
        static IStorage storage;
        public static bool CheckUniqueness(string login)
        {
            bool uniq = true;
            uniq = CheckUniquenessInTeacher(login);
            if (!uniq)
                return uniq;

            uniq = CheckUniquenessInHR(login);
            if (!uniq)
                return uniq;

            uniq = CheckUniquenessInLead(login);
            if (!uniq)
                return uniq;

            return uniq;
        }
        private static bool CheckUniquenessInTeacher(string login)
        {
            storage = new StorageTeacher();
            List<Teacher> teachers = (List<Teacher>)storage.GetAll(Teacher.Fields.Login.ToString(), login);
            if (teachers.Count > 0)
                return false;
            else
                return true;
        }
        private static bool CheckUniquenessInHR(string login)
        {
            storage = new StorageHR();
            List<HR> teachers = (List<HR>)storage.GetAll(HR.Fields.Login.ToString(), login);
            if (teachers.Count > 0)
                return false;
            else
                return true;
        }
        private static bool CheckUniquenessInLead(string login)
        {
            storage = new StorageLead();
            List<Lead> teachers = (List<Lead>)storage.GetAll(Lead.Fields.Login.ToString(), login);
            if (teachers.Count > 0)
                return false;
            else
                return true;
        }

    }
}
