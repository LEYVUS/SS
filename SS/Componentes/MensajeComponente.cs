﻿using SS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Componentes
{   /// <summary>
    /// 
    /// </summary>
    public static class MensajeComponente
    {

       /// <summary>
       /// 
       /// </summary>
       /// <param name="mensaje"></param>
       /// <param name="entidad"></param>
       /// <returns></returns>
        public static MensajeDTO mensaje(string mensaje, Object entidad)
        {
            MensajeDTO mensajeEstado = new MensajeDTO();
            mensajeEstado.Respuesta.Add("Entidad", entidad);
            mensajeEstado.Respuesta.Add("Mensaje", mensaje);
            return mensajeEstado;
        }
    }
}