using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Models.DTO.Filtro
{
    public class SolicitudFiltro
    {
        public SolicitudFiltro()
        {

        }
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public CarreraDTO Carrera { get; set; }
        public UsuarioDTO usuario { get; set; }
        public bool carrera;
    }
}