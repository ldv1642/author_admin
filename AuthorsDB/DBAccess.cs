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
            return null;
        }

        public static Author GetAuthor(string id)
        {
            return null;
        }

        public static int UpdateAuthor(Author author)
        {
            return 0;
        }

        public static int InsertAuthor(Author author)
        {
            return 0;
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

    public class Author
    {

    }
}