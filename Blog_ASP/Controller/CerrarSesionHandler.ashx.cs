using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.SessionState;

namespace Blog_ASP.Controller {

    public class CerrarSesionHandler : IHttpHandler, IRequiresSessionState {

        public void ProcessRequest(HttpContext context) {
            context.Session.Clear();
            context.Response.Redirect("../View/Default.aspx");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}