using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.Serialization;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;

namespace COM.XXXX.Models.Admin
{
   [Serializable]
    public class User : IModel
    {
       /// <summary>
       /// 真实姓名
       /// </summary>
       public string RealName { get; set; }

       /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码 
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
         /// 入职时间
        /// </summary>
        public DateTime? OfferTime { get; set; }

        /// <summary>
         /// 学历
        /// </summary>
         public string Education { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
         public string Professional { get; set; }

        /// <summary>
        /// 婚否
        /// </summary>
        public bool IsMarry { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay { get; set; }

       /// <summary>
       /// 是否启用
       /// </summary>
       public bool InUse { get; set; }

       /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
