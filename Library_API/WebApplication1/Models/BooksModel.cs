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
    public BorrowerModel borrower{ get; set; }
        public BooksModelBorrowed(int ISBN, string title, int id, string surname, string firstname, string DOB)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.borrower = new BorrowerModel(id, surname, firstname, DOB);
        }
    }

}