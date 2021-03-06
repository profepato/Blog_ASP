﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Blog_ASP.View.Default" %>
<%@ Import Namespace="Blog_ASP.Model" %>
<!DOCTYPE html>

<%
    String nick = null;
    String mensajeError = null;

    if (Session["usuario"] != null) {
        nick = ((Usuario)Session["usuario"]).Nickname;
        Session.Clear();
    }else if (Session["mensajeError"] != null) {
        mensajeError = Session["mensajeError"].ToString();
        Session.Clear();
    }
%>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>

    <body>
        <h1>Bienvenid@s al blog!</h1>
        <form action="../Controller/IniciarSesionHandler.ashx" method="post">
            <input type="text" name="correo" placeholder="Correo ó nick:" value="<%=(nick != null ? nick:"") %>"/>
            <input type="password" name="pass" placeholder="Password"/>
            <input type="submit" value="Entrar"/>
        </form>
        <a href="Registro.aspx">Registrarse</a>
        <div>
            <%=(mensajeError != null ? mensajeError: "") %>
        </div>
    </body>
</html>
