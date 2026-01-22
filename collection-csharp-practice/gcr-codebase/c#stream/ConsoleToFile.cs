using System;
using System.IO;

class ConsoleToFile
{
    static void Main()
    {
        try
        {

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            string age = Console.ReadLine();

            Console.Write("Language: ");
            string lang = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter("user.txt"))
            {
                sw.WriteLine(name);
                sw.WriteLine(age);
                sw.WriteLine(lang);
            }

            Console.WriteLine("Data saved");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

