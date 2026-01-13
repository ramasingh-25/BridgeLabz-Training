//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.CustomerFurnitureManufacturing
//{
//    internal class WasteConstraintCutting : IWoodCuttingStrategy
//    {
//        public int GetMaxRevenue(int length, int[] prices, int allowedWaste)
//        {
//            int best = 0;
//            for (int usable = length; usable >= length - allowedWaste; usable--)
//            {
//                int[] dp = new int[usable + 1];

//                for (int i = 1; i <= usable; i++)
//                {
//                    int max = 0;
//                    for (int cut = 1; cut <= i; cut++)
//                    {
//                        max = Math.Max(max, prices[cut] + dp[i - cut]);
//                    }
//                    dp[i] = max;
//                }
//                best = Math.Max(best, dp[usable]);
//            }
//            return best;
//        }
//    }
//}
