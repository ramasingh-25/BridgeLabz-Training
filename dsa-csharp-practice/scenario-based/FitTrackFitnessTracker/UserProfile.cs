//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.FitTrackFitnessTracker
//{
//    class UserProfile
//    {
//        public string Name;
//        public int Age;
//        public double Weight;
//        public double Height;
//        public string FitnessGoal;
//        public double TotalCaloriesBurned;
//        public int TotalWorkouts;

//        public UserProfile(string name, int age, double weight, double height)
//        {
//            Name = name;
//            Age = age;
//            Weight = weight;
//            Height = height;
//            FitnessGoal = "";
//            TotalCaloriesBurned = 0;
//            TotalWorkouts = 0;
//        }

//        public void SetFitnessGoal(string goal)
//        {
//            FitnessGoal = goal;
//            Console.WriteLine("Fitness goal set: " + goal);
//        }

//        public void UpdateProgress(double calories)
//        {
//            TotalCaloriesBurned += calories;
//            TotalWorkouts++;
//        }

//        public void DisplayProfile()
//        {
//            Console.WriteLine("=== User Profile ===");
//            Console.WriteLine("Name: " + Name);
//            Console.WriteLine("Age: " + Age);
//            Console.WriteLine("Weight: " + Weight + " kg");
//            Console.WriteLine("Height: " + Height + " cm");
//            Console.WriteLine("Fitness Goal: " + FitnessGoal);
//            Console.WriteLine("Total Workouts: " + TotalWorkouts);
//            Console.WriteLine("Total Calories Burned: " + TotalCaloriesBurned);
//        }
//    }
//}
