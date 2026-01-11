//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.FitTrackFitnessTracker
//{
//    abstract class Workout : ITrackable
//    {
//        public string WorkoutName;
//        public int Duration;
//        public DateTime StartTime;
//        public DateTime EndTime;
//        public double CaloriesBurned;
//        public bool IsActive;

//        public Workout(string name)
//        {
//            WorkoutName = name;
//            Duration = 0;
//            CaloriesBurned = 0;
//            IsActive = false;
//        }

//        public virtual void StartWorkout()
//        {
//            StartTime = DateTime.Now;
//            IsActive = true;
//            Console.WriteLine(WorkoutName + " workout started at " + StartTime.ToString("HH:mm:ss"));
//        }

//        public virtual void EndWorkout()
//        {
//            EndTime = DateTime.Now;
//            IsActive = false;
//            Duration = (int)(EndTime - StartTime).TotalMinutes;
//            Console.WriteLine(WorkoutName + " workout ended. Duration: " + Duration + " minutes");
//        }

//        public abstract double CalculateCaloriesBurned();

//        public virtual void DisplayProgress()
//        {
//            Console.WriteLine("Workout: " + WorkoutName);
//            Console.WriteLine("Duration: " + Duration + " minutes");
//            Console.WriteLine("Calories Burned: " + CaloriesBurned);
//        }
//    }
//}
