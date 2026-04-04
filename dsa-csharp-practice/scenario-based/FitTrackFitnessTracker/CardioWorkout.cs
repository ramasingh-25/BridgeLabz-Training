//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.FitTrackFitnessTracker
//{
//    class CardioWorkout : Workout
//    {
//        public double Distance;
//        public double Speed;
//        public string CardioType;

//        public CardioWorkout(string name, string type) : base(name)
//        {
//            CardioType = type;
//            Distance = 0;
//            Speed = 0;
//        }

//        public override void EndWorkout()
//        {
//            EndTime = DateTime.Now;
//            IsActive = false;

            
//            Random random = new Random();
//            Duration = random.Next(15, 61);

//            Console.WriteLine(WorkoutName + " workout ended. Duration: " + Duration + " minutes (Random)");
//        }

//        public void SetDistance(double distance)
//        {
//            Distance = distance;
//        }

//        public void SetSpeed(double speed)
//        {
//            Speed = speed;
//        }

//        public override double CalculateCaloriesBurned()
//        {
           


//            CaloriesBurned = Duration * 10;
//            return CaloriesBurned;
//        }



//        public override void DisplayProgress()
//        {

//            base.DisplayProgress();
//            Console.WriteLine("Cardio Type: " + CardioType);
//            Console.WriteLine("Distance: " + Distance + " km");
//            Console.WriteLine("Speed: " + Speed + " km/h");
//        }
//    }
//}