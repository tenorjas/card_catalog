using System;
using System.Collections.Generic;

namespace card_catalog
{
    class Book
    {
        public string BookName {get; set;}
        public string Author {get; set;}
        public DateTime PublishedDate {get; set;}
        public bool IsCheckedOut {get; set;}

        public Member WhoCheckOut {get; set;}

        public DateTime DueDate {get; set;}

        public Book()
        {

        }
    }
}