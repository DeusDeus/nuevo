using Common;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dtos;

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
        //        var actividades = (from a in db.Actividads
        //                           join c in db.empresa
        //                               on a.Idempresa equals c.Idempresa
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

       
    }
}