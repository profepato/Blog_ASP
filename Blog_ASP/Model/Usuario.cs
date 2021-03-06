﻿using System;
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
        private String correo;
        private DateTime nacimiento;
        private int anios;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Password { get => password; set => password = value; }
        public string Correo { get => correo; set => correo = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
        public int Anios { get => anios; set => anios = value; }

        public String GetNombreCompleto() {
            return this.nombre + " " + apellidoPaterno + " " + apellidoMaterno; 
        }
        
    }
}