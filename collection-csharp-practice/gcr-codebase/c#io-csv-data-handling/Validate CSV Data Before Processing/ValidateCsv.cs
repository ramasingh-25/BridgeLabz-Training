// using System;
// using System.IO;
// using System.Text.RegularExpressions;

// class ValidateCsv
// {
//     static void Main()
//     {
//         string filePath = "users.csv";

//         string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
//         string phonePattern = @"^\d{10}$";

//         string[] lines = File.ReadAllLines(filePath);

//         Console.WriteLine("Invalid Records:\n");

//         for (int i = 1; i < lines.Length; i++)
//         {
//             string[] data = lines[i].Split(',');

//             bool emailValid = Regex.IsMatch(data[1], emailPattern);
//             bool phoneValid = Regex.IsMatch(data[2], phonePattern);

//             if (!emailValid || !phoneValid)
//             {
//                 Console.WriteLine($"Row {i + 1}: {lines[i]}");

//                 if (!emailValid)
//                     Console.WriteLine("❌ Invalid Email");

//                 if (!phoneValid)
//                     Console.WriteLine("❌ Invalid Phone Number");

//                 Console.WriteLine("-------------------------");
//             }
//         }
//     }
// }
