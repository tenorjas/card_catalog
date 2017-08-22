using System;
using System.Collections.Generic;
using System.Linq;

namespace card_catalog
{
    class Library
    {
        public string LibraryName { get; set; }
        public string LibraryAddress { get; set; }
        public List<Book> Catalog = new List<Book>();

        public IEnumerable<Book> SearchByBookName(string name)
        {
            var searched = Catalog.Where(w => w.BookName.ToLower().Contains(name.ToLower()));
            return searched;
        }

        public IEnumerable<Book> SearchByBookAuthor(string name)
        {
            var searched = Catalog.Where(w => w.Author.ToLower().Contains(name.ToLower()));
            return searched;
        }

        public IEnumerable<Book> SearchOverDue()
        {
            var searched = Catalog.Where(w => w.DueDate <= DateTime.Now);
            return searched;
        }

        public void CheckOut(string bookname, Member membername)
        {
            var searched = Catalog.FirstOrDefault(w => w.BookName == bookname);
            if (searched?.IsCheckedOut == true)
            {
                Console.WriteLine("You can't check that out.");
            }
            else
            {
                Console.WriteLine($"{membername.MemberName} is checking out {bookname}.");
                searched.IsCheckedOut = true;
            }
        }

        public void CheckIn(string bookname, Member membername)
        {
            var searched = Catalog.FirstOrDefault(w => w.BookName == bookname);
            if (searched?.IsCheckedOut == false)
            {
                Console.WriteLine("That book is already checked in.");
            }
            else
            {
                Console.WriteLine($"{membername.MemberName} is checking in {bookname}.");
                searched.IsCheckedOut = false;
            }
        }



    }
}