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
        public ActionResult Registet(UserModels users, string Pass2)
        {
            if (users == null)
            {
                ModelState.AddModelError("error", "Нет данных");
            }
            else
            {
                if ((users.Name != null && users.Name.Trim() == "")
                    || (users.Pass != null && users.Pass.Trim() == "")
                    || (users.Login != null && users.Login.Trim() == "")
                    || users.Name == null || users.Pass == null || users.Login == null)
                {
                    ModelState.AddModelError("error", "Заполните все поля");
                }
                else
                {
                    
                        if (false)
                        {
                            ModelState.AddModelError("error", "Логин уже занят");
                        }
                        else
                        {
                            if (users.Pass != Pass2)
                            {
                                ModelState.AddModelError("error", "Пароли ни совпадают");
                            }
                            else
                            {
                                var us = new UserProvider();
                                us.Registration(users);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    

                }
            }
            return View();
        }
    }
}