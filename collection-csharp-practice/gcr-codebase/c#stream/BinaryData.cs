using System;
using System.IO;

class BinaryData
{
    static void Main()
    {
        using (BinaryWriter bw = new BinaryWriter(File.Open("stud.bin", FileMode.Create)))
        {
            bw.Write(101);
            bw.Write("Prakash");
            bw.Write(8.5);
        }

        using (BinaryReader br = new BinaryReader(File.Open("stud.bin", FileMode.Open)))
        {
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadDouble());
        }
    }
}
