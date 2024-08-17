using Aeg.TaskManager.Bll.Implementations;
using Aeg.TaskManager.Bll.Interfaces;
using System.Web.Mvc;

namespace Aeg.TaskManager.MvcUI.Controllers
{

    public class HomeController : Controller
    {
        private IUserBll _userBll { get; set; }
        public HomeController()
        {
            _userBll = new UserBll();
        }
        public ActionResult Index()
        {
            var userId = Session["UserId"] as int?;
            if (userId == null)
            {
                return RedirectToAction("Login", "Account"); 
            }

            var user = _userBll.GetById(userId.Value);
            if (user == null)
            {
                return HttpNotFound(); 
            }

            ViewBag.Username = user.Username;
            ViewBag.NameSurname = user.NameSurname;
            ViewBag.Email = user.Email;

            return View();
        }

    }
}