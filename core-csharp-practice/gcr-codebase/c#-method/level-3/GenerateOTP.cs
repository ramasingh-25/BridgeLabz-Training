//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//     class GenerateOTP
//    {
    
//          static string GenerateOtp()

//        {
//            Random random = new Random();
//            string otp = "";

//            for (int i = 0; i < 6; i++)
//            {
//                int digit = random.Next(0, 10);
//                otp += digit.ToString();
//            }
//            return otp;
//        }
//            static bool AreOTPUnique(string[] otpArray)
//            {
//                for (int i = 0; i < otpArray.Length; i++)
//                {
//                    for (int j = i + 1; j < otpArray.Length; j++)
//                    {
//                        if (otpArray[i] == otpArray[j])
//                        {
//                            return false;
//                        }
//                    }
//                }
//                return true;
//            }

//            static void Main()
//            {
//                string[] otpArray = new string[10];

//                Console.WriteLine("Generating 10 OTP numbers:\n");

//                for (int i = 0; i < 10; i++)
//                {
//                    otpArray[i] = GenerateOtp();
//                    Console.WriteLine("OTP " + (i + 1) + ": " + otpArray[i]);


//                    System.Threading.Thread.Sleep(10);
//                }

//                Console.WriteLine("");
//                bool isUnique = AreOTPUnique(otpArray);

//                if (isUnique)
//                {
//                    Console.WriteLine("Result: All OTPs are UNIQUE");
//                }
//                else
//                {
//                    Console.WriteLine("Result: Some OTPs are DUPLICATE");
//                }

//                Console.ReadLine();
//            }
//        }

//    }

