using Common;
using Model.Dominio;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliclinicoWeb.Controllers
{
    public class CampaniasController : Controller
    {
        private readonly IServicioCampanias _ServicioCampanias = Dependencia.GetInstance<IServicioCampanias>();
        // private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Campanias
        public ActionResult Index()
        {
            return View(_ServicioCampanias.GetAll());
        }


        // GET: Campanias/Create
        public ActionResult Create()
        {

            return PartialView();
        }
        [HttpPost]
      
        public ActionResult Create(Campania model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioCampanias.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        //todo falta ponerlo en servicio
        // GET: Campanias/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Campania campania = db.Campanias.Find(id);
        //    if (campania == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    CampaniaViewModel fcampania = new CampaniaViewModel();
        //    fcampania.CampaniaId = campania.CampaniaId;
        //    fcampania.Fecha = campania.Fecha;
        //    fcampania.Nombre = campania.Nombre;
        //    fcampania.Publicada = campania.Publicada;
        //    return View(fcampania);
        //}

    
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CampaniaId,Nombre,FechaPlan,Fecha")] Campania campania)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(campania).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(campania);
        //}

       
        // POST: Campanias/Delete/5
        [HttpPost]
      
        public ActionResult Delete(int id)
        {
            _ServicioCampanias.Delete(id);
            return RedirectToAction("index");
        }
        //todo falta  poner en servicio

        //public ActionResult MuestraDetalle(int idCampania)
        //{
        //    CampaniaViewModel campania = new CampaniaViewModel();
        //    List<ActividadViewModel> actividades = campania.GetActividades(idCampania);
        //    campania.Dispose();
        //    return PartialView("_ListadoActividades", actividades);
        //}

        //public ActionResult AgregaActividad(int idCampania, int idCliente)
        //{
        //    CampaniaViewModel fcampania = new CampaniaViewModel();
        //    if (!fcampania.ExisteCliente(idCampania, idCliente))
        //        fcampania.AgregaCliente(idCampania, idCliente);
        //    List<ActividadViewModel> actividades = new List<ActividadViewModel>();
        //    actividades = fcampania.GetActividades(idCampania);
        //    fcampania.Dispose();
        //    return PartialView("_ListadoActividades", actividades);
        //}
        //public ActionResult EliminaActividad(int idActividad)
        //{
        //    Actividad actividad = db.Actividades.Find(idActividad);
        //    if (actividad != null)
        //    {
        //        int idCampania = (int)actividad.CampaniaId;
        //        db.Actividades.Remove(actividad);
        //        db.SaveChanges();
        //        Campania campania = db.Campanias.Find(idCampania);
        //        CampaniaViewModel fcampania = new CampaniaViewModel();
        //        fcampania.CampaniaId = campania.CampaniaId;
        //        fcampania.Fecha = campania.Fecha;
        //        fcampania.Nombre = campania.Nombre;
        //        return View("Edit", fcampania);
        //    }
        //    else
        //        return HttpNotFound();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}