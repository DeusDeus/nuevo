using Common;
using Model.Dominio;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IServicioPacientes _ServicioPacientes = Dependencia.GetInstance<IServicioPacientes>();

        // GET: Pacientes
        public ActionResult Index()
        {
            return View(_ServicioPacientes.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Paciente model )
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioPacientes.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }
            
            return View(model);
        }
        public ActionResult Edit(int id)
        {

            return View();
        }
        public ActionResult Delete(int id)
        {
            _ServicioPacientes.Delete(id);
            return View();
        }

    }
}