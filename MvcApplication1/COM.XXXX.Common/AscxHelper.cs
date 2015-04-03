using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace COM.XXXX.Common
{
    public class AscxHelper
    {
        public static HtmlString RenderControl<T>(string path)
                     where T : UserControl
        {
            Page p = new Page();
            T control = (T)p.LoadControl(path);
            p.Controls.Add(control);
            using (StringWriter sw = new StringWriter()) 
            {
                HttpContext.Current.Server.Execute(p, sw, false);
                return new HtmlString(sw.ToString());
            }

        }

    }
}
