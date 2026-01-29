// using System;
// using System.IO;

// class CountCsvRows
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

//         int recordCount = lines.Length - 1; // exclude header

//         Console.WriteLine($"Total number of records: {recordCount}");
//     }
// }
