using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Web;

namespace Common
{
    public class UsuarioActual
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }

    public class UsuarioActualComplementos
    {
        public static UsuarioActual Get
        {
            get
            {
                var user = HttpContext.Current.User;

                if (user == null)
                {
                    return null;
                }
                else if (string.IsNullOrEmpty(user.Identity.GetUserId()))
                {
                    return null;
                }

                var jUser = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.UserData).Value;

                return JsonConvert.DeserializeObject<UsuarioActual>(jUser);
            }
        }
    }
}
