//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based.BirdSanctuary
//{

//     class SanctuaryMenu
//    {
//        private Bird[] birds;
//        public SanctuaryMenu(Bird[] birds)
//        {
//            this.birds = birds;
//        }
//        public void ShowMenu()
//        {
//            int choice;
//            do
//            {
//                Console.WriteLine("=======EcoWing Bird Sanctuary Menu===== ");
//                Console.WriteLine("1. View All Birds");
//                Console.WriteLine("2. All Flying Birds");
//                Console.WriteLine("3. All Swimming Birds");
//                Console.WriteLine("4. Exit");
//                Console.WriteLine("Enter your CHOICE");
//                choice = Convert.ToInt32(Console.ReadLine());
//                Console.WriteLine();
//                switch (choice)
//                {
//                    case 1:
//                        DisplayAllBirds();
//                        break;
//                    case 2:
//                        DisplayFlyingBirds();
//                        break;
//                    case 3:
//                        DisplaySwimmingBirds();
//                        break;
//                    case 4:
//                        Console.WriteLine("Exiting Bird Sanctuary System");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid Choice");
//                        break;
//                }
//                Console.WriteLine();
//            }
//            while (choice != 4);
//        }
//        private void DisplayAllBirds()
//        {
//            foreach (Bird bird in birds)
//            {
//                bird.DisplayInfo();
//                if (bird is IFlyable flyingBird)
//                {
//                    flyingBird.Fly();
//                }
//                if (bird is ISwimmable swimmingBird)
//                {
//                    swimmingBird.Swim();
//                }
//                Console.WriteLine();
//            }
//        }
//        private void DisplayFlyingBirds()
//        {
//            foreach (Bird bird in birds)
//            {

//                if (bird is IFlyable flyingBird)
//                {
//                    bird.DisplayInfo();

//                    flyingBird.Fly();
//                    Console.WriteLine();
//                }

//            }
//        }
//        private void DisplaySwimmingBirds()
//        {
//            foreach (Bird bird in birds)
//            {

//                if (bird is ISwimmable swimmingBird)
//                {
//                    bird.DisplayInfo();
//                    swimmingBird.Swim();
//                    Console.WriteLine();
//                }

//            }
//        }

//    }
//}
