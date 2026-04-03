//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//     class OperationOfMatrix
//    {


//        static double[,] TransposeMatrix(double[,] matrix)
//        {
//            int rows = matrix.GetLength(0);
//            int columns = matrix.GetLength(1);
//            double[,] transpose = new double[columns, rows];

//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < columns; j++)
//                {
//                    transpose[j, i] = matrix[i, j];
//                }
//            }

//            return transpose;
//        }





//        static double Determinant2x2(double[,] matrix)
//        {
            




//            double a = matrix[0, 0];
//            double b = matrix[0, 1];
//            double c = matrix[1, 0];
//            double d = matrix[1, 1];

//            double determinant = (a * d) - (b * c);
//            return determinant;
//        }


//        static double Determinant3x3(double[,] matrix)
//        {
//            // For 3x3 matrix: det = a(ei - fh) - b(di - fg) + c(dh - eg)
//            // | a  b  c |
//            // | d  e  f |
//            // | g  h  i |
//            double a = matrix[0, 0];
//            double b = matrix[0, 1];
//            double c = matrix[0, 2];
//            double d = matrix[1, 0];
//            double e = matrix[1, 1];
//            double f = matrix[1, 2];
//            double g = matrix[2, 0];
//            double h = matrix[2, 1];
//            double i = matrix[2, 2];

//            double determinant = a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);
//            return determinant;
//        }


//        static double[,] Inverse2x2(double[,] matrix) //inverse of a 2x2 matrix
//        {
//            double det = Determinant2x2(matrix);


//            if (Math.Abs(det) < 0.0001)
//            {
//                Console.WriteLine("Matrix is not invertible (determinant is zero)");
//                return null;
//            }

//            // For 2x2 matrix inverse: (1/det) * | d  -b |
//            //                                    | -c   a |
//            double[,] inverse = new double[2, 2];
//            double a = matrix[0, 0];
//            double b = matrix[0, 1];
//            double c = matrix[1, 0];
//            double d = matrix[1, 1];

//            inverse[0, 0] = d / det;
//            inverse[0, 1] = -b / det;
//            inverse[1, 0] = -c / det;
//            return inverse;
//        }

//        // Method to find the inverse of a 3x3 matrix
//        static double[,] Inverse3x3(double[,] matrix)
//        {
//            double det = Determinant3x3(matrix);

//            // Check if determinant is zero (matrix is not invertible)
//            if (Math.Abs(det) < 0.0001)
//            {
//                Console.WriteLine("Matrix is not invertible (determinant is zero)");
//                return null;
//            }

//            double[,] inverse = new double[3, 3];

            
//            double a = matrix[0, 0], b = matrix[0, 1], c = matrix[0, 2];
//            double d = matrix[1, 0], e = matrix[1, 1], f = matrix[1, 2];
//            double g = matrix[2, 0], h = matrix[2, 1], i = matrix[2, 2];

            
//            inverse[0, 0] = (e * i - f * h) / det;
//            inverse[0, 1] = (c * h - b * i) / det;
//            inverse[0, 2] = (b * f - c * e) / det;

//            inverse[1, 0] = (f * g - d * i) / det;
//            inverse[1, 1] = (a * i - c * g) / det;
//            inverse[1, 2] = (c * d - a * f) / det;

//            inverse[2, 0] = (d * h - e * g) / det;
//            inverse[2, 1] = (b * g - a * h) / det;
//            inverse[2, 2] = (a * e - b * d) / det;

//            return inverse;
//        }


//        static void DisplayMatrix(double[,] matrix) 
//        {
//            int rows = matrix.GetLength(0);
//            int columns = matrix.GetLength(1);

//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < columns; j++)
//                {
//                    Console.Write("{0,8:F2}\t", matrix[i, j]);
//                }
//                Console.WriteLine();
//            }
//        }
        
//    static void Main()
//        {
//            Console.WriteLine("=== Matrix Manipulation Program ===");
//            Console.WriteLine();


