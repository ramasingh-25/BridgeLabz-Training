//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.ScenarioBased.SortAadharNumber
//{
//    class Utility : IAadharUtility
//    {
//        private AadharRecord[] data = new AadharRecord[100];
//        private int size = 0;

//        public void Add(long aadhar)
//        {
//            data[size++] = new AadharRecord(aadhar);
//        }

//        public void Display()
//        {
//            if (size == 0)
//            {
//                Console.WriteLine("No adhar found");
//            }
//            for (int i = 0; i < size; i++)
//                Console.WriteLine($"{i + 1} . " + data[i].GetAadhar());
//        }

//        public void Sort()
//        {
//            for (long pos = 1; pos <= 100000000000L; pos *= 10)
//                CountingSort(pos);
//        }

//        private void CountingSort(long pos)
//        {
//            int[] freq = new int[10];
//            AadharRecord[] outArr = new AadharRecord[size];

//            for (int i = 0; i < size; i++)
//                freq[(data[i].GetAadhar() / pos) % 10]++;

//            for (int i = 1; i < 10; i++)
//                freq[i] += freq[i - 1];

//            for (int i = size - 1; i >= 0; i--)
//            {
//                int d = (int)((data[i].GetAadhar() / pos) % 10);
//                outArr[--freq[d]] = data[i];
//            }

//            for (int i = 0; i < size; i++)
//                data[i] = outArr[i];
//        }

//        public void Search(long key)
//        {
//            int low = 0, high = size - 1;

//            while (low <= high)
//            {
//                int mid = (low + high) / 2;
//                long val = data[mid].GetAadhar();

//                if (val == key)
//                {
//                    Console.WriteLine("Aadhar Found");
//                    return;
//                }
//                if (key < val) high = mid - 1;
//                else low = mid + 1;
//            }
//            Console.WriteLine("Aadhar Not Found");
//        }
//    }
//}
