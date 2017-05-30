using iTextSharp.text;
using iTextSharp.text.pdf;
using SS.Componentes;
using SS.Componentes.Constantes;
using SS.Models.DTO;
using SS.Models.DTO.Filtro;
using SS.Models.Entidades.SS;
using SS.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace SS.Servicios
{
    public class SolicitudServicio
    {
        private SolicitudRepositorioImpl solicitudRepositorio;
        private UsuarioRepositorioImpl usuarioRepositorio;
        private UsuarioUABCRepositorioImpl usuarioUABCRepositorio;

        /// <summary>
        /// 
        /// </summary>
        public SolicitudServicio()
        {
            solicitudRepositorio = new SolicitudRepositorioImpl(new EntidadesSS());
            usuarioUABCRepositorio = new UsuarioUABCRepositorioImpl();
            usuarioRepositorio = new UsuarioRepositorioImpl(new EntidadesSS());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public MensajeDTO AceptarTotalmente(int id, string Correo)
        {
            Models.Entidades.UABC.Usuario usuarioUABC = usuarioUABCRepositorio.BuscarUsuarioUABC(Correo);
            CorreoComponente correo = new CorreoComponente(usuarioUABC.Email, usuarioUABC.Contraseña);
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(id);
            solicitud.Id_Estado = (int)EstadoEnum.Aceptado;
            solicitud.Validacion.Subdirector = true;
            solicitud.Validacion.Administrador = true;
            solicitud.Validacion.Coordinador = true;
            solicitud.Validacion.Director = true;
            solicitud.Validacion.Posgrado = true;
            solicitudRepositorio.Modificar(solicitud);
            correo.MandarCorreo("Sistema Solicitud de Salida. " + "La solicitud: " + id + " ha sido aceptada."
                   , "Solicitud Aceptada", solicitud.Correo_Solicitante);
            return MensajeComponente.mensaje("Solicitud Aprobada", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MensajeDTO RechazarTotalmente(int id, string Correo)
        {
            Models.Entidades.UABC.Usuario usuarioUABC = usuarioUABCRepositorio.BuscarUsuarioUABC(Correo);
            CorreoComponente correo = new CorreoComponente(usuarioUABC.Email, usuarioUABC.Contraseña);
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(id);
            solicitudRepositorio.Borrar(solicitud);
            correo.MandarCorreo("Sistema Solicitud de Salida. " + "La solicitud: " + id + " ha sido rechazada."
                   , "Solicitud Rechazada", solicitud.Correo_Solicitante);
            return MensajeComponente.mensaje("Solicitud Rechazada", false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public MensajeDTO BuscarSolicitudesHistorial(SolicitudFiltro filtro, int paginacion)
        {
            List<SolicitudDTO> solicitudesDTO = new List<SolicitudDTO>();
            if (filtro.Carrera == null)
            {
                filtro.carrera = true;
                filtro.Carrera = new CarreraDTO();
            }
            List<Solicitud> solicitudes = solicitudRepositorio.buscarSolicituHistorial(filtro);
            MensajeDTO mensaje;

            foreach (Solicitud solicitud in solicitudes)
            {
                solicitudesDTO.Add(TransferirDTO.TransferirSolicitud(solicitud));
            }

            mensaje = MensajeComponente.mensaje("Datos", solicitudesDTO.Skip(paginacion - 10).Take(paginacion).ToList());
            mensaje.largo = solicitudesDTO.Count();
            return mensaje;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public MensajeDTO BuscarSolicitudesPorCorreo(SolicitudFiltro filtro, int paginacion)
        {
            List<SolicitudDTO> solicitudesDTO = new List<SolicitudDTO>();
            if (filtro.Carrera == null)
            {
                filtro.carrera = true;
                filtro.Carrera = new CarreraDTO();
            }
            List<Solicitud> solicitudes = solicitudRepositorio.BuscarSolicitudPorCorreo(filtro);
            MensajeDTO mensaje;
            foreach (Solicitud solicitud in solicitudes)
            {
                solicitudesDTO.Add(TransferirDTO.TransferirSolicitud(solicitud));
            }
            mensaje = MensajeComponente.mensaje("Datos", solicitudesDTO.Skip(paginacion - 10).Take(paginacion).ToList());
            mensaje.largo = solicitudesDTO.Count();
            return mensaje;
         }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SolicitudDTO BuscarSolicitudPorId(int id)
        {
           
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(id);
            SolicitudDTO solicitudDTO =  TransferirDTO.TransferirSolicitud(solicitud);

            return solicitudDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public MensajeDTO AceptarSolicitud(UsuarioDTO usuario,int id )
        {
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(id);
            Models.Entidades.UABC.Usuario usuarioUABC = usuarioUABCRepositorio.BuscarUsuarioUABC(usuario.Correo);
            CorreoComponente correo = new CorreoComponente(usuarioUABC.Email, usuarioUABC.Contraseña);
            Usuario destinatario = null;
            bool solicitudTerminadaRevision = false;

            switch (usuario.Rol.Descripcion)
                {
                    case "Coordinador":
                        solicitud.Validacion.Coordinador = true;
                     destinatario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Director);
                    break;

                    case "Posgrado":
                        solicitud.Validacion.Posgrado = true;
                        solicitudTerminadaRevision = true;
                    break;

                    case "Administradora":
                        solicitud.Validacion.Administrador = true;
                        destinatario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Coordinador);
                        break;
 
                    case "Subdirector":
                        solicitud.Validacion.Subdirector = true;
                        destinatario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Administradora);
                        break;

                    case "Director":
                        solicitud.Validacion.Director = true;
                        if(solicitud.Actividad.Posgrado == true)
                        {
                            destinatario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Posgrado);

                        }else
                        {
                            solicitudTerminadaRevision = true;
                        }
                      break;
            }

            if (solicitudTerminadaRevision)
            {
                solicitud.Id_Estado = (int)EstadoEnum.Aceptado;
                correo.MandarCorreo("Sistema Solicitud de Salida" + "La solicitud:" + id + "ha sido aceptada",
                    "Solicitud Aceptada", solicitud.Correo_Solicitante);
            }else
            {
                correo.MandarCorreo("Sistema Solicitud de Salida" + "Tiene una solicitud pendiente por revisar. Solicitud :" + id
                    ,"Solicitud Pendiente", destinatario.Correo);
            }
                solicitudRepositorio.Modificar(solicitud);
                return MensajeComponente.mensaje("Se ha aprobado correctamente", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public MensajeDTO RechazarSolicitud( SolicitudDTO solicitudDTO)
        {
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(solicitudDTO.Id);
            solicitud.Comentario_Rechazado = solicitudDTO.Comentario_Rechazado;
            solicitud.Id_Estado = (int)EstadoEnum.Rechazado;
            Models.Entidades.UABC.Usuario usuarioUABC = usuarioUABCRepositorio.BuscarUsuarioUABC(solicitud.Correo_Solicitante);
            CorreoComponente correo = new CorreoComponente(usuarioUABC.Email, usuarioUABC.Contraseña);
            correo.MandarCorreo("Sistema Solicitud de Salida" + "Se ha rechazado una solicitud", "Solicitud Pendiente", solicitud.Correo_Solicitante);
            solicitudRepositorio.Modificar(solicitud);
            return MensajeComponente.mensaje("Se ha aprobado correctamente", true);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public MensajeDTO BuscarSolicitudesPorRols(SolicitudFiltro filtro,int paginacion)
        {
            List<SolicitudDTO> solicitudesDTO = new List<SolicitudDTO>();
            List<Solicitud> solicitudes;
            MensajeDTO mensaje;
            if (filtro.Carrera == null)
            {
                filtro.carrera = true;
                filtro.Carrera = new CarreraDTO();
            }
            if (filtro.Nombre == null)
            {
                filtro.Nombre = "";
            }

            if ( filtro.usuario.Rol != null)
            {
                switch (filtro.usuario.Rol.Descripcion)
                {
                    case "Coordinador":
                        solicitudes = solicitudRepositorio.buscarSolicitudesPorCoordinador(filtro);
                        break;

                    case "Posgrado":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorPosgrado(filtro);
                        break;

                    case "Administradora":
                        solicitudes = solicitudRepositorio.buscarSolicitudesPorAdministrador(filtro);
                        break;

                    case "Subdirector":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorSubDirector(filtro);
                        break;

                    case "Director":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorDirector(filtro);
                        break;
                    default:
                        solicitudes = new List<Solicitud>();
                        break;

                }

            }
            else
            {
                solicitudes = solicitudRepositorio.buscarSolicitudesPorDocente(filtro);
            }

            foreach (Solicitud solicitud in solicitudes)
            {
                solicitudesDTO.Add(TransferirDTO.TransferirSolicitud(solicitud));
            }
           
            mensaje=MensajeComponente.mensaje("Datos", solicitudesDTO.Skip(paginacion - 10).Take(paginacion));
            mensaje.largo = solicitudesDTO.Count();
            return mensaje;
        }

        public MensajeDTO EditarSolicitud(SolicitudDTO solicitudDTO)
        {
            if (this.SolicitudValida(solicitudDTO))
            {

                Solicitud solicitud = solicitudRepositorio.BuscarPorId(solicitudDTO.Id);
                solicitud.Fecha_Modificacion = DateTime.Now;
                solicitud.Evento = TransferirDTO.TransferirEvento(solicitudDTO.Evento);
                solicitud.Actividad = TransferirDTO.TransferirActividad(solicitudDTO.Actividad);
                solicitud.Validacion = TransferirDTO.TransferirValidacion(solicitudDTO.Validacion);
                solicitud.Recurso = TransferirDTO.TransferirRecurso(solicitudDTO.Recurso_Solicitado);
                solicitud.Id_Carrera = solicitudDTO.Carrera.Id;
                solicitud.Id_Categoria = solicitudDTO.Categoria.Id;
                solicitud.Id_Estado = (int)EstadoEnum.Proceso;
                solicitud.Comentario_Rechazado = "";
                Models.Entidades.UABC.Usuario usuarioUABC = usuarioUABCRepositorio.BuscarUsuarioUABC(solicitud.Correo_Solicitante);
                CorreoComponente correo = new CorreoComponente(usuarioUABC.Email, usuarioUABC.Contraseña);
                Usuario usuario;
                if (!solicitud.Validacion.Subdirector)
                {
                    //Buscar subdirector
                    usuario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Director);
                }
                else
                {
                    if (!solicitud.Validacion.Administrador)
                    {
                        usuario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Administradora);
                        //buscar administrador
                    }
                    else
                    {
                        if (!solicitud.Validacion.Coordinador)
                        {
                            usuario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Coordinador);
                            //buscar coordinador
                        }
                        else
                        {
                            if (!solicitud.Validacion.Director)
                            {
                                usuario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Director);
                                //buscar director
                            }
                            else
                            {
                                usuario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Posgrado);
                                //buscar posgrado
                            }
                        }
                    }
                }
                correo.MandarCorreo("Sistema Solicitud de Salida" + "La solicitud: " + solicitud.Id + " ha sido corregida.", "Solicitud Pendiente", usuario.Correo);
                solicitudRepositorio.Modificar(solicitud);
                return MensajeComponente.mensaje("Solicitud modificada exitosamente", true);
            }
            return MensajeComponente.mensaje("Error al crear la solicitud", false); ;
        }

        public byte[] CrearPDF(int Id)
        {
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(Id);

            byte[] bytes;
            MemoryStream memoryStream = new MemoryStream();
            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(50,50,50,50);
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.AddTitle("Oficio Comision");
            Font TittleFont = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 15, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
            doc.Open();
            doc.Add(Chunk.NEWLINE);
            Paragraph Tittle = new Paragraph("Universidad Autónoma Baja California", TittleFont);
            Tittle.Alignment = Element.ALIGN_CENTER;
            doc.Add(Tittle);
            doc.Add(Chunk.NEWLINE);

            Font SubTittleFont = new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Paragraph SubTittle = new Paragraph("FACULTAD DE INGENIERÍA, ARQUITECTURA Y DISEÑO ", SubTittleFont);
            SubTittle.Alignment = Element.ALIGN_CENTER;
            doc.Add(SubTittle);
            doc.Add(Chunk.NEWLINE);

            Font TextoIzquierdaFont = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Paragraph subDir = new Paragraph("SUBDIRECCIÓN", TextoIzquierdaFont);
            subDir.Alignment = Element.ALIGN_RIGHT;
            doc.Add(subDir);

            DateTime fecha = DateTime.Now;
            Font TextoIzquierdaNo = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            int id = 1;
            if (fecha.Month > 6)
            {
                id = 2;
            }
            Paragraph No = new Paragraph("No.10/"+ (fecha.Year - 2000)  + "-"+ id, TextoIzquierdaNo);
            No.Alignment = Element.ALIGN_RIGHT;
            doc.Add(No);

            Paragraph Asunto = new Paragraph("Asunto: Oficio Comisión", TextoIzquierdaNo);
            Asunto.Alignment = Element.ALIGN_RIGHT;
            doc.Add(Asunto);
            var mes = DateTime.Now.ToString("MMMM", new CultureInfo("es-ES"));
            Paragraph Fecha = new Paragraph("Ensenada, B.C, a " + fecha.Day + " de " + mes + " del " + fecha.Year, TextoIzquierdaFont);
            Fecha.Alignment = Element.ALIGN_RIGHT;
            doc.Add(Fecha);

            doc.Add(Chunk.NEWLINE);

            Font TextoDerecho = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Paragraph Remitente = new Paragraph("M.C. " + solicitud.Nombre_Solicitante, TextoDerecho);
            Remitente.Alignment = Element.ALIGN_LEFT;
            doc.Add(Remitente);

            Paragraph Presente = new Paragraph("PRESENTE.", TextoDerecho);
            Presente.Alignment = Element.ALIGN_LEFT;
            doc.Add(Presente);

            var mesSalida = solicitud.Evento.Fecha_Hora_Salida.ToString("MMMM", new CultureInfo("es-ES"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            Font CuerpoFont = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            Paragraph Cuerpo = new Paragraph("                               " +
                "Por medio del presente la subdirección a mi" +
                "cargo comisiona a usted los dias " + solicitud.Evento.Fecha_Hora_Salida.Day + " y " +
                solicitud.Evento.Fecha_Hora_Regreso.Day + " de " + mesSalida + " del año en curso, " +
                "a la ciudad de " + solicitud .Evento.Lugar + ".", CuerpoFont);
            Remitente.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(Cuerpo);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            Paragraph Motivo = new Paragraph("MOTIVO: " + solicitud.Evento.Nombre + ".", TextoDerecho);
            Motivo.Alignment = Element.ALIGN_LEFT;
            doc.Add(Motivo);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            Paragraph Despedida = new Paragraph("En espera  que reciba de conformidad, me despido de usted" +
                "con un cordial saludo.", CuerpoFont);
            Despedida.Alignment = Element.ALIGN_LEFT;
            doc.Add(Despedida);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            Paragraph Atentamente = new Paragraph("ATENTAMENTE", TextoDerecho);
            Atentamente.Alignment = Element.ALIGN_CENTER;
            doc.Add(Atentamente);

            Paragraph Slogan = new Paragraph("POR LA REALIZACIÓN PLENA DEL HOMBRE.", TextoDerecho);
            Slogan.Alignment = Element.ALIGN_CENTER;
            doc.Add(Slogan);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            Paragraph NombreSub = new Paragraph("Dr. HUMBERTO CERVANTES DE AVILA"  , TextoDerecho);
            NombreSub.Alignment = Element.ALIGN_CENTER;
            doc.Add(NombreSub);

            Paragraph Sub = new Paragraph("SUBDIRECTOR", TextoDerecho);
            Sub.Alignment = Element.ALIGN_CENTER;
            doc.Add(Sub);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            Paragraph RH = new Paragraph("c.c.p.-D.R. Alejandro Moctezuma Jefe del Depto. de" +
                " de Recursos Humanos. Ensenada.", TextoIzquierdaNo);
            RH.Alignment = Element.ALIGN_LEFT;
            doc.Add(RH);

            Paragraph Expediente = new Paragraph("c.c.p.- Expediente.", TextoIzquierdaNo);
            Expediente.Alignment = Element.ALIGN_LEFT;
            doc.Add(Expediente);


            Paragraph HCDA = new Paragraph("HCDA/eliud", TextoIzquierdaNo);
            HCDA.Alignment = Element.ALIGN_LEFT;
            doc.Add(HCDA);


            doc.Close();
            bytes = memoryStream.GetBuffer();
            memoryStream.Close();
            return bytes;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitudDTO"></param>
        /// <returns></returns>
        public MensajeDTO Agregar(SolicitudDTO solicitudDTO)
        {
            if (this.SolicitudValida(solicitudDTO))
            {
                Solicitud solicitud;
                solicitud = TransferirEntidad.TransferirDatosSolicitudDTO(solicitudDTO);

                //Busca credecniales del usuario logeado
                Models.Entidades.UABC.Usuario usuario = usuarioUABCRepositorio.BuscarUsuarioUABC(solicitud.Correo_Solicitante);

                Usuario subdirector = usuarioRepositorio.BuscarPorRol((int)RolEnum.Subdirector);
                //Busca al proximo usuario que su rol es coordinador
               

                //Envia el correo al sigueinte usuario
                CorreoComponente correo = new CorreoComponente(usuario.Email, usuario.Contraseña);
                 if(correo.MandarCorreo("Sistema Solicitud de Salida" + "Tiene una solicitud pendiente por revisar ", "Solicitud Pendiente", subdirector.Correo))
                {
                    solicitudRepositorio.Agregar(solicitud);
                    return MensajeComponente.mensaje("Solicitud creada exitosamente", true);                  
                }

                return MensajeComponente.mensaje("Error al crear la solicitud", false);
            }
            return MensajeComponente.mensaje("Error al crear la solicitud", false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitudDTO"></param>
        /// <returns></returns>
        private bool SolicitudValida(SolicitudDTO solicitudDTO)
        {
            if (solicitudDTO != null)
            {
                if (solicitudDTO.Nombre_Solicitante == null)
                {
                    return false;
                }
                if (solicitudDTO.Correo_Solicitante == "")
                {
                    return false;
                }
                if(solicitudDTO.Actividad == null)
                {
                    return false;
                }
                if(solicitudDTO.Validacion == null)
                {
                    return false;
                }
                if(solicitudDTO.Recurso_Solicitado == null)
                {
                    return false;
                }
                if(solicitudDTO.Carrera == null)
                {
                    return false;
                }
               if(solicitudDTO.Evento.Fecha_Hora_Regreso <= solicitudDTO.Evento.Fecha_Hora_Salida
                    && solicitudDTO.Evento.Fecha_Hora_Salida < new DateTime())
                {
                    return false;
                }
            }
            return true;
        }
    }

}