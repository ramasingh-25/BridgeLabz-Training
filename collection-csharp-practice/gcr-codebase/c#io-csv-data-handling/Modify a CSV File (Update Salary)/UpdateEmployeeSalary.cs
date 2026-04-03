// using System;
// using System.IO;

// class UpdateEmployeeSalary
// {
//     static void Main()
//     {
//         string inputFile = "employees.csv";
//         string outputFile = "updated_employees.csv";

//         string[] lines = File.ReadAllLines(inputFile);

//         using (StreamWriter writer = new StreamWriter(outputFile))
//         {
//             writer.WriteLine(lines[0]); // write header

//             for (int i = 1; i < lines.Length; i++)
//             {
//                 string[] data = lines[i].Split(',');

//                 string department = data[2];
//                 double salary = double.Parse(data[3]);

//                 if (department == "IT")
//                 {
//                     salary = salary + (salary * 0.10); // 10% increment
//                 }

//                 writer.WriteLine($"{data[0]},{data[1]},{department},{salary}");
//             }
//         }

//         Console.WriteLine("Salary updated and saved to new CSV file.");
//     }
// }