//            Console.WriteLine("--- Operations with 2x2 Matrices ---");//2x2 matrices
//            double[,] matrix1 = CreateRandomMatrix(2, 2);
//            double[,] matrix2 = CreateRandomMatrix(2, 2);
//            Console.WriteLine("Matrix 1:");
//            DisplayMatrix(matrix1);
//            Console.WriteLine("\nMatrix 2:");
//            DisplayMatrix(matrix2);


//            Console.WriteLine("\nAddition (Matrix 1 + Matrix 2):");
//            double[,] addResult = AddMatrices(matrix1, matrix2);
//            DisplayMatrix(addResult);
//            Console.WriteLine("\nSubtraction (Matrix 1 - Matrix 2):");
//            double[,] subResult = SubtractMatrices(matrix1, matrix2);
//            DisplayMatrix(subResult);
//            Console.WriteLine("\nMultiplication (Matrix 1 × Matrix 2):");
//            double[,] mulResult = MultiplyMatrices(matrix1, matrix2);
//            DisplayMatrix(mulResult);
//            Console.WriteLine("\nTranspose of Matrix 1:");
//            double[,] transposeResult = TransposeMatrix(matrix1);
//            DisplayMatrix(transposeResult);


//            Console.WriteLine("\nDeterminant of Matrix 1 (2x2):");
//            double det2x2 = Determinant2x2(matrix1);
//            Console.WriteLine(det2x2);


//            Console.WriteLine("\nInverse of Matrix 1 (2x2):");
            
//            double[,] inverse2x2 = Inverse2x2(matrix1);
//            if (inverse2x2 != null)
//            {
//                DisplayMatrix(inverse2x2);
//            }


//            Console.WriteLine("\n--- Operations with 3x3 Matrices ---");
//            double[,] matrix3x3 = CreateRandomMatrix(3, 3);

//            Console.WriteLine("Matrix 3x3:");
//            DisplayMatrix(matrix3x3);


//            Console.WriteLine("\nDeterminant of 3x3 Matrix:");
//            double det3x3 = Determinant3x3(matrix3x3);
//            Console.WriteLine(det3x3);


//            Console.WriteLine("\nInverse of 3x3 Matrix:");
//            double[,] inverse3x3 = Inverse3x3(matrix3x3);
//            if (inverse3x3 != null)
//            {
//                DisplayMatrix(inverse3x3);
//            }
//        }


//        static double[,] CreateRandomMatrix(int rows, int columns)
//        {
//            double[,] matrix = new double[rows, columns];
//            Random random = new Random();

//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < columns; j++)
//                {

//                    matrix[i, j] = random.Next(1, 11);
//                }
//            }

//            return matrix;
//        }


//        static double[,] AddMatrices(double[,] matrix1, double[,] matrix2)
//        {
//            int rows = matrix1.GetLength(0);
//            int columns = matrix1.GetLength(1);
//            double[,] result = new double[rows, columns];

//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < columns; j++)
//                {
//                    result[i, j] = matrix1[i, j] + matrix2[i, j];
//                }
//            }

//            return result;
//        }


//        static double[,] SubtractMatrices(double[,] matrix1, double[,] matrix2) 
//        {
//            int rows = matrix1.GetLength(0);
//            int columns = matrix1.GetLength(1);
//            double[,] result = new double[rows, columns];

//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < columns; j++)
//                {
//                    result[i, j] = matrix1[i, j] - matrix2[i, j];
//                }
//            }

//            return result;
//        }


//        static double[,] MultiplyMatrices(double[,] matrix1, double[,] matrix2) 
//        {
//            int rows1 = matrix1.GetLength(0);
//            int columns1 = matrix1.GetLength(1);
//            int rows2 = matrix2.GetLength(0);
//            int columns2 = matrix2.GetLength(1);


//            if (columns1 != rows2)
//            {
//                Console.WriteLine("Matrix multiplication not possible!");
//                return null;
//            }

//            double[,] result = new double[rows1, columns2];

//            for (int i = 0; i < rows1; i++)
//            {
//                for (int j = 0; j < columns2; j++)
//                {
//                    double sum = 0;
//                    for (int k = 0; k < columns1; k++)
//                    {
//                        sum += matrix1[i, k] * matrix2[k, j];
//                    }
//                    result[i, j] = sum;
//                }
//            }

//            return result;
//        }


//    } }



