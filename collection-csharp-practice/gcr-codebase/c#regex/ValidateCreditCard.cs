// using System;
// using System.Text.RegularExpressions;

// class ValidateCreditCard
// {
//     static void Main()
//     {
//         Console.Write("Enter the number: ");
//         string c = Console.ReadLine();

//         string visa = @"^4\d{15}$";
//         string mc = @"^5\d{15}$";

//         if (Regex.IsMatch(c, visa))
//             Console.WriteLine("Visa Card");
//         else if (Regex.IsMatch(c, mc))
//             Console.WriteLine("MasterCard");
//         else
//             Console.WriteLine("Invalid");
//     }
// }
