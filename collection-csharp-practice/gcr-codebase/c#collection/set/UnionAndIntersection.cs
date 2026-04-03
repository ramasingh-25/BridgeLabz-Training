//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.Set
//{
//    public class UnionAndIntersectionOfTwoSet
//    {
//        //Compute the union and intersection of two sets.

//        public static void Main(string[] args)
//        {
//            HashSet<int> setOne = new HashSet<int> { 9, 8, 7 };
//            HashSet<int> setTwo = new HashSet<int> { 6, 5, 4 };


//            HashSet<int> unionSet = new HashSet<int>(setOne);
//            unionSet.UnionWith(setTwo);


//            HashSet<int> intersectionSet = new HashSet<int>(setOne);
//            intersectionSet.IntersectWith(setTwo);


//            Console.WriteLine("Union: " + string.Join(", ", unionSet));
//            Console.WriteLine("Intersection: " + string.Join(", ", intersectionSet));
//        }
//    }
//}
