//using business.Models;
//using business.WSAdmin;
//using business.WSHR;
//using business.WSTeacher;
//using business.WSTeacher.HeadTeacher;
//using business.WSUser.interfaces;
//using System;
//using System.Collections.Generic;
//using System.Security.Claims;
//using System.Text;

//namespace business.WSUser
//{
//    public class UserManager
//    {
//        public readonly IUserManager Manager;

//        public UserManager(ClaimsPrincipal user)
//        {
//            if (user == null) throw new NullReferenceException("User is not existed");
//            IUserManager manager = null;
//            if (user.IsInRole("Admin")) manager = new AdminManager();
//            else if (user.IsInRole("HR")) manager = new HRManager();
//            else if (user.IsInRole("HeadHR")) manager = new HeadHR(new HRManager());
//            else if (user.IsInRole("Teacher")) manager = new NormalTeacherManager(user.Identity.Name);
//            else if (user.IsInRole("HeadTeacher")) manager = new MaxHeadTeacherManager(new NormalTeacherManager(user.Identity.Name));

//            Manager = manager;
//        }
//        public IEnumerable<IModelsBusiness> GetLeads()
//        {
//            return Manager.GetLeads();
//        }

//    }
//}
