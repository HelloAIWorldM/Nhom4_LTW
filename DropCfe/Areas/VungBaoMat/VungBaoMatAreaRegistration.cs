using System.Web.Mvc;

namespace DropCfe.Areas.VungBaoMat
{
    public class VungBaoMatAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "VungBaoMat";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "VungBaoMat_default",
                "VungBaoMat/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}