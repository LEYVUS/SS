using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SS.Controllers
{
    /// <summary>
    /// Controlador Home
    /// </summary>
    public class HomeController : Controller
    {
       /// <summary>
       /// Muestra la pantalla Index
       /// </summary>
       /// <returns>Regresa la vista index</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}