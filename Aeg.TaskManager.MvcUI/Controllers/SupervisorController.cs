using Aeg.TaskManager.Bll.Implementations;
using Aeg.TaskManager.Bll.Interfaces;
using Aeg.TaskManager.Entity;
using System.Web.Mvc;
namespace Aeg.TaskManager.MvcUI.Controllers
{
    public class SupervisorController : Controller
    {
        private IUserBll _userBll { get; set; }
        public SupervisorController()
        {
            _userBll = new UserBll();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var users = _userBll.GetAll();
            if (users != null && users.Count > 0)
            {
                return RedirectToAction("Index", "Secure"); 
            }

            return View(); 
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUsers = _userBll.GetAll();
            if (existingUsers != null && existingUsers.Count > 0)
            {
                return RedirectToAction("Index", "Secure"); 
            }

            if (model.Username != "supervisor")
            {
                ModelState.AddModelError("", "Username 'supervisor' is not allowed.");
                return View(model);
            }

            var existingUser = _userBll.GetByUsername(model.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "Username already exists.");
                return View(model);
            }

            _userBll.AddUser(model);

            return RedirectToAction("Index", "Secure");
        }
    }
}