using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace COM.XXXX.Models.Admin
{
    [DataContract]
    public class DictionaryGroup:IModel
    {
        /// <summary>
        /// 字典组名
        /// </summary>
        [DataMember]
        public string GroupName { get; set; }

        /// <summary>
        /// 字典编码
        /// </summary>
        [DataMember]
        public string GroupCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }

    }
}
