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
                try
                {
                    var result = DBAccess.GetAuthors();
                    foreach (Author a in result)
                    {
                        authors.Items.Add(
                            new ListItem(a.FirstName + " " + a.LastName, a.AuthorID));
                    }
                }
                catch (Exception ex)
                {
                    error.InnerHtml = ex.Message;
                }

                //show any status
                string msg;
                if (!string.IsNullOrEmpty(msg = Request.QueryString["s"]))
                {
                    error.InnerHtml = msg;
                }
            }
            else
            {
                error.InnerHtml = "";
            }
        }

        protected void Author_Changed(object sender, EventArgs e)
        {
            tbxID.Enabled = false;
            try
            {
                var author = DBAccess.GetAuthor(authors.SelectedValue);
                displayAuthor(author);
            }
            catch (Exception ex)
            {
                error.InnerHtml = ex.Message;
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            tbxID.Enabled = true;
            try
            {
                Author author = parseForm();
                DBAccess.InsertAuthor(author);
                redirectWithStatus("Insert successful.");
            }
            catch (Exception ex)
            {
                error.InnerHtml = ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Author author = parseForm();
                DBAccess.UpdateAuthor(author);
                redirectWithStatus("Update successful.");
            }
            catch (Exception ex)
            {
                error.InnerHtml = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Author author = parseForm();
                DBAccess.DeleteAuthor(author.AuthorID);
                redirectWithStatus("Delete successful.");
            }
            catch (Exception ex)
            {
                error.InnerHtml = ex.Message;
            }
        }

        void displayAuthor(Author author)
        {
            tbxID.Text = author.AuthorID;
            tbxFirstName.Text = author.FirstName;
            tbxLastName.Text = author.LastName;
            tbxPhone.Text = author.Phone;
            tbxAddress.Text = author.Address;
            tbxCity.Text = author.City;
            tbxState.Text = author.State;
            tbxZip.Text = author.Zip;
            cbxContract.Checked = (author.Contract == true ? true : false);
        }

        Author parseForm()
        {
            Author author = new Author()
            {
                AuthorID = tbxID.Text,
                FirstName = tbxFirstName.Text,
                LastName = tbxLastName.Text,
                Phone = tbxPhone.Text,
                Address = tbxAddress.Text,
                City = tbxCity.Text,
                State = tbxState.Text,
                Zip = tbxZip.Text,
                Contract = cbxContract.Checked
            };

            return author;
        }

        void redirectWithStatus(string msg)
        {
            Response.Redirect("/AuthorAdmin.aspx?s=" + msg);
        }
    }
}