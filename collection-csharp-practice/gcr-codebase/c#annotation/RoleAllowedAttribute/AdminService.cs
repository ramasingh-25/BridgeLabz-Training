using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.RoleAllowedAttribute
{
    public class AdminService
    {
        [RoleAllowed("ADMIN")]
        public void DeleteUser()
        {
            Console.WriteLine("User deleted successfully");
        }

        [RoleAllowed("USER")]
        public void ViewProfile()
        {
            Console.WriteLine("Profile viewed");
        }
    }
}
