// using System;
// using System.IO;
// using System.Text.Json;
// using System.Collections.Generic;

// class CsvToJson
// {
//     static void Main()
//     {
//         List<Student> students = new List<Student>();

//         foreach (string line in File.ReadLines("students.csv"))
//         {
//             if (line.StartsWith("Id")) continue;

//             string[] d = line.Split(',');

//             students.Add(new Student
//             {
//                 Id = int.Parse(d[0]),
//                 Name = d[1],
//                 Age = int.Parse(d[2])
//             });
//         }

//         File.WriteAllText("students.json",
//             JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true }));
//     }
// }
