// using System;
// using System.IO;

// class FilterStudents
// {
//     static void Main()
//     {
//         string filePath = "students.csv";

//         if (!File.Exists(filePath))
//         {
//             Console.WriteLine("File not found!");
//             return;
//         }

//         string[] lines = File.ReadAllLines(filePath);

//         Console.WriteLine("Students with marks > 80:\n");

//         for (int i = 1; i < lines.Length; i++) 
//         {
//             string[] data = lines[i].Split(',');

//             int marks = int.Parse(data[3]);

//             if (marks > 80)
//             {
//                 Console.WriteLine($"ID    : {data[0]}");
//                 Console.WriteLine($"Name  : {data[1]}");
//                 Console.WriteLine($"Marks : {marks}");
//                 Console.WriteLine("------------------");
//             }
//         }
//     }
// }
