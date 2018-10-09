using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog_ASP.Model;
using Blog_ASP.Model.DAO;
using System.Web.SessionState;

namespace Blog_ASP.Controller {

    public class IniciarSesionHandler : IHttpHandler, IRequiresSessionState {

        public void ProcessRequest(HttpContext context) {
            String nickCorreo = context.Request.Params["correo"];
            String pass = context.Request.Params["pass"];
            DAO_Usuario du = new DAO_Usuario();

            Usuario usu = du.GetUsuario(nickCorreo, pass);

            if (usu != null) {
                // sesión ok
                context.Session["user"] = usu;
            } else {
                if (nickCorreo.Contains("@")) {
                    if (!du.IsCorreo(nickCorreo)) {
                        // lo envío a registrar
                        context.Session["correo"] = nickCorreo;
                        context.Response.Redirect("../View/Registro.aspx");
                    }
                }else if (!du.IsNick(nickCorreo)) {
                    // lo envío a registrar
                    context.Session["nick"] = nickCorreo;
                    context.Response.Redirect("../View/Registro.aspx");
                }
            }

        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}