/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：CustomJsonResult
// 文件功能描述：
//
// 创建标识：xycui 2014/8/29 11:19:08
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Com.XXXX.Class
{
    public class CustomJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }
            HttpResponseBase response = context.HttpContext.Response;

            if (Data != null)
            {
                StringWriter sw = new StringWriter(CultureInfo.InvariantCulture);
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                using (JsonWriter jsonWriter = new JsonTextWriter(sw))
                {
                    var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };//这里使用自定义日期格式，默认是ISO8601格式
                    jsonSerializer.Converters.Add(timeConverter);
                    jsonWriter.Formatting = Formatting.Indented;

                    jsonSerializer.Serialize(jsonWriter, Data);
                }
                response.Write(sw.ToString());
            }
        }
    }
}