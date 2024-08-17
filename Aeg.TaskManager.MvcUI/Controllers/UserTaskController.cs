using Aeg.TaskManager.Bll.Implementations;
using Aeg.TaskManager.Bll.Interfaces;
using Aeg.TaskManager.Common.Enums;
using Aeg.TaskManager.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Aeg.TaskManager.MvcUI.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly IUserTaskBll _userTaskBll;
        private readonly IUserBll _userBll;
        public UserTaskController()
        {
            _userTaskBll = new UserTaskBll();
            _userBll = new UserBll();
        }
        
        [HttpGet]
        public ActionResult GetUsers()
        {
            var model= _userBll.GetAllUsers();
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public ActionResult GetUserById(int id)
        {
            var user = _userBll.GetById(id);
            return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult Index()
        {
            var tasks = _userTaskBll.GetAll();

            var userNames = new Dictionary<int, string>();

            foreach (var task in tasks)
            {
                if (task.UserId.HasValue)
                {
                    var user = _userBll.GetById(task.UserId.Value);
                    if (user != null)
                    {
                        userNames[task.Id] = $"{user.Username}";
                    }
                    else
                    {
                        userNames[task.Id] = "Kullanıcı bilgisi mevcut değil";
                    }
                }
                else
                {
                    userNames[task.Id] = "Kullanıcı bilgisi mevcut değil";
                }
            }

            ViewBag.UserNames = userNames;
            
            return View(tasks);

            //var model = _userTaskBll.GetAll();
            //return View(model);
        }

        public ActionResult MyTasks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserTask Model)
        {
            _userTaskBll.AddUserTask(Model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var task = _userTaskBll.Get(x => x.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }

            var user = _userBll.GetById(task.UserId.Value);

            ViewBag.NameSurname = user.NameSurname; 
            return View(task); ;
        }

        [HttpPost]
        public ActionResult Delete(UserTask model)
        {
            _userTaskBll.DeleteUserTask(x => x.Id == model.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var task = _userTaskBll.Get(x => x.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }

            var users = _userBll.GetAllUsers().Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Username,
                Selected = (task.UserId == u.Id)
            }).ToList();

            ViewBag.Users = users;
            return View(task);
        }

        [HttpPost]
        public ActionResult Update(UserTask model)
        {
            if (ModelState.IsValid)
            {
                _userTaskBll.UpdateUserTask(model);
                return RedirectToAction("Index");
            }

            var users = _userBll.GetAllUsers().Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Username,
                Selected = (model.UserId == u.Id)
            }).ToList();

            ViewBag.Users = users;
            return View(model);
        }
        public ActionResult GetUserTasks()
        {
            var userTaskList= _userTaskBll.GetCurrentUserTasks();
            return new JsonResult { Data = userTaskList, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; 
        }
        public ActionResult UpdateUserTaskStatus(int Id, UserTaskStatus status)
        {
            _userTaskBll.UpdateUserTaskStatus(Id, status);
            return  new JsonResult {};
        }
    }
}