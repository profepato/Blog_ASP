using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_ASP.Model {
    public class Blog {
        private int id;
        private String titulo;
        private String texto;
        private String usuario;
        private DateTime fecha;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Texto { get => texto; set => texto = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}