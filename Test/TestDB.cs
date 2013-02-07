using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using AuthorsDB;
using Moq;
using System.Data.SqlClient; //not needed
using System.Configuration;

namespace Test
{
    [TestFixture]
    public class TestDB
    {
        //access db - done
        //get all authors
        //get an author
        //update an author
        //delete an author
        //insert an author

        string connString;

        [SetUp]
        public void Init()
        {
            connString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        }

        [TestCase]
        public void CanConnectToDB()
        {
            bool available = DBAccess.CheckDB();
            Assert.AreEqual(true, available);
        }

        [TestCase]
        public void GetAllAuthors()
        { 
            //check count of return list is qual to row count
            var authors = DBAccess.GetAuthors();
            int count = DBAccess.GetAuthorCount();

            Assert.AreEqual(authors.Count, count);
        }

        [TestCase]
        public void InsertAuthorGetAuthorDeleteAuthor()
        { 
            //insert an author and use returned id to get it back
            string result = DBAccess.InsertAuthor(
                new Author()
                {
                    AuthorID = "822-52-2228",
                    FirstName = "Test First Name",
                    LastName = "Test Last Name",
                    Phone = "051 444-4444",
                    Address = "Test Address",
                    City = "Test City",
                    State = "GB",
                    Zip = "22222",
                    Contract = true
                });
            //get author
            var author = DBAccess.GetAuthor(result);
            //delete author
            DBAccess.DeleteAuthor(result);
            Assert.AreEqual(author.AuthorID,result);
        }

        [TestCase]
        public void UpdateAuthor()
        {
            Assert.Fail("Implement");
        }
    }
}
