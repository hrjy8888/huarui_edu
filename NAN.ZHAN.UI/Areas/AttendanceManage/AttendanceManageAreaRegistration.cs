using System.Web.Mvc;

namespace NAN.ZHAN.UI.Areas.AttendanceManage
{
    public class AttendanceManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AttendanceManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AttendanceManage_default",
                "AttendanceManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}