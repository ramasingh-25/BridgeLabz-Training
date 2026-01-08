//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based.HospitalManagement
//{
//    class InPatient : Patient
//    {
//        private int daysAdmitted;
//        private double roomCharges;

//        public int DaysAdmitted { get { return daysAdmitted; } set { daysAdmitted = value; } }
//        public double RoomCharges { get { return roomCharges; } set { roomCharges = value; } }

//        public InPatient(int id, string name, int age, int days, double charges) : base(id, name, age)
//        {
//            daysAdmitted = days;
//            roomCharges = charges;
//        }

//        public override double CalculateBill()
//        {
//            double consultationFee = 500;
//            double totalRoomCharges = daysAdmitted * roomCharges;
//            return consultationFee + totalRoomCharges;
//        }
//    }
//}
