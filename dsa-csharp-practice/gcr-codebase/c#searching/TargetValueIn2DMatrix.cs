//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Searching
//{

//     class TargetValueIn2DMatrix
//    {
//        static void Main()

//            {
//                int[,] matrix =

//                {
//                    { 3, 6, 7, 9 },
//                    { 11, 13,14, 15 },
//                    { 19, 22, 23, 25 }
//                };

//                int targetValue = 19;

//                bool found = SearchMatrix(matrix, targetValue);

//                Console.WriteLine(found ? "Target found in matrix"
//                    : "Target not found in matrix");
//            }

//            static bool SearchMatrix(int[,] matrix, int target)
//            {
//                int row = matrix.GetLength(0);

//                int col = matrix.GetLength(1);

//                int low = 0;

//                int high = row * col - 1;

//                while (low <= high)

//                {

//                    int mid = low + (high - low) / 2;

//                    int r = mid / col;
//                    int c = mid % col;

//                    if (matrix[r, c] == target)
//                        return true;
//                    else if (matrix[r, c] < target)
//                        low = mid + 1;
//                    else
//                        high = mid - 1;
//                }

//                return false;

//            }
//        }
//    }
