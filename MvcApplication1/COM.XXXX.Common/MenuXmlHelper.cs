/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：ConfigXmlHelper
// 文件功能描述：
//
// 创建标识：xycui 2014/8/27 16:19:58
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace Com.XXXX.Common
{
    public class MenuXmlHelper
    {
        public string ConfigPath { get; set; }

        public XElement ElementDocument { get; set; }

        public IEnumerable<XElement> Elements { get; set; }

        public MenuXmlHelper(string path)
        {
            ConfigPath = path;
            ElementDocument = XElement.Load(path);
        }

        /// <summary>
        /// 根据 Xml获取菜单列表json数据集
        /// </summary>
        /// <returns></returns>
        public string GetJson(Controller controller)
        {
            var menus =    from menu in ElementDocument.Elements("menu")
                          orderby menu.Attribute("order").Value ascending
                          select menu;
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
           
            
            foreach (var menu in menus)
            {
                sb.Append("{");
                sb.Append("\"menuName\":\"" + menu.Attribute("name").Value + "\",");
                sb.Append("\"items\":["); 
                var items = from item in menu.Elements("item")
                            orderby item.Attribute("order").Value ascending
                            select item;
                
                foreach (var item in items)
                {
                    sb.Append("{");
                    sb.Append("\"text\":\"" + item.Attribute("text").Value + "\",");
                    sb.Append("\"leaf\":\"true\",");
                    sb.Append("\"url\":\"" + controller.Url.Content(item.Element("url").Value) + "\"");
                    sb.Append("},");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");
                sb.Append("},");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();

        }

    }
}
