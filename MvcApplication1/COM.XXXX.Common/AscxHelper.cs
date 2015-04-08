using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

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

        public static HtmlString RenderControl<T>(string path, Dictionary<string, object> value)where  T:UserControl
        {
            Page page=new Page();
            HtmlForm form=new HtmlForm();
            T control=(T)page.LoadControl(path);
            form.Controls.Add(control);
            page.Controls.Add(form);
            AscxSetValue(control,value);
            using (StringWriter sw=new  StringWriter())
            {
                HttpContext.Current.Server.Execute(page,sw,false);
                return new HtmlString(sw.ToString());
            }
        }

        private static void AscxSetValue(UserControl uc, Dictionary<string, object> dicValue)
        {
            if (dicValue==null)
            {
                return;
            }
            foreach (KeyValuePair<string,object> kvp in dicValue)
            {
                PropertyInfo pi = uc.GetType().GetProperty(kvp.Key, BindingFlags.Public | BindingFlags.Instance)
                    ;
                if (null!=pi&&pi.CanWrite)
                {
                    pi.SetValue(uc,kvp.Value,null);
                }
            }
        }

    }
}
