//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.LinkedList
//{
//    internal class InventoryManagementSystem
//    {
//        class ItemNode
//        {
//            public int ItemId;
//            public string ItemName;
//            public int Quantity;
//            public double Price;
//            public ItemNode Next;


            
//            public ItemNode(int id, string name, int qty, double price)
//            {
//                this.ItemId = id;
//                this.ItemName = name;
//                this.Quantity = qty;
//                this.Price = price;
//                Next = null;
//            }
//        }

        
//        class InventoryList
//        {
//            private ItemNode head;

//            public void AddAtBeginning(int id, string name, int qty, double price)
//            {
//                ItemNode newNode = new ItemNode(id, name, qty, price);
//                newNode.Next = head;
//                head = newNode;
//            }

//            public void AddAtEnd(int id, string name, int qty, double price)
//            {
//                ItemNode newNode = new ItemNode(id, name, qty, price);

//                if (head == null)
//                {
//                    head = newNode;
//                    return;
//                }

//                ItemNode temp = head;
//                while (temp.Next != null)
//                    temp = temp.Next;

//                temp.Next = newNode;
//            }

//            public void AddAtPosition(int position, int id, string name, int qty, double price)
//            {
//                if (position <= 1 || head == null)
//                {
//                    AddAtBeginning(id, name, qty, price);
//                    return;
//                }

//                ItemNode temp = head;
//                for (int i = 1; i < position - 1 && temp.Next != null; i++)
//                    temp = temp.Next;

//                ItemNode newNode = new ItemNode(id, name, qty, price);
//                newNode.Next = temp.Next;
//                temp.Next = newNode;
//            }




            
//            public void RemoveByItemId(int id)
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("Inventory is empty.");
//                    return;
//                }

//                if (head.ItemId == id)
//                {
//                    head = head.Next;
//                    Console.WriteLine("Item removed successfully.");
//                    return;
//                }

//                ItemNode temp = head;
//                while (temp.Next != null && temp.Next.ItemId != id)
//                    temp = temp.Next;

//                if (temp.Next == null)
//                    Console.WriteLine("Item not found.");
//                else
//                {
//                    temp.Next = temp.Next.Next;
//                    Console.WriteLine("Item removed successfully.");
//                }
//            }



           
//            public void UpdateQuantity(int id, int newQty)
//            {
//                ItemNode temp = head;
//                while (temp != null)
//                {
//                    if (temp.ItemId == id)
//                    {
//                        temp.Quantity = newQty;
//                        Console.WriteLine("Quantity updated successfully.");
//                        return;
//                    }
//                    temp = temp.Next;
//                }
//                Console.WriteLine("Item not found.");
//            }




           
//            public void SearchByItemId(int id)
//            {
//                ItemNode temp = head;
//                while (temp != null)
//                {
//                    if (temp.ItemId == id)
//                    {
//                        DisplayItem(temp);
//                        return;
//                    }
//                    temp = temp.Next;
//                }
//                Console.WriteLine("Item not found.");
//            }




//            public void SearchByItemName(string name)
//            {
//                ItemNode temp = head;
//                bool found = false;

//                while (temp != null)
//                {
//                    if (temp.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase))
//                    {
//                        DisplayItem(temp);
//                        found = true;
//                    }
//                    temp = temp.Next;
//                }

//                if (!found)
//                    Console.WriteLine("Item not found.");
//            }



//            public void CalculateTotalValue()
//            {
//                double total = 0;
//                ItemNode temp = head;

//                while (temp != null)
//                {
//                    total += temp.Price * temp.Quantity;
//                    temp = temp.Next;
//                }

//                Console.WriteLine($"Total Inventory Value: ₹{total}");
//            }



//            //Sort the inventory based on Item Name or Price in ascending or descending order.
//            public void Sort(string criteria, bool ascending)
//            {
//                if (head == null) return;

//                for (ItemNode i = head; i.Next != null; i = i.Next)
//                {
//                    for (ItemNode j = i.Next; j != null; j = j.Next)
//                    {
//                        bool condition = false;

//                        if (criteria == "name")
//                            condition = ascending
//                                ? string.Compare(i.ItemName, j.ItemName) > 0
//                                : string.Compare(i.ItemName, j.ItemName) < 0;
//                        else if (criteria == "price")
//                            condition = ascending
//                                ? i.Price > j.Price
//                                : i.Price < j.Price;

//                        if (condition)
//                            SwapData(i, j);
//                    }
//                }

//                Console.WriteLine("Inventory sorted successfully.");
//            }

//            private void SwapData(ItemNode a, ItemNode b)
//            {
//                (a.ItemId, b.ItemId) = (b.ItemId, a.ItemId);
//                (a.ItemName, b.ItemName) = (b.ItemName, a.ItemName);
//                (a.Quantity, b.Quantity) = (b.Quantity, a.Quantity);
//                (a.Price, b.Price) = (b.Price, a.Price);
//            }



//            //Display everything
//            public void DisplayAll()
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("Inventory is empty.");
//                    return;
//                }

//                ItemNode temp = head;
//                while (temp != null)
//                {
//                    DisplayItem(temp);
//                    temp = temp.Next;
//                }
//            }

//            private void DisplayItem(ItemNode item)
//            {
//                Console.WriteLine($"ID: {item.ItemId}, Name: {item.ItemName}, Qty: {item.Quantity}, Price: ₹{item.Price}");
//            }
//        }

       
//            public static void Main(string[] args)
//            {
//                InventoryList inventory = new InventoryList();

//                inventory.AddAtEnd(1, "Speaker", 5, 80000);
//                inventory.AddAtBeginning(2, "Television", 20, 35000);
//                inventory.AddAtPosition(3, 3, "MobilePhone", 10, 1500);

//                Console.WriteLine("Inventory List:");
//                inventory.DisplayAll();
//                Console.WriteLine();

//                Console.WriteLine("Update Quantity:");
//                inventory.UpdateQuantity(2, 25);
//                Console.WriteLine();

//                Console.WriteLine("Search by Name:");
//                inventory.SearchByItemName("MAC");
//                Console.WriteLine();

//                Console.WriteLine("Total Inventory Value:");
//                inventory.CalculateTotalValue();

//                Console.WriteLine("Sort by Price in Ascending order:");
//                inventory.Sort("price", true);
//                inventory.DisplayAll();
//                Console.WriteLine();

//                Console.WriteLine("Remove Item:");
//                inventory.RemoveByItemId(3);
//                inventory.DisplayAll();
//            }
//        }
//    }
