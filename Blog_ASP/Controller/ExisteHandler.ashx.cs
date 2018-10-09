using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog_ASP.Model;

namespace Blog_ASP.Controller {
    /// <summary>
    /// Descripción breve de ExisteHandler
    /// </summary>
    public class ExisteHandler : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "texto/normal";

            String tipo  = context.Request.Params["tipo"];  // correo, nick
            String valor = context.Request.Params["valor"]; // el valor del correo o del nick

            DAO_Usuario du = new DAO_Usuario();

            if (tipo == "correo") {
                context.Response.Write(du.IsCorreo(valor));
            }else if (tipo == "nick") {
                context.Response.Write(du.IsNick(valor));
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}