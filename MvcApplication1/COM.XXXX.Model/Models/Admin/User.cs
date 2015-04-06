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
    [DataContract]
    public class User : IModel
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        [DataMember]
        public string RealName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 密码 
        /// </summary>
        [DataMember]
        public string PassWord { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        [DataMember]
        public string OfferTime { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [DataMember]
        public string Education { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        [DataMember]
        public string Professional { get; set; }

        /// <summary>
        /// 婚否
        /// </summary>
        [DataMember]
        public bool IsMarry { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [DataMember]
        public string BirthDay { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public bool InUse { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

        [DataMember]
        public Guid? OrganizationID { get; set; }

        /// <summary>
        /// 用户所属组织机构
        /// </summary>
        public virtual Organization Organization { get; set; }

    }
}
