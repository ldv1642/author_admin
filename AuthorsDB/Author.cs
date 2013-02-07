using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorsDB
{
    public class Author
    {
        public string AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool? Contract { get; set; } //extract from db using GetBoolean
    }
}