namespace SS.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

  
    public partial class UsuarioDTO
    {
   
        public UsuarioDTO()
        {
        }

        public UsuarioDTO(int id, string correo, RolDTO rol, string nombre, string apellido, int numero_Empleado)
        {
            Id = id;
            Correo = correo;
            Rol = rol;
            Nombre = nombre;
            Apellido = apellido;
            Numero_Empleado = numero_Empleado;
        }

        public UsuarioDTO(int id, string correo, RolDTO rol)
        {
            Id = id;
            Correo = correo;
            Rol = rol;
        }

        public int Id { get; set; }

        public string Correo { get; set; }

        public RolDTO Rol { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Contrasenia { get; set; }

        public int Numero_Empleado { get; set; }


    }
}
