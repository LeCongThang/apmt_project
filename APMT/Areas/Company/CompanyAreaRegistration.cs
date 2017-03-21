using System.Web.Mvc;

namespace APMT.Areas.Company
{
    public class CompanyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Company";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Company_default",
                "company",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "DefineProcess_default",
                "company/define-process",
                new { controller = "DefineProcess", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "DefineProcess_info",
                "company/process-info",
                new { controller = "DefineProcess", action = "Define", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "step",
               "company/activity-config",
                new { controller = "DefineProcess", action = "StepConfig", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "document",
               "company/document-in-process",
                new { controller = "DefineProcess", action = "ManageDocument", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "act",
               "company/setup-task",
                new { controller = "DefineProcess", action = "SetupActivity", id = UrlParameter.Optional }
            );
        }
    }
}