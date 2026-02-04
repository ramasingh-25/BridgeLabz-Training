// using System;

// public class Menu
// {
//     private IRobotHazardAuditor robotHazardAuditor;
    
//     public Menu(IRobotHazardAuditor robotHazardAuditor)
//     {
//         this.robotHazardAuditor = robotHazardAuditor;
//     }
    
//     public void Run()
//     {
//         try
//         {
//             Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
//             double armPrecision = double.Parse(Console.ReadLine());
            
//             Console.WriteLine("Enter Worker Density (1 - 20):");
//             int workerDensity = int.Parse(Console.ReadLine());
            
//             Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
//             string machineryState = Console.ReadLine();
            
//             double hazardRisk = robotHazardAuditor.CalculateHazardRisk(armPrecision, workerDensity, machineryState);
//             Console.WriteLine($"Robot Hazard Risk Score: {hazardRisk}");
//         }
//         catch (RobotSafetyException ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }