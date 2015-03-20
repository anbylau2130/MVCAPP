/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：WebApiExceptionFilter
// 文件功能描述：
//
// 创建标识：xycui 2014/12/15 15:54:55
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;
using Com.Cngrain.SmartDepotMonitorOnLine.WindowsServer;

namespace COM.XXXX.WebApi
{
    
        public class WebApiExceptionFilter : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                Log4NetHelper log = Log4NetHelper.CreateInstance();

                log.WriteLog(HttpContext.Current.Request.Url.LocalPath, context.Exception);

                var message = context.Exception.Message;
                if (context.Exception.InnerException != null)
                    message = context.Exception.InnerException.Message;

                context.Response = new HttpResponseMessage() { Content = new StringContent(message) };

                base.OnException(context);
            }
      
    }
}
