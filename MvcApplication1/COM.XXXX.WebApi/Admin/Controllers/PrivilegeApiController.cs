/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：PrivilegeController
// 文件功能描述：
//
// 创建标识：xycui 2014/12/11 14:04:18
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using COM.XXXX.Models;
using COM.XXXX.Models.Admin;
using Repository.DAL.Repository;

namespace COM.XXXX.WebApi.Admin.Controllers
{
    public class PrivilegeApiController:ApiControllerBase<PrivilegeRepository,Privilege>
    {
        public PrivilegeApiController()
        {
            base.SetRepository();
        }
    }
}
