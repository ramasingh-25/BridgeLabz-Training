// using System;
// using System.IO;

// class SearchEmployee
// {
//     static void Main()
//     {
//         string filePath = "employees.csv";

//         Console.Write("Enter employee name to search: ");
//         string searchName = Console.ReadLine();

//         bool found = false;
//         string[] lines = File.ReadAllLines(filePath);

//         for (int i = 1; i < lines.Length; i++)
//         {
//             string[] data = lines[i].Split(',');

//             if (data[1].Equals(searchName, StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("\nEmployee Found:");
//                 Console.WriteLine($"Name       : {data[1]}");
//                 Console.WriteLine($"Department : {data[2]}");
//                 Console.WriteLine($"Salary     : {data[3]}");
//                 found = true;
//                 break;
//             }
//         }

//         if (!found)
//         {
//             Console.WriteLine("\nEmployee not found.");
//         }
//     }
// }
