// using System;
// using System.IO;
// using System.Collections.Generic;

// class MergeCsv
// {
//     static void Main()
//     {
//         var studentDetails = new Dictionary<string, string[]>();

//         string[] file1 = File.ReadAllLines("students1.csv");
//         string[] file2 = File.ReadAllLines("students2.csv");

//         // Read first file
//         for (int i = 1; i < file1.Length; i++)
//         {
//             string[] data = file1[i].Split(',');
//             studentDetails[data[0]] = data;
//         }

//         using (StreamWriter writer = new StreamWriter("merged_students.csv"))
//         {
//             writer.WriteLine("ID,Name,Age,Marks,Grade");

//             for (int i = 1; i < file2.Length; i++)
//             {
//                 string[] data2 = file2[i].Split(',');
//                 string id = data2[0];

//                 if (studentDetails.ContainsKey(id))
//                 {
//                     string[] data1 = studentDetails[id];
//                     writer.WriteLine($"{id},{data1[1]},{data1[2]},{data2[1]},{data2[2]}");
//                 }
//             }
//         }

//         Console.WriteLine("CSV files merged successfully.");
//     }
// }
