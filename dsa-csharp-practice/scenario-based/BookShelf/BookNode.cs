//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.BookShelf
//{
//    class BookNode
//    {
//        public string data;
//        public BookNode next;

//        public BookNode(string data)
//        {
//            this.data = data;
//            next = null;
//        }
//    }

//    class BookLinkedList
//    {
//        private BookNode head;

//        public void Add(string book)
//        {
//            if (Contains(book))
//                return;
//            BookNode newNode = new BookNode(book);

//            if (head == null)
//            {
//                head = newNode;
//                return;
//            }

//            BookNode temp = head;
//            while (temp.next != null)
//                temp = temp.next;

//            temp.next = newNode;
//        }
//        public void Remove(string book)
//        {
//            if (head == null) return;

//            if (head.data == book)
//            {
//                head = head.next;
//                return;
//            }
//            BookNode temp = head;
//            while (temp.next != null)
//            {
//                if (temp.next.data == book)
//                {
//                    temp.next = temp.next.next;
//                    return;
//                }
//                temp = temp.next;
//            }
//        }
//        private bool Contains(string book)
//        {
//            BookNode temp = head;
//            while (temp != null)
//            {
//                if (temp.data == book)
//                    return true;
//                temp = temp.next;
//            }
//            return false;
//        }
//        public void Display()
//        {
//            BookNode temp = head;
//            while (temp != null)
//            {
//                Console.WriteLine("  " + temp.data);
//                temp = temp.next;
//            }
//        }
//    }
//}
