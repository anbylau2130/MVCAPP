/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：UserController
// 文件功能描述：
//
// 创建标识：xycui 2014/12/17 11:52:31
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using COM.XXXX.Models;

namespace COM.XXXX.Controllers.Areas.Admin.Controllers
{
    public class UserController:ControllerBase
    {
        public ActionResult Index() 
        {
            return View();
        }
    }
}
