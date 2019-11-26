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
    public class BooksController : ApiController
    {
        // GET: api/Books
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
                query = "select * from Books";
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

        // GET: api/Books/5
    

        // POST: api/Books
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
