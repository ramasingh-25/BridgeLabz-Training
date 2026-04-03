//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.ScenarioBased.ExamProctor
//{
//    class CustomHashMap
//    {
//        private int[] keys;
//        private string[] values;
//        private int count;

//        public CustomHashMap(int size)
//        {
//            keys = new int[size];
//            values = new string[size];
//            count = 0;
//        }

//        public void Put(int key, string value)
//        {
//            for (int i = 0; i < count; i++)
//            {
//                if (keys[i] == key)
//                {
//                    values[i] = value;
//                    return;
//                }
//            }

//            keys[count] = key;
//            values[count] = value;
//            count++;
//        }

//        public string Get(int key)
//        {
//            for (int i = 0; i < count; i++)
//            {
//                if (keys[i] == key)
//                    return values[i];
//            }
//            return null;
//        }

//        public int Size()
//        {
//            return count;
//        }

//        public int GetKeyAt(int index)
//        {
//            return keys[index];
//        }
//    }
//}
