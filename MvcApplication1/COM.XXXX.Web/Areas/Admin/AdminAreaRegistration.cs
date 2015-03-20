using System.Web.Http;
using System.Web.Mvc;
using COM.XXXX.WebApi.Class;

namespace COM.XXXX.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //注册区域MVC路由
            context.MapRoute(
                this.AreaName + "default",
                this.AreaName + "/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "COM.XXXX.Controllers.Areas." + this.AreaName + ".Controllers" }
            );
            //注册区域WebApi路由
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                    this.AreaName + "Api",
                    "api/" + this.AreaName + "/{controller}/{action}/{id}",
                    new
                    {
                        action = RouteParameter.Optional,
                        id = RouteParameter.Optional,
                        namespaceName = new string[] { string.Format("COM.XXXX.WebApi.{0}.Controllers", this.AreaName) }
                    },
                    new { action = new StartWithConstraint() }
             );

           
        }
    }
}
