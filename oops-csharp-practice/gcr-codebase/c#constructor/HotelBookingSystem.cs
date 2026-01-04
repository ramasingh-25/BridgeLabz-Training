//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Constructor
//{
//    internal class HotelBookingSystem
//    {
//            public string guestName;
//            public string roomType;
//            public string nights;

            
//            public HotelBookingSystem()
//            {
//                guestName = "Rama";
//                roomType = "Standard";
//                nights = "7Night";
//            }

           
//            public HotelBookingSystem(string GuestName, string RoomType, string Nights)
//            {
//                this.guestName = GuestName;
//                this.roomType = RoomType;
//                this.nights = Nights;
//            }

            
//            public HotelBookingSystem(HotelBookingSystem other)  //copy constructor
//            {
//                guestName = other.guestName;
//                roomType = other.roomType;
//                nights = other.nights;
//            }
        
//            public static void Main(string[] args)  //main method
//            {
//                //constructor calling
//                HotelBookingSystem B1 = new HotelBookingSystem();

//                Console.WriteLine(B1.guestName + "," + B1.roomType + "," + B1.nights);


//                //param constructor calling 
//                HotelBookingSystem B2 = new HotelBookingSystem("Chitra", "Basic", "8 nights");

//                Console.WriteLine(B2.guestName + "," + B2.roomType + "," + B2.nights);


//                HotelBookingSystem B3 = new HotelBookingSystem(B2);

//                Console.WriteLine(B3.guestName + "," + B3.roomType + "," + B3.nights);

//            }

//        }
//    }

