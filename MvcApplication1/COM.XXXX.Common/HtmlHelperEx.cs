using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace COM.XXXX.Common
{
    public static class HtmlHelperEx
    {
        /// <summary>
        /// 加载服务器端控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static HtmlString RenderContrl<T>(this HtmlHelper helper, string path) where T:UserControl
        {
            return AscxHelper.RenderControl<T>(path);
        }

        /// <summary>
        /// 加载服务器端控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static HtmlString RenderContrl<T>(this HtmlHelper helper, string path,Dictionary<string,object>  dictionary) where T : UserControl
        {
            return AscxHelper.RenderControl<T>(path,dictionary);
        }
    }
}
