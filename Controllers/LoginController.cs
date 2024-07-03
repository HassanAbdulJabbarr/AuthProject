using AuthProject.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthProject.Controllers
{
    [HandleError]
    public class LoginController : Controller
    {
        LoginDbEntities db = new LoginDbEntities();
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index( user u, string ReturnUrl )
        {

            if (IsValid( u ) == true)
            {
                FormsAuthentication.SetAuthCookie( u.username, false );
                Session["username"] = u.username.ToString();

                if (ReturnUrl != null)
                {
                    return Redirect( ReturnUrl );
                }
                else
                {
                    return RedirectToAction( "Index", "Home" );
                }
            }

            else
            {
                return View();
            }

        }
        public bool IsValid( user u )
        {
            var credentials = db.users.Where( model => model.username == u.username && model.password == u.password ).FirstOrDefault();
            if (credentials != null)
            {
                return (u.username == credentials.username && u.password == credentials.password);
            }
            else
            {
                return false;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return RedirectToAction( "Contact", "Default" );

        }

    }
}