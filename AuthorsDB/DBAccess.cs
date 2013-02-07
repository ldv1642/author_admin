using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;


namespace AuthorsDB
{
    public class DBAccess
    {
        static string connString = WebConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public static List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
   
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "GetAuthors";

                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        authors.Add(
                            new Author()
                            {
                                AuthorID=reader["au_id"] as string,
                                FirstName= reader["au_fname"] as string,
                                LastName = reader["au_lname"] as string,
                                Phone = reader["phone"] as string,
                                Address = reader["address"] as string,
                                City = reader["city"] as string,
                                State = reader["State"] as string,
                                Zip = reader["zip"] as string,
                                Contract = reader["contract"] as bool?
                            });
                    }
                    conn.Close();
                }
            }

            return authors;
        }

        public static Author GetAuthor(string id)
        {
            Author author = new Author();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "GetAuthor";
                    comm.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        author.AuthorID = reader["au_id"] as string;
                        author.FirstName = reader["au_fname"] as string;
                        author.LastName = reader["au_lname"] as string;
                        author.Phone = reader["phone"] as string;
                        author.Address = reader["address"] as string;
                        author.City = reader["city"] as string;
                        author.State = reader["State"] as string;
                        author.Zip = reader["zip"] as string;
                        author.Contract = reader["contract"] as bool?;
                    }
                    conn.Close();
                }
            }

            return author;
        }
        
        public static int GetAuthorCount()
        {
            int count;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "GetAuthorCount";

                    conn.Open();
                    var reader = comm.ExecuteReader();
                    reader.Read();
                    count = (int)reader["count"];
                    conn.Close();
                }
            }

            return count;
        }

        public static int UpdateAuthor(Author author)
        {
            return 0;
        }

        public static string InsertAuthor(Author author)
        {
            string id = "";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "AddAuthor";
                    comm.Parameters.AddWithValue("@id", author.AuthorID);
                    comm.Parameters.AddWithValue("@fname", author.FirstName);
                    comm.Parameters.AddWithValue("@lname", author.LastName);
                    comm.Parameters.AddWithValue("@phone", author.Phone);
                    comm.Parameters.AddWithValue("@contract", author.Contract);
                    
                    SqlParameter p = new SqlParameter("@returnID", SqlDbType.VarChar, 11);
                    p.Direction = ParameterDirection.Output;
                    comm.Parameters.Add(p);
                    
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    id = p.Value as string;
                }
            }
            
            return id;
        }

        public static int DeleteAuthor(string id)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "DeleteAuthor";
                    comm.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    result = comm.ExecuteNonQuery();
                    conn.Close();
                }
            }

            return result;
        }

        public static bool CheckDB()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                if (!string.IsNullOrEmpty(conn.ServerVersion))
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
        }
    }
}