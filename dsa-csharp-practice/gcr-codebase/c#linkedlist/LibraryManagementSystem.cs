//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.LinkedList
//{
//     class LibraryManagementSystem
//    {
//        // Node class for doubly linked list
//        private class BookEntry
//        {
//            public int Id;
//            public string BookName;
//            public string Writer;
//            public string Category;
//            public bool AvailableForIssue;
//            public BookEntry Previous;
//            public BookEntry Next;

//            public BookEntry(int bookId, string name, string author, string genre, bool canIssue)
//            {
//                Id = bookId;
//                BookName = name;
//                Writer = author;
//                Category = genre;
//                AvailableForIssue = canIssue;
//                Previous = null;
//                Next = null;
//            }
//        }

//        private class LibraryCollection
//        {
//            private BookEntry firstBook;
//            private BookEntry lastBook;

//            // Insert at start
//            public void InsertFirst(int id, string name, string author, string genre, bool available)
//            {
//                BookEntry newEntry = new BookEntry(id, name, author, genre, available);

//                if (firstBook == null)
//                {
//                    firstBook = lastBook = newEntry;
//                }
//                else
//                {
//                    newEntry.Next = firstBook;
//                    firstBook.Previous = newEntry;
//                    firstBook = newEntry;
//                }
//            }

//            // Insert at end
//            public void InsertLast(int id, string name, string author, string genre, bool available)
//            {
//                BookEntry newEntry = new BookEntry(id, name, author, genre, available);

//                if (lastBook == null)
//                {
//                    firstBook = lastBook = newEntry;
//                }
//                else
//                {
//                    lastBook.Next = newEntry;
//                    newEntry.Previous = lastBook;
//                    lastBook = newEntry;
//                }
//            }

//            // Insert at specific position (1-based index)
//            public void InsertAt(int pos, int id, string name, string author, string genre, bool available)
//            {
//                if (pos <= 1 || firstBook == null)
//                {
//                    InsertFirst(id, name, author, genre, available);
//                    return;
//                }

//                BookEntry current = firstBook;
//                int currentPos = 1;

//                while (currentPos < pos - 1 && current.Next != null)
//                {
//                    current = current.Next;
//                    currentPos++;
//                }

//                if (current.Next == null)
//                {
//                    InsertLast(id, name, author, genre, available);
//                    return;
//                }

//                BookEntry newEntry = new BookEntry(id, name, author, genre, available);
//                newEntry.Next = current.Next;
//                newEntry.Previous = current;
//                current.Next.Previous = newEntry;
//                current.Next = newEntry;
//            }

//            // Delete book by ID
//            public void DeleteBook(int bookId)
//            {
//                BookEntry current = firstBook;

//                while (current != null)
//                {
//                    if (current.Id == bookId)
//                    {
//                        // Adjust links
//                        if (current == firstBook)
//                            firstBook = current.Next;

//                        if (current == lastBook)
//                            lastBook = current.Previous;

//                        if (current.Previous != null)
//                            current.Previous.Next = current.Next;

//                        if (current.Next != null)
//                            current.Next.Previous = current.Previous;

//                        Console.WriteLine($"→ Book (ID: {bookId}) has been removed.");
//                        return;
//                    }
//                    current = current.Next;
//                }

//                Console.WriteLine("No book found with given ID.");
//            }

//            // Search by book title
//            public void FindByName(string bookName)
//            {
//                BookEntry current = firstBook;
//                bool foundAny = false;

//                while (current != null)
//                {
//                    if (current.BookName.Equals(bookName, StringComparison.OrdinalIgnoreCase))
//                    {
//                        ShowBookDetails(current);
//                        foundAny = true;
//                    }
//                    current = current.Next;
//                }

//                if (!foundAny)
//                    Console.WriteLine("→ No books matched the given title.");
//            }

//            // Search by author
//            public void FindByWriter(string writerName)
//            {
//                BookEntry current = firstBook;
//                bool foundAny = false;

//                while (current != null)
//                {
//                    if (current.Writer.Equals(writerName, StringComparison.OrdinalIgnoreCase))
//                    {
//                        ShowBookDetails(current);
//                        foundAny = true;
//                    }
//                    current = current.Next;
//                }

//                if (!foundAny)
//                    Console.WriteLine("→ No books found by this author.");
//            }

//            // Change availability status
//            public void ChangeStatus(int bookId, bool isAvailable)
//            {
//                BookEntry current = firstBook;

//                while (current != null)
//                {
//                    if (current.Id == bookId)
//                    {
//                        current.AvailableForIssue = isAvailable;
//                        Console.WriteLine($"→ Status of book (ID: {bookId}) updated successfully.");
//                        return;
//                    }
//                    current = current.Next;
//                }

//                Console.WriteLine("→ Book not found.");
//            }

//            // Show books from first to last
//            public void ShowAllForward()
//            {
//                if (firstBook == null)
//                {
//                    Console.WriteLine("→ Library collection is currently empty.");
//                    return;
//                }

//                Console.WriteLine("Books in collection (forward):");
//                BookEntry current = firstBook;
//                while (current != null)
//                {
//                    ShowBookDetails(current);
//                    current = current.Next;
//                }
//            }

//            // Show books from last to first
//            public void ShowAllBackward()
//            {
//                if (lastBook == null)
//                {
//                    Console.WriteLine("→ Library collection is currently empty.");
//                    return;
//                }

//                Console.WriteLine("Books in collection (reverse):");
//                BookEntry current = lastBook;
//                while (current != null)
//                {
//                    ShowBookDetails(current);
//                    current = current.Previous;
//                }
//            }

//            // Total count of books
//            public void GetTotalCount()
//            {
//                int total = 0;
//                BookEntry current = firstBook;
//                while (current != null)
//                {
//                    total++;
//                    current = current.Next;
//                }
//                Console.WriteLine($"Total books in library: {total}");
//            }

//            // Helper method to display book info
//            private void ShowBookDetails(BookEntry book)
//            {
//                string statusText = book.AvailableForIssue ? "Available" : "Issued Out";
//                Console.WriteLine($"  ID: {book.Id} | \"{book.BookName}\" by {book.Writer} | {book.Category} | {statusText}");
//            }
//        }

//        // ───────────────────────────────────────────────────────────────
//        public static void Main(string[] args)
//        {
//            LibraryCollection lib = new LibraryCollection();

//            // Adding some sample books
//            lib.InsertLast(101, "Godan", "Munshi Premchand", "Novel", true);
//            lib.InsertFirst(103, "Raag Darbari", "Shrilal Shukla", "Satire", true);
//            lib.InsertAt(2, 102, "Pinjar", "Amrita Pritam", "Historical", false);

//            Console.WriteLine("\n=== Current Collection (Forward) ===");
//            lib.ShowAllForward();

//            Console.WriteLine("\n=== Current Collection (Reverse) ===");
//            lib.ShowAllBackward();

//            Console.WriteLine("\nSearching for author...");
//            lib.FindByWriter("Munshi Premchand");

//            Console.WriteLine("\nChanging book status...");
//            lib.ChangeStatus(101, false);

//            Console.WriteLine("\nRemoving one book...");
//            lib.DeleteBook(102);

//            Console.WriteLine("\n=== Final Collection ===");
//            lib.ShowAllForward();

//            Console.WriteLine();
//            lib.GetTotalCount();

//            Console.WriteLine("\nPress any key to exit...");
//            Console.ReadKey();
//        }
//    }
//}
