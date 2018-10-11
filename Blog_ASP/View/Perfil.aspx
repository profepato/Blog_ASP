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
        <div id="content">
            <div id="divBuscar">
                <form action="Perfil.aspx" method="post">
                    <input type="text" placeholder="Buscar por nick, correo o #" name="filtro"/>
                    <input type="submit" value="Buscar"/>
                </form>
            </div>

            <div id="infoUsuario">
                <div id="nombreCompletoUsuario"><%=user.GetNombreCompleto() %></div>
                <div id="nickname">@<%=user.Nickname %></div>
                <!--<div><%=user.Correo %></div>-->
                <div id="anios"><%=user.Anios %> años</div>
                <a href="../Controller/CerrarSesionHandler.ashx">Cerrar sesión</a>
            </div>

            <div id="creacionDeBlog">
                <form action="../Controller/CrearBlogHandler.ashx" method="post">
                    <input type="hidden" name="usuario" value="<%=user.Id %>"/>
                    <input id="tituloBlogCreacion" type="text" name="titulo" placeholder="Título"/>
                    <textarea id="blogCreacion" name="blog"></textarea>
                    <input id="etiquetasCreacion" type="text" name="etiquetas" placeholder="Etiquetas"/>
                    <input type="submit" value="Crear Blog" />
                </form>
            </div>

            <div id="resultadosBusqueda">
                <%
                    if (Request.Params["filtro"] != null) {
                        String filtro = Request.Params["filtro"].Trim();

                        if (!filtro.StartsWith("#")) {
                            DAO_Usuario du = new DAO_Usuario();

                            foreach (Usuario usu in du.GetUsuario(filtro)) {
                                Response.Write("<div>");
                                Response.Write("<a href=''>"+usu.GetNombreCompleto()+" (@"+usu.Nickname+")</a>");
                                Response.Write("</div>");
                            }
                        } else {
                            DAO_Blog dao_blog = new DAO_Blog();

                            foreach (Blog blog in dao_blog.ReadByTag(filtro)) {
                                Response.Write("<div>");
                                Response.Write("<a href=''>"+blog.Titulo+"</a>");
                                Response.Write("</div>");
                            }
                        }
                    }
                    %>
            </div>

            <div id="listadoBlogs">
                <% 
                    DAO_Blog db = new DAO_Blog();

                    foreach (Blog b in db.Read(user.Id)) {
                        Response.Write("<div class='blog'>");
                        Response.Write("<h1>"+b.Titulo+"</h1>");
                        Response.Write("<div class='escritoEn'>Escrito el "+b.Fecha+". <span class='nickEscritoEn'>@"+user.Nickname+"</span> dijo:</div>");
                        Response.Write("<div class='textoBlog'>");
                        Response.Write(b.Texto);
                        Response.Write("</div>");

                        Response.Write("<div class='etiquetas'>Etiquetas: ");

                        String etiquetas = "";

                        foreach (Etiqueta et in b.Etiquetas) {
                            etiquetas += "#" + et.Valor + ", ";
                        }

                        etiquetas = etiquetas.Substring(0, etiquetas.Length - 2);
                        Response.Write(etiquetas);
                        Response.Write("</div>");
                        Response.Write("</div>");
                    }
                %>
            </div>
        </div>
    </body>
</html>
