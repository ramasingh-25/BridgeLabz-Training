using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.MaxLengthAttribute
{
    public class MainProgram
    {
        public void Main(string[] args)
        {
            try
            {
                User user1 = new User("Rishita");
                user1.Display();

                User user2 = new User("VeryLongUsername");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
