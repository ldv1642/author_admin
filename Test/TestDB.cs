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
        public void InsertAuthorGetAuthorUpdateAuthorDeleteAuthor()
        {
            //todo: if any of these actions fail, how would I rollback? currently atm I'm removing any changes manually.

            //add a user
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
            //get it
            var author = DBAccess.GetAuthor(result);
            //change it
            string newName = "Daniel";
            author.FirstName = newName;
            DBAccess.UpdateAuthor(author);
            //retrieve and compare
            string resultName = DBAccess.GetAuthor(result).FirstName;
            //delete
            DBAccess.DeleteAuthor(result);
            
            Assert.AreEqual(newName, resultName);
        }
    }
}
