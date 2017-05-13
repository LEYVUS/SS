using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Models.DTO
{
    public partial class MensajeDTO
    {
        public MensajeDTO()
        {
            Respuesta = new Dictionary<String, Object>();
        }
        public Dictionary<String, Object> Respuesta { get; set; }
    }
}