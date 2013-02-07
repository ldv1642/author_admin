<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorAdmin.aspx.cs" Inherits="AuthorsDB.AuthorAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        input[type=text] {
            display:block
                ;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <section id="controls">
                <asp:label runat="server">Select and author:</asp:label>
                <asp:dropdownlist runat="server" id="authors" autopostback="true" onselectedindexchanged="Author_Changed">
                </asp:dropdownlist>
            </section>

            <section id="display">
                <asp:label runat="server">ID</asp:label>
                <asp:textbox runat="server" id="tbxID"></asp:textbox>
                <asp:label id="Label1" runat="server">First Name</asp:label>
                <asp:textbox runat="server" id="tbxFirstName"></asp:textbox>
                <asp:label id="Label2" runat="server">Last Name</asp:label>
                <asp:textbox runat="server" id="tbxLastName"></asp:textbox>
            </section>
        </div>
    </form>
</body>
</html>
