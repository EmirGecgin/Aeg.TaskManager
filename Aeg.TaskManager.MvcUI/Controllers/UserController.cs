using Aeg.TaskManager.Bll.Implementations;
using Aeg.TaskManager.Bll.Interfaces;
using Aeg.TaskManager.Entity;
using System.Web.Mvc;
namespace Aeg.TaskManager.MvcUI.Controllers
{
    public class UserController : Controller
    {
        private IUserBll _userBll { get; set; }
        public UserController()
        {
            _userBll = new UserBll();
        }
        [HttpGet]
        
        public ActionResult Index()
        {
            var model= _userBll.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User Model)
        {
            _userBll.AddUser(Model);
            return View();
        }
        [HttpGet]
        public ActionResult Update(int Id)
        {
            var model = _userBll.GetById(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(User Model)
        {
            _userBll.UpdateUser(Model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var model= _userBll.GetById(Id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            _userBll.DeleteUser(Id);
            return RedirectToAction("Index");
        }
    }
}