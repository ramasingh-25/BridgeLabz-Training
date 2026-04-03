using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectFive.Annotation.RoleAllowedAttribute
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            string currentUserRole = "USER"; 

            AdminService service = new AdminService();
            Type type = typeof(AdminService);

            MethodInfo method = type.GetMethod("DeleteUser");

            RoleAllowed attr =
                (RoleAllowed)Attribute.GetCustomAttribute(
                    method, typeof(RoleAllowed));

            if (attr != null && attr.Role == currentUserRole)
            {
                method.Invoke(service, null);
            }
            else
            {
                Console.WriteLine("Access Denied!");
            }
        }
    }

}
