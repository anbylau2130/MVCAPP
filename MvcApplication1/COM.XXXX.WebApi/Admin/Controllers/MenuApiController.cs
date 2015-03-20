using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using COM.XXXX.Models;
using COM.XXXX.Models.Admin;
using Repository.DAL.Repository;

namespace COM.XXXX.WebApi.Admin.Controllers
{
    public class MenuApiController : ApiControllerBase<MenuRepository,Menu>
    {
        public class UIMenu
        {
            public string id { get; set; }
            public string text { get; set; }
            public string iconCls { get; set; }
            public string Checked { get; set; }
            public string state { get; set; }
            public object attributes { get; set; }
            List<UIMenu>  _children=new List<UIMenu>();
            public List<UIMenu> children {
                get { return _children; }
                set { _children = value; }
            }
        }


        public MenuApiController()
        {
            base.SetRepository();
        }

        public IEnumerable<Menu> GetMenusByPage(string modulecode,string controller, string action)
        {
            return Repository.GetMenusByPage(modulecode, controller, action);
        }

        public IEnumerable<UIMenu> GetSubMenusByPMenu(Guid id, string modulecode)
        {
            IEnumerable<Menu> submenus = Repository.GetSubMenusByPMenu(id,modulecode);
            List<UIMenu> menulst = new List<UIMenu>();
            foreach (Menu item in submenus)
            {
                UIMenu menu = new UIMenu() {id = item.ID.ToString(), text = item.DisplayName, iconCls = item.IconCls,
                    attributes=new 
                    {
                        URL= string.Format("/{0}/{1}/{2}",item.Module.Code,item.Controller,item.Action),
                        Width=item.Width,
                        Height=item.Height,
                        OpenType=item.OpenModel
                    }};
                if (!item.IsLeaf)
                {
                    var sub = GetSubMenusByPMenu(item.ID, modulecode);
                    if (sub!=null)
                    {
                        menu.children.AddRange(sub);
                    }
                }
                menulst.Add(menu);
            }
            return menulst;
        }

        public IEnumerable<Menu> GetMenusByPMenu(Guid id,string modulecode)
        {
            return Repository.GetMenusByPMenu(id, modulecode);
        }

    }
}