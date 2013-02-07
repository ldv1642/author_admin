using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using AuthorsDB;

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

        [TestCase]
        public void CanConnectToDB()
        {
            bool available = DBAccess.CheckDB();
            Assert.AreEqual(true, available);
        }
    }
}
