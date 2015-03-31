using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace COM.XXXX.Models.Admin
{
    [Serializable]
    [DataContract]
    public class Organization : IModel
    {

        /// <summary>
        /// 部门名称
        /// </summary>	
        [DataMember]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 上级部门
        /// </summary>		
        [DataMember]
        public Guid? POrganizationID
        {
            get;
            set;
        }

        public virtual Organization POrganization
        {
            get;
            set;
        }

        /// <summary>
        /// 组织机构类型：单位，部门，岗位，
        /// </summary>
        [DataMember]
        public string OrgType { get; set; }

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
        /// 领导ID
        /// </summary>	
        [DataMember]
        public Guid LeaderID
        {
            get; set;
        }

        /// <summary>
        /// 领导
        /// </summary>		
        [DataMember]
        public User Leader
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        [DataMember]
        public string Remark
        {
            get;
            set;
        }

        public virtual List<User> Users
        {
            get; set;
        }

        /// <summary>
        /// easyui加载界面使用
        /// </summary>
        [NotMapped]
        [DataMember]
        public List<Organization> children
        {
            get; set;
        }
    }
}
