﻿using SSUABC.Models.EntidadesSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSUABC.Repositorios
{
    /// <summary>
    /// 
    /// </summary>
    interface ICarreraRepositorio
    {
        Carrera BuscarPorUsuario(int id);
    }
}
