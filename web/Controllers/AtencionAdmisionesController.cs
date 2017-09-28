using Model.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class AtencionAdmisionesController : Controller
    {
        // GET: AtencionAdmisiones
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Actividad model)
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}