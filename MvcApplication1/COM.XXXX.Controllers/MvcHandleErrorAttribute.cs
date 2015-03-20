/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：MvcHandleErrorAttribute
// 文件功能描述：
//
// 创建标识：xycui 2014/12/15 16:18:53
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Com.Cngrain.SmartDepotMonitorOnLine.WindowsServer;

namespace COM.XXXX.Controllers
{
    public class MvcHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Log4NetHelper log = Log4NetHelper.CreateInstance();
            log.WriteLog(filterContext.RequestContext.HttpContext.Request.Url.LocalPath,filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}
