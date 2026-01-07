//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.FoodDeliverySystem
//{

//    class VegItem : FoodItem, IDiscountable
//    {
//        public VegItem(string name, double price, int quantity)
//            : base(name, price, quantity) { }

//        public override double CalculatingTotalPrice()
//        {
//            return Price * Quantity;
//        }

//        public double ApplyDiscount()
//        {
//            return CalculatingTotalPrice() * 0.10;
//        }

//        public string GetDiscountDetails()
//        {
//            return "10% discount on Veg items";
//        }
//    }
//}