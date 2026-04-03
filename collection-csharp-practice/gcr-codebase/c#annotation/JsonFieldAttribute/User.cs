using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.JsonFieldAttribute
{
    public class User
    {
        [JsonField(Name = "user_name")]
        public string Username;

        [JsonField(Name = "user_age")]
        public int Age;

        public string Password; 

        public User(string username, int age, string password)
        {
            Username = username;
            Age = age;
            Password = password;
        }
    }
}
