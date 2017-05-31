using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAN.ZHAN.DAL;
using System.Linq.Expressions;

namespace NAN.ZHAN.UI.Areas.MeettingManage.Controllers
{
    public class MeetingController : Controller
    {
        private MeetingServices meetting = new MeetingServices();
        // GET: MeettingManage/Meeting/GetMeetingSetting
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMeetingSetting()
        {
            Expression<Func<HR_MeettingSetting, bool>> predicate = PredicateBuilder.True<HR_MeettingSetting>();
            List<HR_MeettingSetting> list_meetting= meetting.GetMeetingSetting(predicate);
            return Json(list_meetting);
        }
    }
}