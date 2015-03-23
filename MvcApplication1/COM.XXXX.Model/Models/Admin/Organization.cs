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
    public class Organization:IModel
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
        public Guid? UserID
        {
            get;
            set;
        }

        [DataMember]
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
        /// <summary>
        /// easyui加载界面使用
        /// </summary>
        [NotMapped]
        [DataMember]
        public List<Organization> children { get; set; }
    }
}
