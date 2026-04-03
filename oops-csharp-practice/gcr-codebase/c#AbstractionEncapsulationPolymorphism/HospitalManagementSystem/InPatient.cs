//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.HospitalManagementSystem
//{
//    class InPatient : Patient
//    {
//        private int daysAdmitted;
//        private double dailyCharge;

//        public InPatient(int id, string name, int age, string diagnosis, int days, double charge)
//            : base(id, name, age, diagnosis)
//        {
//            daysAdmitted = days;
//            dailyCharge = charge;
//        }

//        public override double CalculateBill()
//        {
//            return daysAdmitted * dailyCharge;
//        }
//    }

//}
