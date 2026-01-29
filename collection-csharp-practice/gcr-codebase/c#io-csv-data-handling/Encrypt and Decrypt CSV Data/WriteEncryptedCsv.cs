// using System.IO;

// class WriteEncryptedCsv
// {
//     static void Main()
//     {
//         using (StreamWriter writer = new StreamWriter("secure.csv"))
//         {
//             writer.WriteLine("Name,Email,Salary");
//             writer.WriteLine($"Rahul,{CryptoHelper.Encrypt("rahul@gmail.com")},{CryptoHelper.Encrypt("50000")}");
//         }
//     }
// }
