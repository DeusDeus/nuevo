using Auth.Service;
using Common;
using Microsoft.AspNet.Identity.Owin;
using Model.Auth;
using Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PoliclinicoWeb.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private ApplicationRoleManager _roleManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        // GET: User
        public ActionResult Index()
        {
            var model = _roleManager.Roles.OrderBy(x => x.Name).ToList();

            return View(model);
        }

        public async Task<ActionResult> Add(ApplicationRole model)
        {
            var Respuesta = await _roleManager.CreateAsync(model);

            if (!Respuesta.Succeeded)
            {
                throw new Exception(Respuesta.Errors.First());
            }

            return RedirectToAction("Index");
        }
    }
}