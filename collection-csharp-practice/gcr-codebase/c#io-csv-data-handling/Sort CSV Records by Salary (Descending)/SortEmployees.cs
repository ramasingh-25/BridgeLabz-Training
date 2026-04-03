// using System;
// using System.IO;
// using System.Linq;

// class SortEmployees
// {
//     static void Main()
//     {
//         string filePath = "employees.csv";

//         string[] lines = File.ReadAllLines(filePath);

//         var employees = lines
//             .Skip(1) 
//             .Select(line => line.Split(','))
//             .OrderByDescending(data => int.Parse(data[3]))
//             .Take(5);

//         Console.WriteLine("Top 5 Highest Paid Employees:\n");

//         foreach (var emp in employees)
//         {
//             Console.WriteLine($"Name   : {emp[1]}");
//             Console.WriteLine($"Salary : {emp[3]}");
//             Console.WriteLine("---------------------");
//         }
//     }
// }
