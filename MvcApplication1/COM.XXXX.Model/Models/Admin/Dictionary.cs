/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：SystemVariables
// 文件功能描述：
//
// 创建标识：xycui 2014/12/17 9:36:11
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
    public class Dictionary : IModel
    {
        /// <summary>
        /// 字典编号
        /// </summary>
        [DataMember]
        public string GroupCode { get; set; } 

        /// <summary> 
        /// 变量键
        /// </summary>
        [DataMember]
        public string Key { get; set; }

        /// <summary>
        /// 变量值
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
    }
}
