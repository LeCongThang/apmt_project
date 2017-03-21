using System.Web.Mvc;

namespace APMT.Areas.System
{
    public class SystemAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "System";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "System_default",
                "system-admin",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}