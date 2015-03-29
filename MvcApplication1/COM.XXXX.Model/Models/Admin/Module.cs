/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：Module
// 文件功能描述：
//
// 创建标识：xycui 2014/12/10 9:39:14
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
    public class Module : IModel
    {
        /// <summary>
        /// 模块编号
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }


        /// <summary>
        /// 模块描述
        /// </summary>
        [DataMember]
        public string Desc { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [DataMember]
        public string PicUrl { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int Sort { get; set; }

    }
}
