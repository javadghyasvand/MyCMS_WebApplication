using System.Web.Mvc;
using DataBase;
using System.Web.Security;

namespace MyCMS_WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly  ILoginAdmin _loginAdmin;
        private readonly  MyCmsContext _cmsContext= new MyCmsContext();

        public LoginController()
        {
            _loginAdmin = new LoginAdmin(_cmsContext);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                if (_loginAdmin.IsExistUser(loginViewModel.UserName, loginViewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginViewModel.UserName,loginViewModel.RememberMe);
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName","کاربری یافت نشد");
                }
            }

            return View(loginViewModel);
        }

        public ActionResult SingOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}