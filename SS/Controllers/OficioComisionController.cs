using SS.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SS.Controllers
{
    public class OficioComisionController : Controller
    {
        SolicitudServicio solicitudServicio = new SolicitudServicio();

        [Authorize]
        [HttpGet]
        public FileResult PDF(int id)
        {
            byte[] stream = solicitudServicio.CrearPDF(id);
            return File(stream, "application/octet-stream", "OficioComision.pdf");
        }

        [Authorize]
        [HttpPost]
        public void Upload(HttpPostedFileWrapper file)
        {
            string name = file.FileName;
            string path = Server.MapPath("~/UploadedFiles/");
            file.SaveAs(path + Guid.NewGuid() + "." + "pdf");
       //     solicitudServicio.TerminarSolicitud(id);
        }
    }
}