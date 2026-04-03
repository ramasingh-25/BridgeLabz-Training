// using System;
// using System.Collections.Generic;

// public class CreatorUtility : ICreatorUtility
// {
//     public void RegisterCreator(CreatorStats record)
//     {
//         CreatorStats.EngagementBoard.Add(record);
//     }

//     public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
//     {
//         Dictionary<string, int> result = new Dictionary<string, int>();
        
//         foreach (var creator in records)
//         {
//             int count = 0;
//             foreach (var likes in creator.WeeklyLikes)
//             {
//                 if (likes >= likeThreshold)
//                     count++;
//             }
//             if (count > 0)
//                 result[creator.CreatorName] = count;
//         }
        
//         return result;
//     }

//     public double CalculateAverageLikes()
//     {
//         if (CreatorStats.EngagementBoard.Count == 0)
//             return 0;
            
//         double totalLikes = 0;
//         int totalWeeks = 0;
        
//         foreach (var creator in CreatorStats.EngagementBoard)
//         {
//             foreach (var likes in creator.WeeklyLikes)
//             {
//                 totalLikes += likes;
//                 totalWeeks++;
//             }
//         }
        
//         return totalLikes / totalWeeks;
//     }
// }