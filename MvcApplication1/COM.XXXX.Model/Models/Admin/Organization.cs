using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace COM.XXXX.Models.Admin
{
    public class Organization:IModel
    {
      
        /// <summary>
        /// 部门名称
        /// </summary>	
        public string Agency
        {
            get;
            set;
        }
        /// <summary>
        /// 上级部门
        /// </summary>		
        public Guid ParentID
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
        public int Sort
        {
            get;
            set;
        }
        /// <summary>
        /// 负责人Id
        /// </summary>		
        public Guid? UserID
        {
            get;
            set;
        }

        public User User { get; set; }

        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark
        {
            get;
            set;
        }
    }
}
