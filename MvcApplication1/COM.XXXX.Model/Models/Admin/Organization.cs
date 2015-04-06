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
        /// 分管领导ID：以逗号分隔
        /// </summary>	
        [DataMember]
        public string ChargeLeaderIDs
        {
            get;
            set;
        }
        /// <summary>
        /// 分管领导名称：以逗号分隔
        /// </summary>	
        [DataMember]
        public string ChargeLeaderNames
        {
            get;
            set; 
        }
        /// <summary>
        /// 领导ID：以逗号分隔
        /// </summary>	
        [DataMember]
        public string LeaderIDs
        {
            get; set;
        }

        /// <summary>
        /// 领导ID
        /// </summary>	
        [DataMember]
        public string LeaderNames
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

        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public bool InUse { get; set; }

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
