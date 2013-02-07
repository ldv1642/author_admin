<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorAdmin.aspx.cs" Inherits="AuthorsDB.AuthorAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script>

        function clearForm() {
            //clear all textboxs
            $("input[type=text]").each(function () {
                $(this).val("")
            });

            //clear checkbox
            $("input[type=checkbox]").removeAttr("checked");

            $("#tbxID").removeAttr("disabled");
        }
    </script>
    <style>
        input[type=text] {
            display:block;
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
                <input type="button" value="Clear" onclick="clearForm()" />
                <asp:button id="btnInsert" runat="server" text="Insert" onclick="btnInsert_Click" />
                <asp:button id="btnUpdate" runat="server" text="Update" onclick="btnUpdate_Click" />
                <asp:button id="btnDelete" runat="server" text="Delete" onclick="btnDelete_Click" />
            </section>

            <section id="display">
                <asp:label runat="server">ID</asp:label>
                <asp:textbox runat="server" id="tbxID"></asp:textbox>
                <asp:label id="Label1" runat="server">First Name</asp:label>
                <asp:textbox runat="server" id="tbxFirstName"></asp:textbox>
                <asp:label id="Label2" runat="server">Last Name</asp:label>
                <asp:textbox runat="server" id="tbxLastName"></asp:textbox>
                <asp:label id="Label3" runat="server">Phone</asp:label>
                <asp:textbox runat="server" id="tbxPhone"></asp:textbox>
                <asp:label id="Label4" runat="server">Address</asp:label>
                <asp:textbox runat="server" id="tbxAddress"></asp:textbox>
                <asp:label id="Label5" runat="server">City</asp:label>
                <asp:textbox runat="server" id="tbxCity"></asp:textbox>
                <asp:label id="Label6" runat="server">State</asp:label>
                <asp:textbox runat="server" id="tbxState"></asp:textbox>
                <asp:label id="Label7" runat="server">Zip</asp:label>
                <asp:textbox runat="server" id="tbxZip"></asp:textbox>
                <asp:label id="Label8" runat="server">Contract</asp:label>
                <asp:checkbox runat="server" id="cbxContract" />
            </section>
            <section id="error" runat="server"></section>
        </div>
    </form>
</body>
</html>
