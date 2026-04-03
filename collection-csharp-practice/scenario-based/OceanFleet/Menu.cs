// using System;
// using System.Collections.Generic;

// public class Menu
// {
//     private IVesselUtil vesselUtil;
    
//     public Menu(IVesselUtil vesselUtil)
//     {
//         this.vesselUtil = vesselUtil;
//     }
    
//     public void Run()
//     {
//         Console.WriteLine("Enter the number of vessels to be added");
//         int numberOfVessels = int.Parse(Console.ReadLine());
        
//         Console.WriteLine("Enter vessel details");
//         for (int i = 0; i < numberOfVessels; i++)
//         {
//             string vesselDetails = Console.ReadLine();
//             string[] parts = vesselDetails.Split(':');
            
//             Vessel vessel = new Vessel(parts[0], parts[1], double.Parse(parts[2]), parts[3]);
//             vesselUtil.AddVesselPerformance(vessel);
//         }
        
//         Console.WriteLine("Enter the Vessel Id to check speed");
//         string searchVesselId = Console.ReadLine();
        
//         Vessel foundVessel = vesselUtil.GetVesselById(searchVesselId);
//         if (foundVessel != null)
//         {
//             Console.WriteLine($"{foundVessel.VesselId} | {foundVessel.VesselName} | {foundVessel.VesselType} | {foundVessel.AverageSpeed} knots");
//         }
//         else
//         {
//             Console.WriteLine($"Vessel Id {searchVesselId} not found");
//         }
        
//         Console.WriteLine("High performance vessels are");
//         List<Vessel> highPerformanceVessels = vesselUtil.GetHighPerformanceVessels();
//         foreach (var vessel in highPerformanceVessels)
//         {
//             Console.WriteLine($"{vessel.VesselId} | {vessel.VesselName} | {vessel.VesselType} | {vessel.AverageSpeed} knots");
//         }
//     }
// }