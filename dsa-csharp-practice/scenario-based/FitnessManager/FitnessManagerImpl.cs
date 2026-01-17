//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.FitnessManager
//{
    
//        public class FitnessManagerImpl : IFitnessManager
//        {
//            public UserStats[] GroupList;
//            public int Count;
//            public int MaxUsers = 20;

//            public FitnessManagerImpl()
//            {
//                GroupList = new UserStats[MaxUsers];
//                Count = 0;
//            }

//            public void LogUserSteps(string name, int steps)
//            {
//                for (int i = 0; i < Count; i++)
//                {
//                    if (GroupList[i].UserName == name)
//                    {
//                        GroupList[i].Steps = steps;
//                        Console.WriteLine($"    Updated {name}'s steps to {steps}.");
//                        return;
//                    }
//                }

//                if (Count >= MaxUsers)
//                {
//                    Console.WriteLine("    [!] Group is full.");
//                    return;
//                }

//                GroupList[Count] = new UserStats(name, steps);
//                Count++;
//                Console.WriteLine($"    Logged {name}: {steps} steps.");
//            }

//            public void UpdateRankings()
//            {
//                Console.WriteLine("    [!] Updating Leaderboard (Bubble Sort)...");

//                for (int i = 0; i < Count - 1; i++)
//                {
//                    for (int j = 0; j < Count - i - 1; j++)
//                    {
//                        if (GroupList[j].Steps < GroupList[j + 1].Steps)
//                        {
//                            UserStats temp = GroupList[j];
//                            GroupList[j] = GroupList[j + 1];
//                            GroupList[j + 1] = temp;
//                        }
//                    }
//                }
//            }

//            public void ShowLeaderboard()
//            {
//                Console.WriteLine("\n    === DAILY LEADERBOARD ===");
//                for (int i = 0; i < Count; i++)
//                {
//                    Console.WriteLine($"    {i + 1}. {GroupList[i].UserName} : {GroupList[i].Steps} steps");
//                }
//                Console.WriteLine("    =========================\n");
//            }
//        }
//}
