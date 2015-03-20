/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：Main
// 文件功能描述：
//
// 创建标识：xycui 2014/12/15 13:52:17
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/

using System.Web.Mvc;

namespace COM.XXXX.Controllers.Areas.Admin.Controllers
{
    public class HomeController:ControllerBase
    { 
        public ActionResult Index()
        { 
            return View();
        }
    }
}
