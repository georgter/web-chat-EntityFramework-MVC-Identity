using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.BLL.DTO;
using WebChat.BLL.Interfaces;
using WebChat.BLL.Services;
using WebChat.Web.Models;

namespace WebChat.Web.Controllers
{
    
    public class HomeController : Controller
    {

        private readonly IChatLogService _logChatService;
       private readonly SerchServises _serchServises;


        public HomeController()
        {
            _logChatService = new LogChatServices();
            _serchServises = new SerchServises();
        }



        public ActionResult Index()
        {
            SerchServises _serchServises = new SerchServises();
            var name = User.Identity.Name;
            
            if (name == "")
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.UserName = name;
            ViewBag.UserId = _serchServises.GetIdUser(name);
            return View();
        }

        /// <summary>
        /// Запрос на отсортированый список сообщений по датам 
        /// </summary>
        /// <param name="dateOt"></param>
        /// <param name="dateDo"></param>
        /// <returns></returns>
        public JsonResult HistoriDate(DateTime? dateOt, DateTime? dateDo)
        {
            var logChatsRes = new List<LogChat>();
            var logChats = new List<LogChatDTO>();

            logChats = _logChatService.PrintPostSearchDate(dateOt, dateDo);

            foreach (var item in logChats)
            {
                logChatsRes.Add(new LogChat()
                {
                    Id = item.Id,
                    LogDate = item.LogDate.ToString("dd.MM.yyyy HH:mm:ss"),
                    LogMessage = item.LogMessage,
                    Login = _serchServises.GetNameUser(item.UserId),
                });
            }
            return Json(new { usr = logChatsRes }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Запрос на отсортированый список сообщений по логину
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public JsonResult HistoriLogin(string login)
        {
            var logChatsRes = new List<LogChat>();
            var logChats = new List<LogChatDTO>();

            logChats = _logChatService.PrintPostSearchUser(login);
            foreach (var item in logChats)
            {
                logChatsRes.Add(new LogChat()
                {
                    Id = item.Id,
                    LogDate = item.LogDate.ToString("dd.MM.yyyy HH:mm:ss"),
                    LogMessage = item.LogMessage,
                    Login = _serchServises.GetNameUser(item.UserId)
                });
            }
            return Json(new { usr = logChatsRes }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Вытаскивает всех пользователей для установки в фильтер
        /// </summary>
        /// <returns></returns>
        public JsonResult AllUser()
        {

            var users = _serchServises.GetAllDTOUser();
            return Json(new { usr = users }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Запрос на отсортированый список сообщений по логину и датам
        /// </summary>
        /// <param name="dateOt"></param>
        /// <param name="dateDo"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public JsonResult HistoriAll(DateTime? dateOt, DateTime? dateDo, string login)
        {
            var logChatsRes = new List<LogChat>();
            var logChats = new List<LogChatDTO>();

            logChats = _logChatService.PrintPostSearchDateUser(dateOt, dateDo, login);

            foreach (var item in logChats)
            {
                logChatsRes.Add(new LogChat()
                {
                    Id = item.Id,
                    LogDate = item.LogDate.ToString("dd.MM.yyyy HH:mm:ss"),
                    LogMessage = item.LogMessage,
                    Login = _serchServises.GetNameUser(item.UserId)
                });
            }
            return Json(new { usr = logChatsRes }, JsonRequestBehavior.AllowGet);
        }
    }
}