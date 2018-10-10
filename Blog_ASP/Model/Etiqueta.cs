using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_ASP.Model{
    public class Etiqueta{
        private int id;
        private String valor;

        public int Id { get => id; set => id = value; }
        public string Valor { get => valor; set => valor = value; }
    }
}