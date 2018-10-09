using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*Imports necesarios para una conexión hacia MS SQL*/
using System.Data;
using System.Data.SqlClient;
/*Imports necesarios para una conexión hacia MS SQL*/

namespace Blog_ASP.Model {
    public class Conexion {
        private SqlConnection con; // Connection
        private SqlCommand sen;	// Statement
        public SqlDataReader rs; // ResultSet

        public Conexion(String bd) {
            con = new SqlConnection(
                "Data Source=localhost;" +
                "Initial Catalog=" + bd + "; " +
                "User id=sa; " +
                "Password=123456;"
            );

            /*
            Autenticación de windows
            "Data Source=ServerName;" +
            "Initial Catalog=DataBaseName;" +
            "Integrated Security=SSPI;";
            */
        }

        public DataTable Ejecutar(String query) {
            Console.WriteLine("QUERY=" + query);
            DataTable dt = null;

            con.Open();
            sen = new SqlCommand(query, con);

            if (query.ToLower().Contains("select")) {
                rs = sen.ExecuteReader();
                dt = new DataTable();
                dt.Load(rs);
            } else { //insert, update, delete
                sen.ExecuteNonQuery();
            }
            Cerrar();

            return dt;
        }

        public void Cerrar() {
            con.Close();
        }
    }
}