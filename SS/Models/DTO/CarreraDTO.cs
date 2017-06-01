using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Models.DTO
{
    public class CarreraDTO
    {

        public CarreraDTO(int id, string nombre, UsuarioDTO usuario)
        {
            Id = id;
            Nombre = nombre;
            this.usuario = usuario;
        }

        public CarreraDTO()
        {
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public UsuarioDTO usuario;

 
    }
}