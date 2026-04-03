// using System;
// using System.IO;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         string filePath = "students.csv";
//         List<Student> students = new List<Student>();

//         if (!File.Exists(filePath))
//         {
//             Console.WriteLine("CSV file not found!");
//             return;
//         }

//         foreach (string line in File.ReadLines(filePath))
//         {
//             // Skip header row
//             if (line.StartsWith("ID"))
//                 continue;

//             string[] data = line.Split(',');

//             Student student = new Student
//             {
//                 Id = int.Parse(data[0]),
//                 Name = data[1],
//                 Age = int.Parse(data[2]),
//                 Marks = int.Parse(data[3])
//             };

//             students.Add(student);
//         }

//         Console.WriteLine("Student Details:\n");

//         foreach (Student s in students)
//         {
//             s.Display();
//         }
//     }
// }
