using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace Blog_ASP.Model.DAO {
    public class DAO_Usuario : Conexion, IDAO<Usuario> {
        public DAO_Usuario() : base("blog_ASP") {
        }

        public void Create(Usuario ob) {
            Ejecutar("INSERT INTO usuario VALUES(NEWID(), " +
                "'"+ob.Nombre+"'," +
                "'"+ob.ApellidoPaterno+"'," +
                "'"+ob.ApellidoMaterno+"'," +
                "'"+ob.Nickname+"'," +
                "'"+ob.Password+"', " +
                "'"+ob.Correo+"')");
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
            Cerrar();
            return lista;
        }

        
        public void Update(Usuario ob) {
            Ejecutar("UPDATE usuario SET password = '"+ob.Password+"', nickname = '"+ob.Nickname+"' WHERE id = '"+ob.Id+"'");
        }

        public Boolean IsCorreo(String correo) {
            DataTable dt = Ejecutar("SELECT * FROM usuario WHERE correo = '"+correo+"'");
            Cerrar();
            return dt.Rows.Count != 0;
        }

        public Boolean IsNick(String nick) {
            DataTable dt = Ejecutar("SELECT * FROM usuario WHERE nickname = '" + nick + "'");
            Cerrar();
            return dt.Rows.Count != 0;
        }

        public Usuario GetUsuario(String nickCorreo, String pass) {
            Usuario usu = null;
            DataTable dt = Ejecutar("SELECT * FROM usuario " +
                "WHERE (correo = '"+ nickCorreo + "' OR nickname = '"+ nickCorreo + "') " +
                "AND password = ''");

            if (dt.Rows.Count != 0) {
                usu = new Usuario();

                usu.Id = dt.Rows[0][0].ToString();
                usu.Nombre = dt.Rows[0][1].ToString();
                usu.ApellidoPaterno = dt.Rows[0][2].ToString();
                usu.ApellidoMaterno = dt.Rows[0][3].ToString();
                usu.Nickname = dt.Rows[0][4].ToString();
            }

            Cerrar();

            return usu;
        }
    }
}