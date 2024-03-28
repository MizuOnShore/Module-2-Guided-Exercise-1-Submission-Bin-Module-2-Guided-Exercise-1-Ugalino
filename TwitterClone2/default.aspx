<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TwitterClone2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
<%--            <asp:repeater ID="PostRepeater" runat="server">
                <ItemTemplate>
                    <div>
                        <p> <%# Eval("Content")%> </p>
                        <p> <%# Eval("PostedBy")%> </p>
                        <p> <%# Eval("PostedOn")%> </p>
                        <br />
                    </div>
                </ItemTemplate>
            </asp:repeater>--%>
            <% foreach (var post in posts) %>
            <%{%>
            <%if (post.PostedBy != "gelo")%>
            <%{%>
            <div>
                <p> <%= post.Content%> </p>
                <p> <%= post.PostedBy%> </p>
                <p> <%= post.PostedOn%> </p>
                <br />
            </div>
            <%} %>
            <%else %>
                <%{ %>
                <div>
                    <p>YOUR NOT ALLOWED TO SEE THIS POST</p>
                </div>
                <%}%>
            <%}%>
        </div>
    </form>
</body>
</html>
