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
    public class EmpresaController : Controller
    {
        private readonly IServicioEmpresas _EmpresaService = Dependencia.GetInstance<IServicioEmpresas>();

        // GET: Empresa
        public ActionResult Index()
        {
            return View(_EmpresaService.GetAll());
        }
        public ActionResult New()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Create(Empresa model)
        //{
        //    _EmpresaService.Insert(model);
        //    return RedirectToAction("Index");
        //}
        public ActionResult New(int id = 0)
        {
            return View(id == 0 ? new Empresa() : _EmpresaService.Get(id));
        }
        [HttpPost]
        public ActionResult Create(Empresa model)
        {
            if (ModelState.IsValid)
            {
                var rh = _EmpresaService.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Deleted(int id)
        {
           
            _EmpresaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}