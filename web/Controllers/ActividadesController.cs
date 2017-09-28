using Common;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dtos;
using Model.Dominio;

namespace FrontEnd.Controllers
{
    public class ActividadesController : Controller
    {
        private readonly IServicioActividades _ServicioActividades = Dependencia.GetInstance<IServicioActividades>();
        private readonly IServicioEmpresas _ServicioEmpresas = Dependencia.GetInstance<IServicioEmpresas>();

        // private model db = new Model1();
        //todo  en duda si el metodo deve estar aca o en el servicio de actividad
        //public JsonResult Eventos(DateTime start, DateTime end)
        //{
        //    var actividades = (from a in db.Actividads
        //                       join c in db.empresa
        //                           on a.Idempresa equals c.Idempresa
        //                       where a.FechaInicial >= start
        //                       && a.FechaInicial <= end
        //                       select new
        //                       {
        //                           a.IdActividad,
        //                           a.FechaInicial,
        //                           c.sRazon_social,
        //                           a.Descripcion
        //                       }).ToList();
        //    List<Events> eventos = new List<Events>();
        //    foreach (var item in actividades)
        //    {
        //        Events evento = new Events();
        //        evento.id = item.IdActividad;
        //        evento.start = item.FechaInicial.ToString("o");
        //        evento.end = item.FechaInicial.ToString("o");
        //        evento.title = item.sRazon_social + " " + item.Descripcion;
        //        eventos.Add(evento);
        //    }
        //    return Json(eventos, JsonRequestBehavior.AllowGet);
        //}
        // GET: Actividades
        public ActionResult Index()
        {
            return View(_ServicioActividades.GetAll());
        }
      


        public ActionResult Create()
        {
            //var tipos = new SelectList(db.TipoActividades.ToList(), "TipoActividadId", "Descripcion");
            //ViewData["tipos"] = tipos;
            return PartialView();
        }

        // POST: Actividades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActividadDto factividad)
        {
           
            //var tipos = new SelectList(db.TipoActividades.ToList(), "TipoActividadId", "Descripcion");
            //ViewData["tipos"] = tipos;
            return PartialView(factividad);
        }

        // GET: Actividades/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Actividad actividad = db.Actividades.Find(id);
            //if (actividad == null)
            //{
            //    return HttpNotFound();
            //}
            //db.Entry(actividad).Reference("ClienteActividad").Load();
            //ActividadViewModel factividad = new ActividadViewModel();
            //factividad.ActividadId = actividad.ActividadId;
            //factividad.Descripcion = actividad.Descripcion;
            //factividad.FechaInicial = actividad.FechaInicial;
            //factividad.ClienteId = actividad.ClienteId;
            //factividad.TipoActividadId = actividad.TipoActividadId;
            //factividad.nombre = actividad.ClienteActividad.Nombre;
            //var tipos = new SelectList(db.TipoActividades.ToList(), "TipoActividadId", "Descripcion");
            //ViewData["tipos"] = tipos;
            //factividad.ObtenTelefonosYEmailsDeCliente();
            return PartialView();
        }

        // POST: Actividades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actividad factividad)
        {
            //if (ModelState.IsValid)
            //{
            //    Actividad actividad = db.Actividades.Find(factividad.ActividadId);
            //    actividad.ActividadId = factividad.ActividadId;
            //    actividad.FechaInicial = factividad.FechaInicial;
            //    actividad.FechaFinal = factividad.FechaInicial;
            //    actividad.FechaInicialPlan = factividad.FechaInicial;
            //    actividad.FechaFinalPlan = factividad.FechaInicial;
            //    actividad.ClienteId = factividad.ClienteId;
            //    actividad.TipoActividadId = factividad.TipoActividadId;
            //    actividad.Descripcion = factividad.Descripcion;
            //    actividad.Estado = 0;
            //    db.Entry(actividad).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return Json(new { success = true });
            //}
            //var tipos = new SelectList(db.TipoActividades.ToList(), "TipoActividadId", "Descripcion");
            //ViewData["tipos"] = tipos;
            return PartialView(factividad);
        }

        [Authorize(Roles = "Admin, AdminAgenda")]
        // GET: Actividades/Delete/5
        public ActionResult Delete(int? id)
        {
            //Actividad actividad = db.Actividades.Find(id);
            //db.Actividades.Remove(actividad);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
