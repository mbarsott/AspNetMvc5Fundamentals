using System.Web.Mvc;

namespace Identity.Controllers
{
//    [Authorize(Roles="admin, sales")]
    [Authorize(Users="mbarsott@gmail.com")]
    public class SecretController : Controller
    {
//        [Authorize]
        public ContentResult Secret()
        {
            return Content("This is a secret...");
        }

        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("This is not a secret...");
        }
    }
}