//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based.HospitalManagement
//{
//    class OutPatient : Patient
//    {
//        private int consultationCount;

//        public int ConsultationCount { get { return consultationCount; } set { consultationCount = value; } }

//        public OutPatient(int id, string name, int age, int consultations) : base(id, name, age)
//        {
//            consultationCount = consultations;
//        }

//        public override double CalculateBill()
//        {
//            double consultationFee = 300;
//            return consultationCount * consultationFee;
//        }
//    }
//}
