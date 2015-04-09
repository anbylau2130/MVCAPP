using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web.UI.WebControls;

namespace COM.XXXX.Models.Admin
{
    [DataContract]
    public class Dictionary:IModel
    {
        /// <summary>
        /// 父节点ID
        /// </summary>
        [DataMember]
        public Guid? PDictionaryID { get; set; }
        /// <summary>
        /// 字典Key
        /// </summary>
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// 字典代码
        /// </summary>
        [DataMember] 
        public string Code { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        [DataMember]
        public string Value { get; set; }
        /// <summary>
        /// 字典排序
        /// </summary>
        [DataMember]
        public int Sort { get; set; }
        /// <summary>
        /// 字典描述
        /// </summary>
        [DataMember]
        public string Desc { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [DataMember]
        public string iconCls { get; set; }

        public virtual Dictionary PDictionary { get; set; }
    }
}
