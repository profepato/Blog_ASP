using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog_ASP.Model;
using Blog_ASP.Model.DAO;
using System.Web.SessionState;

namespace Blog_ASP.Controller {
    /// <summary>
    /// Descripción breve de RegistrarUsuarioHandler
    /// </summary>
    public class RegistrarUsuarioHandler : IHttpHandler, IRequiresSessionState {

        public void ProcessRequest(HttpContext context) {
            Usuario u = new Usuario();

            u.ApellidoMaterno   = context.Request.Params["apMaterno"];
            u.ApellidoPaterno   = context.Request.Params["apPaterno"];
            u.Nickname          = context.Request.Params["nick"];
            u.Nombre            = context.Request.Params["nombre"];
            u.Password          = context.Request.Params["pass"];
            u.Correo            = context.Request.Params["correo"];

            DAO_Usuario du = new DAO_Usuario();

            du.Create(u);

            context.Session["usuario"] = u;
            context.Response.Redirect("../View/Default.aspx");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}