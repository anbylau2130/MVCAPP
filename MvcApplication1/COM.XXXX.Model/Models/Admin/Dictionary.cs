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
        [DataMember]
        public Guid? PDictionaryID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember] 
        public string Code { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public int Sort { get; set; }
        [DataMember]
        public string Desc { get; set; }

        public virtual Dictionary PDictionary { get; set; }
    }
}
