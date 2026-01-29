// using System;
// using System.IO;
// using System.Collections.Generic;

// class DetectDuplicateCsv
// {
//     static void Main()
//     {
//         HashSet<string> ids = new HashSet<string>();

//         Console.WriteLine("Duplicate Records:\n");

//         foreach (string line in File.ReadLines("students.csv"))
//         {
//             if (line.StartsWith("ID")) continue;

//             string[] data = line.Split(',');
//             string id = data[0];

//             if (!ids.Add(id))
//             {
//                 Console.WriteLine(line);
//             }
//         }
//     }
// }
