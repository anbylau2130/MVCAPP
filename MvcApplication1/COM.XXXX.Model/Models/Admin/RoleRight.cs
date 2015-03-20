/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：RoleRight
// 文件功能描述：
//
// 创建标识：xycui 2014/12/11 9:19:22
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace COM.XXXX.Models.Admin
{
    public class RoleRight : IModel
    {
        public Guid? RoleID { get; set; }

        public Guid? UserID { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
