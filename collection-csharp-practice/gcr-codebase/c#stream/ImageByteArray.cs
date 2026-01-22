using System;
using System.IO;

class ImageByteArray
{
    static void Main()
    {
        try
        {
            byte[] img = File.ReadAllBytes("img.jpg");
            using (MemoryStream ms = new MemoryStream(img))
            {
                File.WriteAllBytes("copy.jpg", ms.ToArray());
            }
            Console.WriteLine("Image copied");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
