using System;
using System.IO;

class UpperToLower
{
    static void Main()
    {
        using (StreamReader sr = new StreamReader("input.txt"))
        using (StreamWriter sw = new StreamWriter("output.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                sw.WriteLine(line.ToLower());
            }
        }
        Console.WriteLine("Converted successfully");
    }
}
