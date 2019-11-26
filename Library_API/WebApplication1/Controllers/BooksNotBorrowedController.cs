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
    public class BooksNotBorrowedController : ApiController
    {
        // GET: api/BooksNotBorrowed
        public IEnumerable<BooksModel> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<BooksModel> output = new List<BooksModel>();

            try
            {
                conn.Open();
                query = "select * from Books where borrower is null";
                cmd = new SqlCommand(query, conn);

                //read the data for that command
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output.Add(new BooksModel(Int32.Parse(rdr["ISBN"].ToString()),
                                                rdr["title"].ToString()));

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

        // GET: api/BooksNotBorrowed/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BooksNotBorrowed
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BooksNotBorrowed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BooksNotBorrowed/5
        public void Delete(int id)
        {
        }
    }
}
