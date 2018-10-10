using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog_ASP.Model.DAO;
using Blog_ASP.Model;

namespace Blog_ASP.Controller
{
    public class CrearBlogHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            Blog blog = new Blog();
            String etiquetas;

            blog.Titulo = context.Request.Params["titulo"];
            blog.Texto = context.Request.Params["blog"];
            etiquetas = context.Request.Params["etiquetas"];
            blog.Usuario = context.Request.Params["usuario"];

            String[] ets = etiquetas.Split(',');

            DAO_Etiqueta de = new DAO_Etiqueta();
            DAO_Blog db = new DAO_Blog();

            String idBlog = db.CreateBlog(blog);

            int idEtiqueta;
            foreach (String et in ets) {
                idEtiqueta = de.Create(et);

                de.CreateEtiquetaBlog(idEtiqueta, idBlog);
            }

            context.Response.Redirect("../View/Perfil.aspx");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}