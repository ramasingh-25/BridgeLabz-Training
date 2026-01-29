// using System;
// using System.Data.SqlClient;
// using System.IO;

// class DbToCsv
// {
//     static void Main()
//     {
//         string connStr = "your_connection_string";
//         string query = "SELECT EmployeeId, Name, Department, Salary FROM Employees";

//         using (SqlConnection con = new SqlConnection(connStr))
//         using (SqlCommand cmd = new SqlCommand(query, con))
//         using (StreamWriter writer = new StreamWriter("employees_report.csv"))
//         {
//             con.Open();
//             SqlDataReader reader = cmd.ExecuteReader();

//             writer.WriteLine("Employee ID,Name,Department,Salary");

//             while (reader.Read())
//             {
//                 writer.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]}");
//             }
//         }
//     }
// }
