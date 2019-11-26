using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BooksModel
    {
        public int ISBN { get; set; }
        public string title { get; set; }

        public BooksModel(int ISBN, string title)
        {
            this.ISBN = ISBN;
            this.title = title;
        }
    }

    public class BooksModelBorrowed
    { 
    public int ISBN { get; set; }
    public string title { get; set; }
    public string borrower { get; set; }
        public BooksModelBorrowed(int ISBN, string title, string borrower)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.borrower = borrower;
        }
    }
}