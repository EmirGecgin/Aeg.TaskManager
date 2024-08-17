using Aeg.TaskManager.Bll.Implementations;
using Aeg.TaskManager.Bll.Interfaces;
using Aeg.TaskManager.Entity;
using System.Web.Mvc;


namespace Aeg.TaskManager.MvcUI.Controllers
{

    public class SecureController : Controller
    {
        private readonly IAuthenticationBll _authenticationBll;

        public SecureController()
        {
            _authenticationBll = new AuthenticationBll();
        }
        public ActionResult Index()
        {
            //ViewBag.Error = "Bilinmeyen Hata";
            return View();
        }
        [HttpPost]
        public ActionResult Index(User Model)
        {
            if (ModelState.IsValid)
            {
                var user = _authenticationBll.Login(Model.Username, Model.Password);

                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            _authenticationBll.Logout();
            return RedirectToAction("Index", "Secure");
        }
    }
}