using System;
using System.IO;

class FileReadWrite
{
    static void Main()
    {
        string src = "source.txt";
        string dest = "dest.txt";

        try
        {
            if (!File.Exists(src))
            {
                Console.WriteLine("Source file not found");
                return;
            }

            using (FileStream fr = new FileStream(src, FileMode.Open))
            using (FileStream fw = new FileStream(dest, FileMode.Create))
            {
                fr.CopyTo(fw);
            }

            Console.WriteLine("File copied successfully");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
