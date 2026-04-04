//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.LinkedList
//{
//     class SocialMediaConnection
//    {
//        class UserNode
//        {
//            public int UserId;
//            public string Name;
//            public int Age;
//            public int[] Friends = new int[20];
//            public int FriendCount = 0;
//            public UserNode Next;

//            //parameterized constructor
//            public UserNode(int id, string name, int age)
//            {
//                this.UserId = id;
//                this.Name = name;
//                this.Age = age;
//                this.Next = null;
//            }
//        }

//        class SocialMedia
//        {
//            private UserNode head;


//            public void AddUser(int id, string name, int age)
//            {
//                UserNode newNode = new UserNode(id, name, age);
//                newNode.Next = head;
//                head = newNode;
//            }


//            public UserNode SearchById(int id)
//            {
//                UserNode temp = head;
//                while (temp != null)
//                {
//                    if (temp.UserId == id)
//                        return temp;
//                    temp = temp.Next;
//                }
//                return null;
//            }


//            public UserNode SearchByName(string name)
//            {
//                UserNode temp = head;
//                while (temp != null)
//                {
//                    if (temp.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
//                        return temp;
//                    temp = temp.Next;
//                }
//                return null;
//            }


//            public void AddFriend(int id1, int id2)
//            {
//                UserNode u1 = SearchById(id1);
//                UserNode u2 = SearchById(id2);

//                if (u1 == null || u2 == null)
//                {
//                    Console.WriteLine("User not found.");
//                    return;
//                }

//                u1.Friends[u1.FriendCount++] = id2;
//                u2.Friends[u2.FriendCount++] = id1;

//                Console.WriteLine("Friend connection added.");
//            }

//            public void RemoveFriend(int id1, int id2)
//            {
//                UserNode u1 = SearchById(id1);
//                UserNode u2 = SearchById(id2);

//                if (u1 == null || u2 == null) return;

//                RemoveFriendId(u1, id2);
//                RemoveFriendId(u2, id1);

//                Console.WriteLine("Friend connection removed.");
//            }

//            private void RemoveFriendId(UserNode user, int friendId)
//            {
//                for (int i = 0; i < user.FriendCount; i++)
//                {
//                    if (user.Friends[i] == friendId)
//                    {
//                        for (int j = i; j < user.FriendCount - 1; j++)
//                            user.Friends[j] = user.Friends[j + 1];

//                        user.FriendCount--;
//                        break;
//                    }
//                }
//            }


//            public void ShowFriends(int id)
//            {
//                UserNode user = SearchById(id);
//                if (user == null) return;

//                Console.Write("Friends of " + user.Name + ": ");
//                for (int i = 0; i < user.FriendCount; i++)
//                    Console.Write(user.Friends[i] + " ");
//                Console.WriteLine();
//            }


//            public void MutualFriends(int id1, int id2)
//            {
//                UserNode u1 = SearchById(id1);
//                UserNode u2 = SearchById(id2);

//                Console.Write("Mutual Friends: ");
//                for (int i = 0; i < u1.FriendCount; i++)
//                {
//                    for (int j = 0; j < u2.FriendCount; j++)
//                    {
//                        if (u1.Friends[i] == u2.Friends[j])
//                            Console.Write(u1.Friends[i] + " ");
//                    }
//                }
//                Console.WriteLine();
//            }


           
//            public void CountFriends()
//            {
//                UserNode temp = head;
//                while (temp != null)
//                {
//                    Console.WriteLine($"{temp.Name} has {temp.FriendCount} friends");
//                    temp = temp.Next;
//                }
//            }
//        }

        
        
//            //MAIN METHOD

//            public static void Main(string[] args)
//            {
//                SocialMedia sm = new SocialMedia();

//                sm.AddUser(1, "Chitra", 15);
//                sm.AddUser(2, "Swati", 16);
//                sm.AddUser(3, "Khushi", 17);

//                Console.WriteLine();

//                sm.AddFriend(1, 3);
//                sm.AddFriend(1, 2);
//                sm.AddFriend(2, 3);

//                Console.WriteLine();

//                sm.ShowFriends(2);
//                sm.MutualFriends(1, 3);
//                sm.CountFriends();

//                Console.WriteLine();

//                sm.RemoveFriend(1, 2);
//                sm.ShowFriends(2);
//            }
//        }
//    }
