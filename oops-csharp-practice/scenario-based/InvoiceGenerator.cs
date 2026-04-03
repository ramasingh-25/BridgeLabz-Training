//using System;

//namespace Oops.Scenario_Based
//{
//    class InvoiceGenerator
//    {
//        static void InitialBill()
//        {
//            Console.WriteLine("Enter work details (Example: Logo Design - 3000 INR, Web Page - 4500 INR)");
//            string invoiceInput = Console.ReadLine();

//            string[] invoiceItems = BreakInvoice(invoiceInput);
//            double totalAmount = CalculateTotal(invoiceItems);

//            Console.WriteLine("Final bill amount is " + totalAmount);
//        }

//        static string[] BreakInvoice(string invoiceData)
//        {
//            string[] workItems = invoiceData.Split(',');

//            Console.WriteLine("Bill Information");

//            foreach (string workItem in workItems)
//            {
//                string[] workDetails = workItem.Split('-');
//                Console.WriteLine(
//                    "Work : " + workDetails[0].Trim() +
//                    " Cost : " + workDetails[1].Trim()
//                );
//            }

//            return workItems;
//        }

//        static double CalculateTotal(string[] workItemList)
//        {
//            double total = 0;

//            foreach (string workItem in workItemList)
//            {
//                string[] itemDetails = workItem.Split('-');
//                string amountText = itemDetails[1].Replace("INR", "").Trim();
//                total += double.Parse(amountText);
//            }

//            return total;
//        }

//        static void Main(string[] args)
//        {
//            InitialBill();
//        }
//    }
//}
