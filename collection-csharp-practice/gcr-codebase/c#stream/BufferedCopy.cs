using System;
using System.IO;
using System.Diagnostics;

class BufferedCopy
{
    static void Main()
    {
        byte[] buf = new byte[4096];
        Stopwatch sw = new Stopwatch();

        sw.Start();
        using (FileStream fr = new FileStream("big.dat", FileMode.Open))
        using (FileStream fw = new FileStream("copy.dat", FileMode.Create))
        using (BufferedStream br = new BufferedStream(fr))
        using (BufferedStream bw = new BufferedStream(fw))
        {
            int n;
            while ((n = br.Read(buf, 0, buf.Length)) > 0)
            {
                bw.Write(buf, 0, n);
            }
        }
        sw.Stop();

        Console.WriteLine("Buffered Time: " + sw.ElapsedMilliseconds + " ms");
    }
}
