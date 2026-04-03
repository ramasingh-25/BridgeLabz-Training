using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectFive.Annotation.MaxLengthAttribute
{
    public class User
    {
        [MaxLength(10)]
        private string Username;

        public User(string username)
        {
         
            FieldInfo field =
                typeof(User).GetField("Username",
                BindingFlags.NonPublic | BindingFlags.Instance);

           
            MaxLength attr =
                (MaxLength)Attribute.GetCustomAttribute(
                    field, typeof(MaxLength));

            
            if (attr != null && username.Length > attr.Value)
            {
                throw new ArgumentException(
                    $"Username cannot exceed {attr.Value} characters");
            }

            Username = username;
        }

        public void Display()
        {
            Console.WriteLine("Username: " + Username);
        }
    }
}

