using System;
using System.Collections.Generic;
using System.Linq;

namespace card_catalog
{
    class Program
    {
        static void Main(string[] args)
        {
            var lib = new Library();
            var something = new Book
            {
                BookName = "The Death of Ivan Ilyich",
                Author = "Tolstoy",
                PublishedDate = new DateTime(1886,1,1),
                IsCheckedOut = false,
                DueDate = DateTime.Now.AddDays(10)
            };
            var bookTwo = new Book
            {
                BookName = "Go the Fuck to Sleep",
                Author = "Adam Mansbach",
                PublishedDate = new DateTime(2011,6,14),
                IsCheckedOut = true,
                DueDate = DateTime.Now.AddDays(-1)
            };
            lib.Catalog.Add(something);
            lib.Catalog.Add(bookTwo);
            var authorSearchList = lib.SearchByBookAuthor("Tolstoy");
            foreach (var item in authorSearchList)
            {
                Console.WriteLine("Searching by author...");
                Console.WriteLine($"{item.BookName} was written by {item.Author}.");
            }

            var bookSearchList = lib.SearchByBookName("go");
            foreach (var item in bookSearchList)
            {
                Console.WriteLine("Searching by Book Title...");
                Console.WriteLine($"{item.BookName} was written by {item.Author}.");
            }

            var Jonathan = new Member
            {
                MemberName = "Jonathan",
                MemberAddress = "6542 Sycamore St.",
                MemberEmail = "tenorjas@yahoo.com",
                MemberPhoneNumber = "555-867-5309"
            };

            lib.CheckIn("Go the Fuck to Sleep", Jonathan);
            Console.WriteLine($"Is {bookTwo.BookName} checked out? {bookTwo.IsCheckedOut}.");

            lib.CheckOut("The Death of Ivan Ilyich", Jonathan);
            Console.WriteLine($"Is {something.BookName} checked out? {something.IsCheckedOut}.");

            var overdueList = lib.SearchOverDue();
            foreach (var item in overdueList)
            {
                Console.WriteLine($"{item.BookName} is currently overdue.");
            }
            
        }
    }
}
