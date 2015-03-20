/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：Page
// 文件功能描述：
//
// 创建标识：xycui 2014/12/5 14:09:15
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace COM.XXXX.Models.Admin
{
    [DataContract]
    public class Page : IModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Controller
        /// </summary>
        [DataMember]
        public string Controller { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        [DataMember]
        public string Action { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 所有菜单
        /// </summary>
        public virtual List<Menu> Menus { get; set; }
    }
}
