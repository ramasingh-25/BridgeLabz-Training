//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.LinkedList
//{
//    public class DoublyLinkedList
//    {
//        class MovieNode
//        {
//            public string Title;
//            public string Director;
//            public int Year;
//            public double Rating;
//            public MovieNode Prev;
//            public MovieNode Next;

//            //constructor
//            public MovieNode(string title, string director, int year, double rating)
//            {
//                this.Title = title;
//                this.Director = director;
//                this.Year = year;
//                this.Rating = rating;
//                this.Prev = null;
//                Next = null;
//            }
//        }

//        //class movielist
//        //Add a movie record at the beginning, end, or at a specific position.
//        class MovieList
//        {
//            private MovieNode head;
//            private MovieNode tail;


//            public void AddAtBeginning(string title, string director, int year, double rating)
//            {
//                MovieNode newNode = new MovieNode(title, director, year, rating);

//                if (head == null)
//                {
//                    head = tail = newNode;
//                }
//                else
//                {
//                    newNode.Next = head;
//                    head.Prev = newNode;
//                    head = newNode;
//                }
//            }



//            public void AddAtEnd(string title, string director, int year, double rating)
//            {
//                MovieNode newNode = new MovieNode(title, director, year, rating);

//                if (tail == null)
//                {
//                    head = tail = newNode;
//                }
//                else
//                {
//                    tail.Next = newNode;
//                    newNode.Prev = tail;
//                    tail = newNode;
//                }
//            }



//            public void AddAtPosition(int position, string title, string director, int year, double rating)
//            {
//                if (position <= 1)
//                {
//                    AddAtBeginning(title, director, year, rating);
//                    return;
//                }

//                MovieNode temp = head;
//                for (int i = 1; i < position - 1 && temp != null; i++)
//                {
//                    temp = temp.Next;
//                }

//                if (temp == null || temp.Next == null)
//                {
//                    AddAtEnd(title, director, year, rating);
//                    return;
//                }

//                MovieNode newNode = new MovieNode(title, director, year, rating);
//                newNode.Next = temp.Next;
//                newNode.Prev = temp;
//                temp.Next.Prev = newNode;
//                temp.Next = newNode;
//            }


//            //Remove a movie record by Movie Title.
//            public void RemoveByTitle(string title)
//            {
//                MovieNode temp = head;

//                while (temp != null)
//                {
//                    if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
//                    {
//                        if (temp == head)
//                            head = temp.Next;

//                        if (temp == tail)
//                            tail = temp.Prev;

//                        if (temp.Prev != null)
//                            temp.Prev.Next = temp.Next;

//                        if (temp.Next != null)
//                            temp.Next.Prev = temp.Prev;

//                        Console.WriteLine("Movie removed successfully.");
//                        return;
//                    }
//                    temp = temp.Next;
//                }

//                Console.WriteLine("Movie not found.");
//            }


//            //Search for a movie record by Director or Rating
//            public void SearchByDirector(string director)
//            {
//                MovieNode temp = head;
//                bool found = false;

//                while (temp != null)
//                {
//                    if (temp.Director.Equals(director, StringComparison.OrdinalIgnoreCase))
//                    {
//                        DisplayMovie(temp);
//                        found = true;
//                    }
//                    temp = temp.Next;
//                }

//                if (!found)
//                    Console.WriteLine("No movies found for this director.");
//            }



//            public void SearchByRating(double rating)
//            {
//                MovieNode temp = head;
//                bool found = false;

//                while (temp != null)
//                {
//                    if (temp.Rating == rating)
//                    {
//                        DisplayMovie(temp);
//                        found = true;
//                    }
//                    temp = temp.Next;
//                }

//                if (!found)
//                    Console.WriteLine("No movies found with this rating.");
//            }


//            //Update a movie's Rating based on the Movie Title.
//            public void UpdateRating(string title, double newRating)
//            {
//                MovieNode temp = head;

//                while (temp != null)
//                {
//                    if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
//                    {
//                        temp.Rating = newRating;
//                        Console.WriteLine("Rating updated successfully.");
//                        return;
//                    }
//                    temp = temp.Next;
//                }

//                Console.WriteLine("Movie not found.");
//            }



//            //Display all movie records in forward order.
//            public void DisplayForward()
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("No movie records available.");
//                    return;
//                }

//                MovieNode temp = head;
//                while (temp != null)
//                {
//                    DisplayMovie(temp);
//                    temp = temp.Next;
//                }
//            }



//            //Display all movie records in reverse order.
//            public void DisplayReverse()
//            {
//                if (tail == null)
//                {
//                    Console.WriteLine("No movie records available.");
//                    return;
//                }

//                MovieNode temp = tail;
//                while (temp != null)
//                {
//                    DisplayMovie(temp);
//                    temp = temp.Prev;
//                }
//            }

//            private void DisplayMovie(MovieNode movie)
//            {
//                Console.WriteLine($"Title: {movie.Title}, Director: {movie.Director}, Year: {movie.Year}, Rating: {movie.Rating}");
//            }
//        }


//        //Main class
        
//            //Main Method
//            public static void Main(string[] args)
//            {
//                MovieList movies = new MovieList();

//                movies.AddAtEnd("Harry Potter", "Rama Singh", 2010, 8.0);
//                movies.AddAtBeginning("Money Heist", "Chitra Singh", 2019, 7.8);
//                movies.AddAtPosition(2, "Lucifer", "Swati Singh", 2006, 7.5);

//                Console.WriteLine("Movies in Forward order:");
//                movies.DisplayForward();
//                Console.WriteLine();

//                Console.WriteLine("Movies in Reverse order:");
//                movies.DisplayReverse();
//                Console.WriteLine();

//                Console.WriteLine("Search by Director:");
//                movies.SearchByDirector("Chitra");
//                Console.WriteLine();

//                Console.WriteLine("Update Rating:");
//                movies.UpdateRating("Lucifer", 10.0);
//                Console.WriteLine();

//                Console.WriteLine("Remove Movie:");
//                movies.RemoveByTitle("Inception");
//                Console.WriteLine();

//                Console.WriteLine("Final Movie List:");
//                movies.DisplayForward();
//            }
//        }
//    }



