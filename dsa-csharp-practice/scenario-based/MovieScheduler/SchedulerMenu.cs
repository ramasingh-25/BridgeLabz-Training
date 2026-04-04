//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.MovieScheduler
//{
//    class CinemaMenu
//    {
//        private IMovieFunctionality cinemaService;

//        public CinemaMenu(IMovieFunctionality cinemaService)
//        {
//            this.cinemaService = cinemaService;
//        }

//        public void ShowMenu()
//        {
//            while (true)
//            {
//                Console.WriteLine("\n=== CinemaTime Menu ===");
//                Console.WriteLine("1. Add Movie");
//                Console.WriteLine("2. Search Movie");
//                Console.WriteLine("3. Display All Movies");
//                Console.WriteLine("4. Exit");
//                Console.Write("Enter your choice: ");

//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        Console.Write("Enter movie title: ");
//                        string title = Console.ReadLine();

//                        Console.Write("Enter show time: ");
//                        string time = Console.ReadLine();

//                        cinemaService.AddMovie(title, time);
//                        break;

//                    case 2:
//                        Console.Write("Enter keyword to search: ");
//                        string keyword = Console.ReadLine();
//                        cinemaService.SearchMovie(keyword);
//                        break;

//                    case 3:
//                        cinemaService.DisplayAllMovies();
//                        break;

//                    case 4:
//                        Console.WriteLine("Thank you for using CinemaTime!");
//                        return;

//                    default:
//                        Console.WriteLine("Invalid choice. Try again.");
//                        break;
//                }
//            }
//        }
//    }
//}