// using System;
// using System.IO;

// class ReadEncryptedCsv
// {
//     static void Main()
//     {
//         foreach (string line in File.ReadLines("secure.csv"))
//         {
//             if (line.StartsWith("Name")) continue;

//             string[] d = line.Split(',');

//             Console.WriteLine($"Name   : {d[0]}");
//             Console.WriteLine($"Email  : {CryptoHelper.Decrypt(d[1])}");
//             Console.WriteLine($"Salary : {CryptoHelper.Decrypt(d[2])}");
//         }
//     }
// }
