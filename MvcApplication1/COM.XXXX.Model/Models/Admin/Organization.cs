using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace COM.XXXX.Models.Admin
{
    [DataContract]
    public class Organization
    {
        [DataMember]
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 部门名称
        /// </summary>	
        [DataMember]
        public string Agency
        {
            get;
            set;
        }
        /// <summary>
        /// 上级部门
        /// </summary>		
        [DataMember]
        public int ParentID
        {
            get;
            set;
        }

        public Organization POrganization
        {
            get;
            set;
        }

        /// <summary>
        /// 排序
        /// </summary>		
        [DataMember]
        public int Sort
        {
            get;
            set;
        }
        /// <summary>
        /// 负责人Id
        /// </summary>		
        [DataMember]
        public int UserID
        {
            get;
            set;
        }

        public User User { get; set; }

        /// <summary>
        /// 备注
        /// </summary>		
        [DataMember]
        public string Remark
        {
            get;
            set;
        }
    }
}
