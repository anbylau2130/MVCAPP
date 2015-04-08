using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COM.XXXX.Web.AspNetControl
{
    public partial class IconPicker : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
               
            }
        }


        public string ID { get; set; }

        public string Style { get; set; }

        private Guid _newGuid = Guid.NewGuid(); 
        public string NewGuid {
            get { return this._newGuid.ToString(); }
        }
    }
}