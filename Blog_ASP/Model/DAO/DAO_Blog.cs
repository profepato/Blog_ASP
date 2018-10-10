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
    }
}