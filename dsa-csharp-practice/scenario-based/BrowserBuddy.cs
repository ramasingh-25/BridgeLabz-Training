//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based
//{
   
//    class PageNode
//    {
//        public string Url;
//        public PageNode Previous;
//        public PageNode Next;

//        public PageNode(string url)
//        {
//            Url = url;
//            Previous = null;
//            Next = null;
//        }
//    }

//    class BrowserBuddy
//    {
//        PageNode currentPage;
//        Stack<PageNode> closedPages = new Stack<PageNode>();

//        public void Visit(string url)
//        {
//            PageNode newPageNode = new PageNode(url);

//            if (currentPage != null)
//            {
//                currentPage.Next = newPageNode;
//                newPageNode.Previous = currentPage;
//            }

//            currentPage = newPageNode;
//            Console.WriteLine("Visited website: " + url);
//        }

//        public void Back()
//        {
//            if (currentPage != null && currentPage.Previous != null)
//            {
//                currentPage = currentPage.Previous;
//                Console.WriteLine("Back to: " + currentPage.Url);
//            }
//            else
//            {
//                Console.WriteLine("No previous page");
//            }
//        }

//        public void Forward()
//        {
//            if (currentPage != null && currentPage.Next != null)
//            {
//                currentPage = currentPage.Next;
//                Console.WriteLine("Forward to: " + currentPage.Url);
//            }
//            else
//            {
//                Console.WriteLine("No next page");
//            }
//        }

//        public void CloseTab()
//        {
//            if (currentPage == null)
//            {
//                Console.WriteLine("No tab to close.");
//                return;
//            }

//            closedPages.Push(currentPage);
//            Console.WriteLine("Closed tab: " + currentPage.Url);

//            if (currentPage.Previous != null)
//            {
//                currentPage = currentPage.Previous;
//                currentPage.Next = null;
//            }
//            else
//            {
//                currentPage = null;
//            }
//        }

//        public void RestoreTab()
//        {
//            if (closedPages.Count == 0)
//            {
//                Console.WriteLine("No closed tabs to restore.");
//                return;
//            }

//            currentPage = closedPages.Pop();
//            Console.WriteLine("Restored tab: " + currentPage.Url);
//        }

//        public void ShowCurrent()
//        {
//            if (currentPage != null)
//                Console.WriteLine("Current Page: " + currentPage.Url);
//            else
//                Console.WriteLine("No page opened");
//        }

//        class Menu
//        {
//            public void ShowMenu()
//            {
//                BrowserBuddy browserBuddy = new BrowserBuddy();
//                int userChoice;

//                do
//                {
//                    Console.WriteLine("\n--- BrowserBuddy Menu ---");
//                    Console.WriteLine("1. Visit Page");
//                    Console.WriteLine("2. Back");
//                    Console.WriteLine("3. Forward");
//                    Console.WriteLine("4. Close Tab");
//                    Console.WriteLine("5. Restore Closed Tab");
//                    Console.WriteLine("6. Show Current Page");
//                    Console.WriteLine("0. Exit");
//                    Console.Write("Enter choice: ");

//                    userChoice = int.Parse(Console.ReadLine());

//                    switch (userChoice)
//                    {
//                        case 1:
//                            Console.Write("Enter URL: ");
//                            browserBuddy.Visit(Console.ReadLine());
//                            break;
//                        case 2:
//                            browserBuddy.Back();
//                            break;
//                        case 3:
//                            browserBuddy.Forward();
//                            break;
//                        case 4:
//                            browserBuddy.CloseTab();
//                            break;
//                        case 5:
//                            browserBuddy.RestoreTab();
//                            break;
//                        case 6:
//                            browserBuddy.ShowCurrent();
//                            break;
//                    }

//                } while (userChoice != 0);
//            }
//        }

//        class StartApp
//        {
//            static void Main()
//            {
//                new Menu().ShowMenu();
//            }
//        }
//    }

//}