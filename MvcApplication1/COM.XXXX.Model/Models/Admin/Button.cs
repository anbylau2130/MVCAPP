/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：Button
// 文件功能描述：
//
// 创建标识：xycui 2014/12/11 9:31:52
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
    public class Button:IModel
    {
        public string BtnName { get; set; }

        public string BtnNo { get; set; }

        public string BtnClass { get; set; }

        public string BtnIcon { get; set; }

        public string BtnStatus { get; set; }

        public Guid? MenuID { get; set; } 

        public virtual Menu Menu { get; set; }
    }
}
