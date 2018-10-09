using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_ASP.Controller {
    /// <summary>
    /// Descripción breve de IniciarSesionHandler
    /// </summary>
    public class IniciarSesionHandler : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            //context.Response.ContentType = "texto/normal";
            //context.Response.Write("Hola a todos");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}