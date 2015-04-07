using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using COM.XXXX.WebApi;
using COM.XXXX.WebApi.Class;

namespace COM.XXXX.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));
            //自己定义的WebApi错误记录
            config.Filters.Add(new WebApiExceptionFilter());

            //WebApi身份认证
            //config.Filters.Add(new BasicAuthenticationFilter());

            //解决MVC的Controller和Web API的Controller类名不能相同的问题 
            //注意，这里WebApi命名时，必须以ApiController结尾
            var suffix = typeof(DefaultHttpControllerSelector).GetField("ControllerSuffix", BindingFlags.Static | BindingFlags.Public);
            if (suffix != null) suffix.SetValue(null, "ApiController");


            //自定义的路由放在默认路由之上才能起作用
            config.Routes.MapHttpRoute(
                "ActionApi",
                "api/{controller}/{action}/{id}",
                new { action = RouteParameter.Optional, id = RouteParameter.Optional },
                new { action = new StartWithConstraint() }
            );


            //默认路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

       
        }

    }
}
