using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace Blog_ASP.Model.DAO{
    public class DAO_Etiqueta : Conexion, IDAO<Etiqueta> {
        public DAO_Etiqueta() : base("blog_ASP") {
        }

        public void Create(Etiqueta ob) {
            throw new NotImplementedException();
        }

        public int Create(String valor) {
            valor = valor.Trim();
            Etiqueta et = GetEtiqueta(valor);

            if (et == null) {
                Ejecutar("INSERT INTO etiqueta(valor) VALUES('" + valor + "');");
                et = GetEtiqueta(valor);
            }

            return et.Id;
        }

        public void CreateEtiquetaBlog(int etiqueta, String blog) {
            Ejecutar("INSERT INTO etiqueta_blog(etiqueta, blog) VALUES('"+ etiqueta + "','"+ blog + "')");
        }

        public void Delete(object id) {
            throw new NotImplementedException();
        }

        public List<Etiqueta> Read() {
            throw new NotImplementedException();
        }

        public void Update(Etiqueta ob) {
            throw new NotImplementedException();
        }

        public Etiqueta GetEtiqueta(String valor) {
            DataTable dt = Ejecutar("SELECT * FROM etiqueta WHERE valor = '"+valor+"'");
            Etiqueta et = null;

            if (dt.Rows.Count != 0) {
                et = new Etiqueta();

                et.Id = int.Parse(dt.Rows[0][0].ToString());
                et.Valor = dt.Rows[0][1].ToString();
            }

            return et;
        }

        public List<Etiqueta> GetEtiquetasByBlog(int idBlog) {
            List<Etiqueta> lista = new List<Etiqueta>();

            DataTable dt = Ejecutar("SELECT e.id, e.valor "+
                                    "FROM etiqueta e "+
                                    "INNER JOIN etiqueta_blog eb ON e.id = eb.etiqueta "+
                                    "INNER JOIN blog b ON b.id = eb.blog "+
                                    "WHERE b.id = '"+ idBlog + "'");
            Etiqueta et;

            for (int i = 0; i < dt.Rows.Count; i++) {
                et = new Etiqueta();

                et.Id = int.Parse(dt.Rows[i][0].ToString());
                et.Valor = dt.Rows[i][1].ToString();

                lista.Add(et);
            }

            return lista;
        }
    }
}