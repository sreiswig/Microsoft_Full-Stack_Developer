using System;
using System.Collections.Generic;

class LibraryManager
{
    static void Main()
    {
        Dictionary<string, bool> books = new Dictionary<string, bool>();
        int borrowLimit = 3;
        List<string> borrowedBooks = new List<string>();

        while (true)
        {
            Console.WriteLine("Would you like to add, remove, search, borrow, return, check-in, or exit? (add/remove/search/borrow/return/check-in/exit)");
            string action = Console.ReadLine()?.Trim().ToLower();

            if (action == "add")
            {
                if (books.Count >= 5)
                {
                    Console.WriteLine("The library is full. No more books can be added.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to add:");
                    string newBook = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(newBook))
                    {
                        if (!books.ContainsKey(newBook))
                        {
                            books.Add(newBook, false); // false indicates the book is not checked out
                            Console.WriteLine($"Book '{newBook}' added.");
                        }
                        else
                        {
                            Console.WriteLine("Book already exists.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
            }
            else if (action == "remove")
            {
                if (books.Count == 0)
                {
                    Console.WriteLine("The library is empty. No books to remove.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to remove:");
                    string removeBook = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(removeBook))
                    {
                        if (books.Remove(removeBook))
                        {
                            Console.WriteLine($"Book '{removeBook}' removed.");
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
            }
            else if (action == "search")
            {
                Console.WriteLine("Enter the title of the book to search for:");
                string searchBook = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(searchBook))
                {
                    if (books.ContainsKey(searchBook))
                    {
                        bool isBorrowed = books[searchBook];
                        Console.WriteLine($"Book '{searchBook}' is available. Checked out: {isBorrowed}");
                    }
                    else
                    {
                        Console.WriteLine($"Book '{searchBook}' is not in the collection.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else if (action == "borrow")
            {
                if (borrowedBooks.Count >= borrowLimit)
                {
                    Console.WriteLine($"You have reached the borrowing limit of {borrowLimit} books.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to borrow:");
                    string borrowBook = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(borrowBook) && books.ContainsKey(borrowBook))
                    {
                        if (!books[borrowBook])
                        {
                            books[borrowBook] = true; // mark the book as checked out
                            borrowedBooks.Add(borrowBook);
                            Console.WriteLine($"Book '{borrowBook}' borrowed.");
                        }
                        else
                        {
                            Console.WriteLine("Book is already checked out.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input or book not found.");
                    }
                }
            }
            else if (action == "return")
            {
                Console.WriteLine("Enter the title of the book to return:");
                string returnBook = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(returnBook) && books.ContainsKey(returnBook))
                {
                    if (books[returnBook])
                    {
                        books[returnBook] = false; // mark the book as not checked out
                        borrowedBooks.Remove(returnBook);
                        Console.WriteLine($"Book '{returnBook}' returned.");
                    }
                    else
                    {
                        Console.WriteLine("Book is not checked out.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input or book not found.");
                }
            }
            else if (action == "check-in")
            {
                Console.WriteLine("Enter the title of the book to check in:");
                string checkInBook = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(checkInBook) && books.ContainsKey(checkInBook))
                {
                    if (books[checkInBook])
                    {
                        books[checkInBook] = false; // mark the book as checked in
                        borrowedBooks.Remove(checkInBook);
                        Console.WriteLine($"Book '{checkInBook}' checked in.");
                    }
                    else
                    {
                        Console.WriteLine("Book is not checked out.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input or book not found.");
                }
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', 'search', 'borrow', 'return', 'check-in', or 'exit'.");
            }

            // Display the list of books
            Console.WriteLine("Available books:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Key} (Checked out: {book.Value})");
            }

            // Display the list of borrowed books
            Console.WriteLine("Borrowed books:");
            foreach (var borrowedBook in borrowedBooks)
            {
                Console.WriteLine(borrowedBook);
            }
        }
    }
}

