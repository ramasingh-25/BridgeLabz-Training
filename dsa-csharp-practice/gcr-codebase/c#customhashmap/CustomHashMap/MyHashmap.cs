//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.HashMap.CustomHashMap
//{
    
//        public class MyHashMap<K, V>
//        {
//            public class Node
//            {
//                public K Key;
//                public V Value;
//                public Node Next;

//                public Node(K key, V value)
//                {
//                    Key = key;
//                    Value = value;
//                    Next = null;
//                }
//            }

//            private int capacity = 200;

//            private Node[] buckets;

//            public MyHashMap()
//            {
//                buckets = new Node[capacity];
//            }

//            private int GetBucketIndex(K key)
//            {
//                int hashCode = key.GetHashCode();
//                int index = hashCode % capacity;
//                return Math.Abs(index);
//            }

//            public void Put(K key, V value)
//            {
//                int index = GetBucketIndex(key);
//                Node head = buckets[index];

//                while (head != null)
//                {
//                    if (head.Key.Equals(key))
//                    {
//                        head.Value = value;
//                        return;
//                    }
//                    head = head.Next;
//                }

//                Node newNode = new Node(key, value);
//                newNode.Next = buckets[index];
//                buckets[index] = newNode;
//            }

//            public V Get(K key)
//            {
//                int index = GetBucketIndex(key);
//                Node head = buckets[index];

//                while (head != null)
//                {
//                    if (head.Key.Equals(key))
//                    {
//                        return head.Value;
//                    }
//                    head = head.Next;
//                }
//                return default(V);
//            }

//            public bool ContainsKey(K key)
//            {
//                int index = GetBucketIndex(key);
//                Node head = buckets[index];

//                while (head != null)
//                {
//                    if (head.Key.Equals(key))
//                    {
//                        return true;
//                    }
//                    head = head.Next;
//                }
//                return false;
//            }

//            public void Remove(K key)
//            {
//                int index = GetBucketIndex(key);
//                Node head = buckets[index];
//                Node prev = null;

//                while (head != null)
//                {
//                    if (head.Key.Equals(key))
//                    {
//                        if (prev == null)
//                        {
//                            buckets[index] = head.Next;
//                        }
//                        else
//                        {
//                            prev.Next = head.Next;
//                        }
//                        return;
//                    }
//                    prev = head;
//                    head = head.Next;
//                }
//            }
//        }
//    }
