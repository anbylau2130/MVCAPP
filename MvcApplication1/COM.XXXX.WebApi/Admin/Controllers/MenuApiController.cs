using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using COM.XXXX.EasyUIModels;
using COM.XXXX.Models;
using COM.XXXX.Models.Admin;
using Repository.DAL.Repository;

namespace COM.XXXX.WebApi.Admin.Controllers
{
    public class MenuApiController : ApiControllerBase<MenuRepository,Menu>
    {

        public MenuApiController()
        {
            base.SetRepository();
        }

        public IEnumerable<Menu> GetMenusByPage(string modulecode,string controller, string action)
        {
            return Repository.GetMenusByPage(modulecode, controller, action);
        }

        public IEnumerable<UITree> GetSubMenusByPMenu(Guid id, string modulecode)
        {
            IEnumerable<Menu> submenus = Repository.GetSubMenusByPMenu(id,modulecode);
            List<UITree> menulst = new List<UITree>();
            foreach (Menu item in submenus)
            {
                UITree menu = new UITree()
                {
                    id = item.ID.ToString(),
                    text = item.DisplayName,
                    iconCls = item.IconCls,
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