using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace Blog_ASP.Model.DAO {
    public class DAO_Blog : Conexion, IDAO<Blog> {
        public DAO_Blog() : base("blog_ASP") {
        }

        public String CreateBlog(Blog ob) {
            ob.Texto = ob.Texto.Replace("'", "''");
            Ejecutar("INSERT INTO blog" +
                "(titulo, texto, usuario, fecha) " +
                "VALUES('"+ob.Titulo+"','"+ob.Texto+"','"+ob.Usuario+"',getdate())");

            DataTable dt = Ejecutar("SELECT MAX(id) FROM blog");

            return dt.Rows[0][0].ToString();
        }

        public void Create(Blog ob) {
            throw new NotImplementedException();
        }

        public void Delete(object id) {
            throw new NotImplementedException();
        }

        public List<Blog> Read() {
            throw new NotImplementedException();
        }

        public void Update(Blog ob) {
            throw new NotImplementedException();
        }

        public List<Blog> Read(String userId) {
            List<Blog> lista = new List<Blog>();
            DataTable dt = Ejecutar(
                "SELECT id, titulo, texto, fecha " +
                "FROM blog " +
                "WHERE usuario = '"+userId+"' " +
                "ORDER BY fecha DESC"
            );

            Blog b;
            DAO_Etiqueta de = new DAO_Etiqueta();

            for (int i = 0; i < dt.Rows.Count; i++) {
                b = new Blog();

                b.Id = int.Parse(dt.Rows[i][0].ToString());
                b.Titulo = dt.Rows[i][1].ToString();
                b.Texto = dt.Rows[i][2].ToString();
                b.Fecha = DateTime.Parse(dt.Rows[i][3].ToString());

                b.Etiquetas = de.GetEtiquetasByBlog(b.Id);

                lista.Add(b);
            }

            return lista;
        }

        public List<Blog> ReadByTag(String valorEtiqueta) {
            valorEtiqueta = valorEtiqueta.Replace("#", "");

            List<Blog> lista = new List<Blog>();
            DataTable dt = Ejecutar(
                "SELECT b.id, b.titulo, b.texto, b.fecha "+
                "FROM blog b " +
                "INNER JOIN etiqueta_blog eb ON eb.blog = b.id " +
                "INNER JOIN etiqueta e ON e.id = eb.etiqueta " +
                "WHERE e.valor = '"+ valorEtiqueta + "' " +
                "ORDER BY b.titulo"
            );

            Blog b;
            DAO_Etiqueta de = new DAO_Etiqueta();

            for (int i = 0; i < dt.Rows.Count; i++) {
                b = new Blog();

                b.Id = int.Parse(dt.Rows[i][0].ToString());
                b.Titulo = dt.Rows[i][1].ToString();
                b.Texto = dt.Rows[i][2].ToString();
                b.Fecha = DateTime.Parse(dt.Rows[i][3].ToString());

                b.Etiquetas = de.GetEtiquetasByBlog(b.Id);

                lista.Add(b);
            }

            return lista;
        }
    }
}