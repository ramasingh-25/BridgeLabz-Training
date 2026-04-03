//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace project1.ScenarioBased
//{
//  class SnakeAndLadder
    
//    {
       
//            public static int Apply(int p, int[] s, int[] e)
//            {
//                for (int i = 0; i < s.Length; i++)
//                {
//                    if (p == s[i])
//                    {
//                        p = e[i];
//                        break;
//                    }

//                }
//                return p;
//            }
//            //main method
//            public static void Main(String[] args)
//            {
//                Console.WriteLine("Enter the number of players(2-4)");
//                int pc = int.Parse(Console.ReadLine());
//                if (pc < 2 || pc > 4)
//                {
//                    Console.WriteLine("No of players are invalid input in range of 2-4");
//                    return;
//                }
//                string[] player = new string[pc];
//                int[] pos = new int[pc];
//                for (int i = 0; i < pc; i++)
//                {
//                    Console.WriteLine("Enter the name of the player");
//                    player[i] = Console.ReadLine();
//                    pos[i] = 0;
//                }
//                int[] x = { 5, 10, 16, 24, 26, 50, 55, 34, 19, 60, 91, 24, 73, 75, 78 };
//                int[] y = { 13, 33, 71, 36, 88, 59, 67, 54, 62, 64, 71, 87, 93, 95, 99,  };
//                bool gameover = false;
//                while (!gameover)
//                {
//                    for (int i = 0; i < pc; i++)
//                    {
//                        bool extra = true;

//                        while (extra)
//                        {
//                            extra = false;
//                            Console.WriteLine();
//                            Console.WriteLine(player[i] + "turn  to roll the dice");
//                            Console.WriteLine("press enter to roll a dice");
//                            Console.ReadLine();
//                            int dice = new Random().Next(1, 7);
//                            int oldpos = pos[i];
//                            int newpos = oldpos + dice;
//                            Console.WriteLine("Dice rolled" + dice);
//                            if (newpos > 100)
//                            {
//                                Console.WriteLine("your chance is skipped cause u roll more than 100");

//                            }
//                            else
//                            {
//                                pos[i] = newpos;
//                                int before = pos[i];
//                                pos[i] = Apply(pos[i], x, y);
//                                if (before < pos[i])
//                                {
//                                    Console.WriteLine("yooo u climb the ladder nice!!");
//                                }
//                                else if (before > pos[i])
//                                {
//                                    Console.WriteLine("Brooooo snake bite's u ");
//                                }
//                                Console.WriteLine("old position" + oldpos + "->" + pos[i]);
//                                if (pos[i] == 100)
//                                {
//                                    Console.WriteLine("cong... " + player[i] + " Wins");
//                                    gameover = true;
//                                    break;
//                                }

//                            }
//                            if (dice == 6 && !gameover)
//                            {
//                                Console.WriteLine("Yoo you get an extra chance for rolling 6");
//                                extra = true;



//                            }
//                        }
//                        if (gameover)
//                        {
//                            break;
//                        }

//                    }


//                }
//            }
//        }
//    }
