<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Blog_ASP.View.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <script src="../js/jquery-3.3.1.min.js"></script>
        <script>
            var nickOk = false;
            var correoOk = false;

            function existeNick() {
                $.ajax({
                    type: 'POST',
                    url: 'http://localhost:54548/Controller/ExisteHandler.ashx',
                    data: {
                        tipo: 'nick',
                        valor: $("#nick").val()
                    }
                }).done(function (res) {
                    if (res == "True") {
                        $("#nick").css("background-color", "red");
                        $("#nick").css("color", "white");
                        $("#btnRegistrar").attr("disabled", true);
                        nickOk = false;
                        $("#menNick").html("El nickname ya existe.");
                    } else {
                        nickOk = true;
                        $("#menNick").html("");
                        $("#nick").css("background-color", "white");
                        $("#nick").css("color", "black");

                        if (correoOk) {
                            $("#btnRegistrar").attr("disabled", false);
                        }
                    }
                });

            }

            function existeCorreo() {
                $.ajax({
                    type: 'POST',
                    url: 'http://localhost:54548/Controller/ExisteHandler.ashx',
                    data: {
                        tipo: 'correo',
                        valor: $("#correo").val()
                    }
                }).done(function (res) {
                    if (res == "True") {
                        correoOk = false;
                        $("#correo").css("background-color", "red");
                        $("#correo").css("color", "white");
                        $("#btnRegistrar").attr("disabled", true);
                        $("#menCorreo").html("El correo ya existe.");
                    } else {
                        correoOk = true;
                        $("#menCorreo").html("");
                        $("#correo").css("background-color", "white");
                        $("#correo").css("color", "black");

                        if (nickOk) {
                            $("#btnRegistrar").attr("disabled", false);
                        }
                    }
                });
            }
        </script>

        
    </head>
    <body onload="$('#btnRegistrar').attr('disabled', true);">
        <h1>Registro</h1>
        <form action="../Controller/RegistrarUsuarioHandler.ashx" method="post">
            <input required="required" type="text"      id="nick" name="nick"        placeholder="Nick:" onfocusout="existeNick()"/>
            <span id="menNick"></span>
            <input required="required" type="text"      name="nombre"                placeholder="Nombre:"/>
            <input required="required" type="text"      name="apPaterno"             placeholder="Apellido Paterno:"/>
            <input required="required" type="text"      name="apMaterno"             placeholder="Apellido Materno:"/>
            <input required="required" type="text"      id="correo" name="correo"    placeholder="Correo:" onfocusout="existeCorreo()"/>
            <span id="menCorreo"></span>
            <input required="required" type="password"  name="pass"                  placeholder="Password:"/>

            <input id="btnRegistrar" type="submit" value="Registrarse"/>
        </form>
        <a href="Default.aspx">Volver</a>
    </body>
</html>
