// using System;
// using System.IO;
// using System.Text.Json;
// using System.Collections.Generic;

// class JsonToCsv
// {
//     static void Main()
//     {
//         var students = JsonSerializer.Deserialize<List<Student>>(
//             File.ReadAllText("students.json"));

//         using (StreamWriter writer = new StreamWriter("students.csv"))
//         {
//             writer.WriteLine("Id,Name,Age");

//             foreach (var s in students)
//                 writer.WriteLine($"{s.Id},{s.Name},{s.Age}");
//         }
//     }
// }

// class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public int Age { get; set; }
// }
