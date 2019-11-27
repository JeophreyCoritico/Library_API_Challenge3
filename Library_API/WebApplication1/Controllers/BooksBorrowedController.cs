using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1.Controllers
{
    public class BooksBorrowedController : ApiController
    {
        // GET: api/BooksBorrowed
        public IEnumerable<BooksModelBorrowed> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<BooksModelBorrowed> output = new List<BooksModelBorrowed>();
            //List<BorrowerModel> output2 = new List<BorrowerModel>();

            try
            {
                conn.Open();

                query = "select * " +
                    "from Books " +
                    "inner join Borrower on Books.Borrower = Borrower.id " +
                    "where Books.Borrower is not null";
                //query = "select Books.ISBN, Books.title, Books.Borrower, Borrower.firstname " +
                //    "from Books" +
                //    "inner join Borrowers on Books.Borrower = Borrower.id" +
                //    "where Books.borrower is not null";
                cmd = new SqlCommand(query, conn);

                //read the data for that command
                rdr = cmd.ExecuteReader();

                //int borrowCheck = Int32.Parse(rdr["borrower"].ToString());
                //int i = Convert.ToInt32(rdr["borrower"]);
                //int borrowCheck = i ?? 0;
                //while ((rdr.Read()) || (borrowCheck.))  


                while (rdr.Read())
                {
                    output.Add(new BooksModelBorrowed(Int32.Parse(rdr["ISBN"].ToString()),
                                                rdr["title"].ToString(),
                                                Int32.Parse(rdr["id"].ToString()),
                                                rdr["surname"].ToString(),
                                                rdr["firstname"].ToString(),
                                                rdr["DOB"].ToString()));

                    //output2.Add(new BorrowerModel(Int32.Parse(rdr["id"].ToString()),
                    //                            rdr["surname"].ToString(),
                    //                            rdr["firstname"].ToString(),
                    //                            rdr["DOB"].ToString()));

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return output;
        }

        // GET: api/BooksBorrowed/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BooksBorrowed
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BooksBorrowed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BooksBorrowed/5
        public void Delete(int id)
        {
        }
    }
}
