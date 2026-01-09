//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.LinkedList
//{
//    class OnlineTicketBookingSystem
//    {
//        class TicketNode
//        {
//            public int TicketId;
//            public string CustomerName;
//            public string MovieName;
//            public string SeatNumber;
//            public string BookingTime;
//            public TicketNode Next;


//            //parameterized constructor


//            public TicketNode(int id, string customer, string movie, string seat, string time)
//            {
//                this.TicketId = id;
//                this.CustomerName = customer;
//                this.MovieName = movie;
//                this.SeatNumber = seat;
//                this.BookingTime = time;
//                this.Next = null;
//            }
//        }

//        class TicketSystem
//        {
//            private TicketNode head = null;

           

//            public void AddTicket(int id, string customer, string movie, string seat, string time)
//            {
//                TicketNode newNode = new TicketNode(id, customer, movie, seat, time);

//                if (head == null)
//                {
//                    head = newNode;
//                    newNode.Next = head;
//                    return;
//                }

//                TicketNode temp = head;
//                while (temp.Next != head)
//                {
//                    temp = temp.Next;
//                }

//                temp.Next = newNode;
//                newNode.Next = head;

//            }


            
//            public void RemoveTicket(int id)     //Remove Tickets by id
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("No tickets to remove.");
//                    return;
//                }

//                TicketNode curr = head;
//                TicketNode prev = null;

//                do
//                {
//                    if (curr.TicketId == id)
//                    {
//                        if (prev == null) 
//                        {
//                            TicketNode last = head;
//                            while (last.Next != head)
//                                last = last.Next;

//                            head = head.Next;
//                            last.Next = head;
//                        }
//                        else
//                        {
//                            prev.Next = curr.Next;
//                        }

//                        Console.WriteLine("Ticket removed successfully.");
//                        return;
//                    }

//                    prev = curr;
//                    curr = curr.Next;

//                } while (curr != head);

//                Console.WriteLine("Ticket not found.");
//            }


            
//            public void DisplayTickets()
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("No tickets booked.");
//                    return;
//                }

//                TicketNode temp = head;
//                do
//                {
//                    Console.WriteLine(
//                        $"ID:{temp.TicketId}, Name:{temp.CustomerName}, Movie:{temp.MovieName}, Seat:{temp.SeatNumber}, Time:{temp.BookingTime}"
//                    );
//                    temp = temp.Next;
//                } while (temp != head);
//            }


//            public void SearchTicket(string key)
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("No tickets available.");
//                    return;
//                }

//                bool found = false;
//                TicketNode temp = head;

//                do
//                {
//                    if (temp.CustomerName.Equals(key, StringComparison.OrdinalIgnoreCase) ||
//                        temp.MovieName.Equals(key, StringComparison.OrdinalIgnoreCase))
//                    {
//                        Console.WriteLine(
//                            $"ID:{temp.TicketId}, Name:{temp.CustomerName}, Movie:{temp.MovieName}, Seat:{temp.SeatNumber}"
//                        );
//                        found = true;
//                    }
//                    temp = temp.Next;
//                } while (temp != head);

//                if (!found)
//                    Console.WriteLine("No matching ticket found.");
//            }


           
//            public int CountTickets()
//            {
//                if (head == null) return 0;

//                int count = 0;
//                TicketNode temp = head;

//                do
//                {
//                    count++;
//                    temp = temp.Next;
//                } while (temp != head);

//                return count;
//            }
//        }

       
        

            
//            public static void Main(string[] args)     //main method
//        {
//                TicketSystem ts = new TicketSystem();

//                ts.AddTicket(1, "Chitra", "Ghost", "A1", "10:00 AM");
//                ts.AddTicket(2, "Swati", "Money Heist", "A1", "11:00 PM");
//                ts.AddTicket(3, "Khushi", "OMG", "A2", "30:00 AM");

//                Console.WriteLine("All Tickets:");
//                ts.DisplayTickets();
//                Console.WriteLine();

//                Console.WriteLine("Search by Movie:");
//                ts.SearchTicket("Conjuring");

//                Console.WriteLine();

//                Console.WriteLine("Total Tickets: " + ts.CountTickets());
//                ts.RemoveTicket(2);
//                Console.WriteLine();

//                Console.WriteLine("After Removal..final displaying");
//                ts.DisplayTickets();
//            }
//        }
//    }
