// using System;
// using System.Collections.Generic;

// public class Menu
// {
//     private ICreatorUtility creatorUtility;
    
//     public Menu(ICreatorUtility creatorUtility)
//     {
//         this.creatorUtility = creatorUtility;
//     }
    
//     public void Run()
//     {
//         while (true)
//         {
//             DisplayMenu();
//             string choice = Console.ReadLine();
            
//             switch (choice)
//             {
//                 case "1":
//                     RegisterCreator();
//                     break;
//                 case "2":
//                     ShowTopPosts();
//                     break;
//                 case "3":
//                     CalculateAverage();
//                     break;
//                 case "4":
//                     Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
//                     return;
//             }
//         }
//     }
    
//     private void DisplayMenu()
//     {
//         Console.WriteLine("1. Register Creator");
//         Console.WriteLine("2. Show Top Posts");
//         Console.WriteLine("3. Calculate Average Likes");
//         Console.WriteLine("4. Exit");
//         Console.WriteLine();
//         Console.Write("Enter your choice:");
//         Console.WriteLine();
//     }
    
//     private void RegisterCreator()
//     {
//         Console.Write("Enter Creator Name:");
//         Console.WriteLine();
//         string name = Console.ReadLine();
        
//         Console.Write("Enter weekly likes (Week 1 to 4):");
//         Console.WriteLine();
//         double[] likes = new double[4];
//         for (int i = 0; i < 4; i++)
//         {
//             likes[i] = double.Parse(Console.ReadLine());
//         }
        
//         CreatorStats creator = new CreatorStats(name, likes);
//         creatorUtility.RegisterCreator(creator);
//         Console.WriteLine("Creator registered successfully");
//         Console.WriteLine();
//     }
    
//     private void ShowTopPosts()
//     {
//         Console.Write("Enter like threshold:");
//         Console.WriteLine();
//         double threshold = double.Parse(Console.ReadLine());
        
//         var topPosts = creatorUtility.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);
        
//         if (topPosts.Count == 0)
//         {
//             Console.WriteLine("No top-performing posts this week");
//         }
//         else
//         {
//             foreach (var post in topPosts)
//             {
//                 Console.WriteLine($"{post.Key} - {post.Value}");
//             }
//         }
//         Console.WriteLine();
//     }
    
//     private void CalculateAverage()
//     {
//         double average = creatorUtility.CalculateAverageLikes();
//         Console.WriteLine($"Overall average weekly likes: {average}");
//         Console.WriteLine();
//     }
// }