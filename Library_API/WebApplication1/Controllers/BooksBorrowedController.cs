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

            try
            {
                conn.Open();
                query = "select * from Books where borrower is not null";
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
                                                Int32.Parse(rdr["borrower"].ToString())));

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
