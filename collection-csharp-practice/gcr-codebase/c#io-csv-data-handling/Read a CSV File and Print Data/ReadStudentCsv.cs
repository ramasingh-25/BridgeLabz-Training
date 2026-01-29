// using System;
// using System.IO;

// class ReadStudentCsv
// {
//     static void Main()
//     {
//         string filePath = "students.csv";

//         if (!File.Exists(filePath))
//         {
//             Console.WriteLine("CSV file not found!");
//             return;
//         }

//         string[] lines = File.ReadAllLines(filePath);

//         Console.WriteLine("Student Details:\n");

//         // Skip header (start from index 1)
//         for (int i = 1; i < lines.Length; i++)
//         {
//             string[] data = lines[i].Split(',');

//             Console.WriteLine($"ID     : {data[0]}");
//             Console.WriteLine($"Name   : {data[1]}");
//             Console.WriteLine($"Age    : {data[2]}");
//             Console.WriteLine($"Marks  : {data[3]}");
//             Console.WriteLine("--------------------");
//         }
//     }
// }
