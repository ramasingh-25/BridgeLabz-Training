//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.ScenarioBased
//{
//    class ParagraphAnalyzer
//    {
       
//            public static int CountingWords(String st)
//            {
//                int count = 0;
//                for (int i = 1; i < st.Length - 1; i++)
//                {
//                    if ((st[i] == ' ' && st[i - 1] != ' ') && (st[i] == ' ' && st[i + 1] != ' '))
//                    {
//                        count++;
//                    }
//                }
//                return count + 1;
//            }

//            public static String LongestWord(String st)
//            {
//                StringBuilder temp = new StringBuilder();
//                StringBuilder longest = new StringBuilder();

//                int longestLength = 0;

//                for (int i = 0; i < st.Length; i++)
//                {
//                    if (st[i] == ' ' || st[i] == ',' || st[i] == ';')
//                    {
//                        if (temp.Length >= longest.Length)
//                        {
//                            longest.Clear();
//                            longest.Append(temp);
//                        }
//                        temp.Clear();
//                    }

//                    else
//                    {
//                        temp.Append(st[i]);
//                    }


//                }
//                return longest.ToString();
//            }

//            public static String WordReplace(String st, String word, String change)
//            {
//                StringBuilder temp = new StringBuilder();
//                StringBuilder result = new StringBuilder();

//                for (int i = 0; i < st.Length; i++)
//                {
//                    if (st[i] == ' ' || st[i] == '.' || st[i] == ';' || st[i] == '?' || st[i] == ',' || st[i] == '}' || st[i] == ']' || st[i] == '-' || st[i] == ')')
//                    {
//                        if (word == temp.ToString())
//                        {

//                            result.Append(change);
//                            result.Append(st[i]);
//                            temp.Clear();
//                        }
//                        else
//                        {

//                            result.Append(temp);
//                            result.Append(st[i]);
//                            temp.Clear();
//                        }
//                    }

//                    else
//                    {
//                        temp.Append(st[i]);
//                    }

//                }
//                return result.ToString();
//            }

//            public static void DisplayingContent()
//            {
               
//                Console.WriteLine("      Welcome to the Paragraph Analyzer       ");

//                Console.Write("Enter the string to analyze: ");
//                String st = Console.ReadLine();

//                bool exit = false;

//                while (!exit)
//                {
//                    Console.WriteLine($"CURRENT STRING: \"{st}\"");
//                    Console.WriteLine("1. Count Words");
//                    Console.WriteLine("2. Find Longest Word");
//                    Console.WriteLine("3. Find and Replace a Word");
//                    Console.WriteLine("4. Enter New String");
//                    Console.WriteLine("5. Exit");
//                    Console.Write("Select an option (1-5): ");

//                    String option = Console.ReadLine();

//                    switch (option)
//                    {
//                        case "1":
//                            int count = CountingWords(st);
//                            Console.WriteLine($"\n[Result] Total Words: {count}");
//                            break;

//                        case "2":
//                            String longest = LongestWord(st);
//                            Console.WriteLine($"\n[Result] Longest Word: \"{longest}\"");
//                            break;

//                        case "3":
//                            Console.WriteLine("Enter the word to find: ");
//                            String find = Console.ReadLine();

//                            Console.Write("Enter the word to replace it with: ");
//                            String replace = Console.ReadLine();

//                            String replacedString = WordReplace(st, find, replace);
//                            Console.WriteLine($"\n[Result] Updated String: \"{replacedString}\"");


//                            break;

//                        case "4":
//                            Console.Write("\nEnter new string: ");
//                            st = Console.ReadLine();
//                            Console.WriteLine("String updated.");
//                            break;

//                        case "5":
//                            exit = true;
//                            Console.WriteLine("Exiting... Goodbye!");
//                            break;

//                        default:
//                            Console.WriteLine("Invalid choice! Please try again.");
//                            break;
//                    }
//                }
//            }

//            public static void Main(String[] args)
//            {

//                DisplayingContent();


//            }
//        }
//    }
