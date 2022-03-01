using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models.Models;
using WebChat.Provaiders.Providers;

namespace WebChat.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Registet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registet(UserModels user, string Pass2)
        {           
            if (user == null)
            {
                ModelState.AddModelError("error", "Нет данных");
            }
            else
            {
                if ((user.Name != null && user.Name.Trim() == "")
                    || (user.Pass != null && user.Pass.Trim() == "")
                    || (user.Login != null && user.Login.Trim() == "")
                    || user.Name == null || user.Pass == null || user.Login == null)
                {
                    ModelState.AddModelError("error", "Заполните все поля");
                }
                else
                {
                    var us = new UserProvider();
                    if (us.isThere(user.Login))
                    {
                        ModelState.AddModelError("error", "Логин уже занят");
                    }
                    else
                    {
                        if (user.Pass != Pass2)
                        {
                            ModelState.AddModelError("error", "Пароли ни совпадают");
                        }
                        else
                        {
                            us = new UserProvider();
                            us.Registration(user);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    

                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string Login, string Pass)
        {
            var us = new UserProvider();
            var user = us.Authorization(Login,Pass); 
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
            ModelState.AddModelError("error", "Не верный логин или пароль");
            }

            return View();
        }
    }
}