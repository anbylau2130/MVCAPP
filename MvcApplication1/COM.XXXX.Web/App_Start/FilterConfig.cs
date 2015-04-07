using System.Web;
using System.Web.Mvc;
using COM.XXXX.Controllers;

namespace COM.XXXX.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //自己定义的Mvc错误记录
            filters.Add(new MvcHandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}