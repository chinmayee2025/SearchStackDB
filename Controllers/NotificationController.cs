using Microsoft.AspNetCore.Mvc;
using SearchStackDatabase.DataDB;
using SearchStackDatabase.IService;
using SearchStackDatabase.Models;
using System.Diagnostics;

namespace SearchStackDatabase.Controllers
{
    public class NotificationController : Controller
    {
        INotiService _notiService = null;
        List<Noti> _oNotifications = new List<Noti>();
        public NotificationController(INotiService notiService)

        {
            _notiService = notiService;
        }


        public IActionResult AllNotifications()
        {
            return View();
        }

        public JsonResult GetNotifications (bool bIsGetOnlyUnread = false)
        {
            int nToUserId = 3;
            _oNotifications = new List<Noti>();
            _oNotifications = _notiService.GetNotifications(nToUserId, bIsGetOnlyUnread);
            return Json(_oNotifications);



        }
    }
}
