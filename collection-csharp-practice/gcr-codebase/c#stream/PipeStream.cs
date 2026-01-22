using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class PipeStream
{
    static void Main()
    {
        var server = new AnonymousPipeServerStream(PipeDirection.Out);
        var client = new AnonymousPipeClientStream(PipeDirection.In, server.ClientSafePipeHandle);

        Thread writer = new Thread(() =>
        {
            using (StreamWriter sw = new StreamWriter(server))
            {
                sw.AutoFlush = true;
                sw.WriteLine("Hello Pipe");
            }
        });

        Thread reader = new Thread(() =>
        {
            using (StreamReader sr = new StreamReader(client))
            {
                Console.WriteLine(sr.ReadLine());
            }
        });

        writer.Start();
        reader.Start();
        writer.Join();
        reader.Join();
    }
}
