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
        // GET: MeettingManage/Meeting/EidtMeetingSetting
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMeetingSetting()
        {
            string m_name = Request["m_name"];
            string start_time = Request["m_start_time"];
            Expression<Func<HR_MeettingSetting, bool>> predicate = PredicateBuilder.True<HR_MeettingSetting>();
            if(!string.IsNullOrEmpty(m_name))
            {
                predicate = predicate.And(p => p.m_name == m_name);

            }
            if (!string.IsNullOrEmpty(start_time))
            {
                predicate = predicate.And(p => p.m_start_time == Convert.ToDateTime(start_time));

            }

            List<HR_MeettingSetting> list_meetting= meetting.GetMeetingSetting(predicate);
            return Json(list_meetting);
        }

        [HttpPost]
        public ActionResult AddMeettingSetting(HR_MeettingSetting met)
        {
            met.m_isOpen = 0;
            met.m_state = 1;
           int count= meetting.AddMeetingSetting(met);
            return Json(count== 1 ? new { msg = "op_success" } : new { msg = "op_fail" });
        }

        [HttpPost]
        public ActionResult EidtMeetingSetting(HR_MeettingSetting met)
        {
            int count = meetting.EidtMeettingSetting(met);
            return Json(count == 1 ? new { msg = "op_success" } : new { msg = "op_fail" });
        }
    }
}