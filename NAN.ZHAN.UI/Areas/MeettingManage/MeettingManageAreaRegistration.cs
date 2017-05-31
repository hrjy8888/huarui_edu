using System.Web.Mvc;

namespace NAN.ZHAN.UI.Areas.MeettingManage
{
    public class MeettingManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MeettingManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MeettingManage_default",
                "MeettingManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}