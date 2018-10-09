using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace Blog_ASP.Model {
    public class DAO_Usuario : Conexion, IDAO<Usuario> {
        public DAO_Usuario() : base("blog_ASP") {
        }

        public void Create(Usuario ob) {
            Ejecutar("INSERT INTO usuario VALUES(NEWID(), " +
                "'"+ob.Nombre+"'," +
                "'"+ob.ApellidoPaterno+"'," +
                "'"+ob.ApellidoMaterno+"'," +
                "'"+ob.Nickname+"'," +
                "'"+ob.Password+"')");
        }

        public void Delete(object id) {
            //throw new NotImplementedException();
        }

        public List<Usuario> Read() {
            List<Usuario> lista = new List<Usuario>();
            DataTable dt = Ejecutar("SELECT * FROM usuario");

            for (int i = 0; i < dt.Rows.Count; i++) {
                Usuario usu = new Usuario();

                usu.Id = dt.Rows[i][0].ToString();
                usu.Nombre = dt.Rows[i][1].ToString();
                usu.ApellidoPaterno = dt.Rows[i][2].ToString();
                usu.ApellidoMaterno = dt.Rows[i][3].ToString();
                usu.Nickname = dt.Rows[i][4].ToString();
                usu.Password = dt.Rows[i][5].ToString();

                lista.Add(usu);
            }

            return lista;
        }

        
        public void Update(Usuario ob) {
            Ejecutar("UPDATE usuario SET password = '"+ob.Password+"', nickname = '"+ob.Nickname+"' WHERE id = '"+ob.Id+"'");
        }
    }
}