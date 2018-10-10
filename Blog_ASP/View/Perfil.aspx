<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Blog_ASP.View.Perfil" %>
<%@ Import Namespace="Blog_ASP.Model" %>
<%@ Import Namespace="Blog_ASP.Model.DAO" %>

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
        <link href="../css/styles.css" type="text/css" rel="stylesheet"/>
    </head>
    <body>
        <div>
            <h1><%=user.GetNombreCompleto() %></h1>
            <div>@<%=user.Nickname %></div>
            <div><%=user.Correo %></div>
            <a href="../Controller/CerrarSesionHandler.ashx">Cerrar sesión</a>
        </div>
        <div id="creacionDeBlog">
            <form action="../Controller/CrearBlogHandler.ashx" method="post">
                <input type="hidden" name="usuario" value="<%=user.Id %>"/>
                <input type="text" name="titulo" placeholder="Título"/>
                <textarea name="blog"></textarea>
                <input type="text" name="etiquetas" placeholder="Etiquetas"/>
                <input type="submit" value="Crear Blog" />
            </form>
        </div>
        <div id="listadoBlogs">
            <% 
                DAO_Blog db = new DAO_Blog();

                foreach (Blog b in db.Read(user.Id)) {
                    Response.Write("<div class='blog'>");
                        Response.Write("<h1>"+b.Titulo+"</h1>");
                        Response.Write("<div class='escritoEn'>Escrito el "+b.Fecha+". @"+user.Nickname+" dijo:</div>");
                        Response.Write("<div class='textoBlog'>");
                            Response.Write(b.Texto);
                        Response.Write("</div>");

                        Response.Write("<div class='etiquetas'>Etiquetas: ");
                        foreach (Etiqueta et in b.Etiquetas) {
                            Response.Write("#"+et.Valor+", ");
                        }
                        Response.Write("</div>");
                    Response.Write("</div>");
                }
            %>
        </div>
    </body>
</html>
