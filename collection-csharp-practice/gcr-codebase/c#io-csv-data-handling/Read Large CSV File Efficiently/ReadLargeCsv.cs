// using System;
// using System.IO;
// using System.Collections.Generic;

// class ReadLargeCsv
// {
//     static void Main()
//     {
//         string filePath = "large_students.csv";
//         int batchSize = 100;
//         int processedCount = 0;

//         using (StreamReader reader = new StreamReader(filePath))
//         {
//             string line;
//             bool isHeader = true;
//             List<string> batch = new List<string>();

//             while ((line = reader.ReadLine()) != null)
//             {
//                 if (isHeader)
//                 {
//                     isHeader = false;
//                     continue;
//                 }

//                 batch.Add(line);

//                 if (batch.Count == batchSize)
//                 {
//                     processedCount += batch.Count;
//                     Console.WriteLine($"Processed records: {processedCount}");
//                     batch.Clear();
//                 }
//             }

//             if (batch.Count > 0)
//             {
//                 processedCount += batch.Count;
//                 Console.WriteLine($"Processed records: {processedCount}");
//             }
//         }
//     }
// }
