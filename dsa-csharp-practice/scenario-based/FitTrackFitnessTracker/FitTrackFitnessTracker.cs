//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.FitTrackFitnessTracker
//{
//     class FitTrackFitnessTracker
//    {
//        static void Main()
//        {
//            Console.WriteLine("=== FitTrack - Fitness Tracker ===");
//            Console.WriteLine();

//            // Get user details
//            Console.Write("Enter your name: ");
//            string name = Console.ReadLine();

//            Console.Write("Enter your age: ");
//            int age = int.Parse(Console.ReadLine());

//            Console.Write("Enter your weight (kg): ");
//            double weight = double.Parse(Console.ReadLine());

//            Console.Write("Enter your height (cm): ");
//            double height = double.Parse(Console.ReadLine());

//            Console.Write("Enter your fitness goal: ");
//            string goal = Console.ReadLine();

//            // Create user profile
//            UserProfile user = new UserProfile(name, age, weight, height);
//            user.SetFitnessGoal(goal);
//            Console.WriteLine();
//            user.DisplayProfile();
//            Console.WriteLine();

//            // Choose workout type
//            Console.WriteLine("Choose workout type:");
//            Console.WriteLine("1. Cardio Workout");
//            Console.WriteLine("2. Strength Workout");
//            Console.Write("Enter choice: ");
//            int choice = int.Parse(Console.ReadLine());
//            Console.WriteLine();

//            if (choice == 1)
//            {
//                // Cardio workout
//                Console.Write("Enter cardio type (Running/Cycling/Swimming): ");
//                string cardioType = Console.ReadLine();

//                CardioWorkout cardio = new CardioWorkout("Cardio Session", cardioType);
//                cardio.StartWorkout();

//                Console.WriteLine("Press any key to end workout...");
//                Console.ReadKey();

//                cardio.EndWorkout();

//                Console.Write("Enter distance covered (km): ");
//                double distance = double.Parse(Console.ReadLine());

//                Console.Write("Enter average speed (km/h): ");
//                double speed = double.Parse(Console.ReadLine());

//                cardio.SetDistance(distance);
//                cardio.SetSpeed(speed);
//                cardio.CalculateCaloriesBurned();

//                Console.WriteLine();
//                cardio.DisplayProgress();
//                user.UpdateProgress(cardio.CaloriesBurned);
//            }
//            else if (choice == 2)
//            {
//                // Strength workout
//                Console.Write("Enter exercise name: ");
//                string exerciseName = Console.ReadLine();

//                Console.Write("Enter muscle group: ");
//                string muscleGroup = Console.ReadLine();

//                StrengthWorkout strength = new StrengthWorkout(exerciseName, muscleGroup);
//                strength.StartWorkout();

//                Console.WriteLine("Press any key to end workout...");
//                Console.ReadKey();

//                strength.EndWorkout();

//                Console.Write("Enter number of sets: ");
//                int sets = int.Parse(Console.ReadLine());

//                Console.Write("Enter reps per set: ");
//                int reps = int.Parse(Console.ReadLine());

//                Console.Write("Enter weight used (kg): ");
//                double workoutWeight = double.Parse(Console.ReadLine());

//                strength.SetWorkoutDetails(sets, reps, workoutWeight);
//                strength.CalculateCaloriesBurned();

//                Console.WriteLine();
//                strength.DisplayProgress();
//                user.UpdateProgress(strength.CaloriesBurned);
//            }
//            else
//            {
//                Console.WriteLine("Invalid choice!");
//            }

//            Console.WriteLine();
//            Console.WriteLine("=== Updated Profile ===");
//            user.DisplayProfile();

//            Console.WriteLine();
//            Console.WriteLine("Press any key to exit...");
//            Console.ReadKey();
//        }
//    }
//}
