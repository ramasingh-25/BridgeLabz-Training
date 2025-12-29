//using System;
//using System.Collections.Generic;
//using System.Text;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace project1.DailyLeetcode
//{
//   class SortedArray
//    {
       
//            public boolean check(int[] nums)
//            {
//                int count = 0;
//                boolean check = true;
//                for (int i = 1; i < nums.Length; i++)
//                {
//                    if (nums[i - 1] > nums[i])
//                    {
//                        count++;
//                    }

//                }
//                if (nums[nums.Length - 1] > nums[0])
//                {
//                    count++;
//                }
//                return count <= 1;


//            }
//        }
//    }