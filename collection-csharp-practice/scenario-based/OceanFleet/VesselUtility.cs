// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class VesselUtil : IVesselUtil
// {
//     private List<Vessel> vesselList;
    
//     public VesselUtil()
//     {
//         vesselList = new List<Vessel>();
//     }
    
//     public void AddVesselPerformance(Vessel vessel)
//     {
//         vesselList.Add(vessel);
//     }
    
//     public Vessel GetVesselById(string vesselId)
//     {
//         return vesselList.FirstOrDefault(v => v.VesselId == vesselId);
//     }
    
//     public List<Vessel> GetHighPerformanceVessels()
//     {
//         if (!vesselList.Any())
//             return new List<Vessel>();
            
//         double maxSpeed = vesselList.Max(v => v.AverageSpeed);
//         return vesselList.Where(v => v.AverageSpeed == maxSpeed).ToList();
//     }
// }