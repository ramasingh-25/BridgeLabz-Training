//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.LoanApprovalAutomation
//{
//    class LoanApplication : IApproval
//    {
//        protected Applicant applicant;
//        protected int months;
//        protected double interestRate;
//        private bool approved;
//        public LoanApplication(Applicant applicant, int months, double interestRate)
//        {
//            this.applicant = applicant;
//            this.months = months;
//            this.interestRate = interestRate;
//            this.approved = false;
//        }
//        protected virtual bool CheckEligibility()
//        {
//            return applicant.GetCreditScore() >= 650 && applicant.GetIncome() >= applicant.GetLoanAmount() / 10;

//        }
//        public bool ApproveLoan()
//        {
//            approved = CheckEligibility();
//            return approved;
//        }
//        public virtual double CalculateEMI()
//        {
//            double p = applicant.GetLoanAmount();
//            double r = interestRate / 12 / 100;

//            return (p * r * Math.Pow(1 + r, months)) / (Math.Pow(1 + r, months) - 1);

//        }
//    }
//}