using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ProjectFive.Annotation.JsonFieldAttribute
{
   public class MainProgram
    {
       public static void Main(string[] args)
        {
            User user = new User("Rishita", 22, "secret123");

            string json = JsonSerializer.ToJson(user);
            Console.WriteLine(json);
        }
    }
}
