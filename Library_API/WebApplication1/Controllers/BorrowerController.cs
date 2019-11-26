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
    public class BorrowerController : ApiController
    {
        // GET: api/Borrower
        public IEnumerable<BorrowerModel> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<BorrowerModel> output = new List<BorrowerModel>();

            try
            {
                conn.Open();
                query = "select * from Borrower";
                cmd = new SqlCommand(query, conn);

                //read the data for that command
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output.Add(new BorrowerModel(Int32.Parse(rdr["id"].ToString()),
                                                rdr["surname"].ToString(),
                                                rdr["firstname"].ToString(),
                                                rdr["DOB"].ToString()));
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

        // GET: api/Borrower/5
        public IEnumerable<BooksModel> Get(int id)
        {

            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<BooksModel> output = new List<BooksModel>();
            try

            {
                conn.Open();
                query = "select * from Books where borrower = " + id;
                cmd = new SqlCommand(query, conn);
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

        // POST: api/Borrower
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Borrower/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Borrower/5
        public void Delete(int id)
        {
        }
    }
}
