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
        /// 变量名
        /// </summary>
        [DataMember]
        public string VarName { get; set; }

        /// <summary>
        /// 变量编码
        /// </summary>
        [DataMember]
        public string VarCode { get; set; }

        /// <summary>
        /// 变量值
        /// </summary>
        [DataMember]
        public string VarValue { get; set; }

        /// <summary>
        /// 唯一值
        /// </summary>
        [DataMember]
        public string UniqueValue { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public int PID { get; set; }

        /// <summary>
        /// 所属模块ID,如果是全局系统变量则，该值为0
        /// </summary>
        public int ModuleID { get; set; }

        public virtual Module Module { get; set; }
    }
}
