<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Blog_ASP.View.Perfil" %>
<%@ Import Namespace="Blog_ASP.Model" %>
<!DOCTYPE html>
<% 
    Usuario user = null;
    if (Session["user"] != null) {
        user = (Usuario)Session["user"];
    } else {
        Response.Redirect("Default.aspx");
    }
%>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <div>
            <h1><%=user.GetNombreCompleto() %></h1>
            <div>@<%=user.Nickname %></div>
            <div><%=user.Correo %></div>
            <a href="../Controller/CerrarSesionHandler.ashx">Cerrar sesión</a>
        </div>
        <div>
            <form action="../Controller/CrearBlogHandler.ashx" method="post">
                <input type="hidden" name="usuario" value="<%=user.Id %>"/>
                <input type="text" name="titulo" placeholder="Título"/>
                <textarea name="blog"></textarea>
                <input type="text" name="etiquetas" placeholder="Etiquetas"/>
                <input type="submit" value="Crear Blog" />
            </form>
        </div>
    </body>
</html>
