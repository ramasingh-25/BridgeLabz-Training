//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.ObjectModelling
//{
//    internal class Association
//    {
//        static void Main(String[] args)
//        {

//            Bank b = new Bank("Bank of baroda ");


//            Customer c1 = new Customer("Rama ");
//            Customer c2 = new Customer("Chitra");


//            b.OpenAccount(c1, 30000);
//            b.OpenAccount(c2, 50000);


//            c1.ViewBalance();
//            c2.ViewBalance();
//        }
//        // class customer
//        class Customer
//    {
//        public string CustomerName;
//        public double Balance;

//        //parameterized constructor
//        public Customer(string entercustomerName)
//        {
//            this.CustomerName = entercustomerName;
//            this.Balance = 0;
//        }


//        public void ViewBalance()
//        {
//            Console.WriteLine(CustomerName + " Balance: " + Balance);
//        }
//    }

//    // another class name as bank
//    class Bank
//    {
//        public string BankName;
//        public List<Customer> Customers;

//        //paramterized constructor
//        public Bank(string enterbankName)
//        {
//            this.BankName = enterbankName;
//            this.Customers = new List<Customer>();
//        }


//        public void OpenAccount(Customer customer, double initialAmount)
//        {
//            customer.Balance = initialAmount;
//            Customers.Add(customer);

//            Console.WriteLine("Account opened for " + customer.CustomerName +
//                              " in " + BankName);
//        }
//    }

    
         
//    }


//}

