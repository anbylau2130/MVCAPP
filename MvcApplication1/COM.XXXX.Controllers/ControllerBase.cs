/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：UIControllerBase
// 文件功能描述：
//
// 创建标识：xycui 2014/12/4 14:45:10
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Com.XXXX.Class;
using Com.XXXX.Common;
using COM.XXXX.Models.Admin;
using Repository.Domain;
using Repository.Domain.Infrastructure;

namespace COM.XXXX.Controllers
{
    public class ControllerBase:Controller
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private TestDbContext DbContext { get; set; }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new CustomJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding };
        }
        public new JsonResult Json(object data, JsonRequestBehavior jsonRequest)
        {
            return new CustomJsonResult { Data = data, JsonRequestBehavior = jsonRequest };
        }
        public new JsonResult Json(object data)
        {
            return new CustomJsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ControllerBase()
        {
            DbContext = new TestDbContext();
            UnitOfWork = new UnitOfWork(DbContext);
        } 
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (null == CurrentUser)
            {
                filterContext.Result = RedirectToAction("Index", "Login");
            }
        }

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public User CurrentUser
        {
            get
            {
                return new CookieManage().ReadFromCookie(ConstHelper.UserCookie) as User;
            }
        }
    }
}
