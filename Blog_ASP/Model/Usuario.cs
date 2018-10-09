using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_ASP.Model {
    public class Usuario {
        private String id;
        private String nombre;
        private String apellidoPaterno;
        private String apellidoMaterno;
        private String nickname;
        private String password;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Password { get => password; set => password = value; }
    }
}