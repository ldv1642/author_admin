using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthorsDB
{
    public partial class AuthorAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var result = DBAccess.GetAuthors();
                foreach (Author a in result)
                { 
                    authors.Items.Add(
                        new ListItem(a.FirstName + " " + a.LastName,a.AuthorID));
                }
            }
        }

        protected void Author_Changed(object sender, EventArgs e)
        {
            var author = DBAccess.GetAuthor(authors.SelectedValue);
            displayAuthor(author);
        }

        void displayAuthor(Author author)
        {
            tbxID.Text = author.AuthorID;
            tbxFirstName.Text = author.FirstName;
            tbxLastName.Text = author.LastName;
        }
    }
}