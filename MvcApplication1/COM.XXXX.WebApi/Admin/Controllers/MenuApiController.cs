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
    public class MenuApiController : ApiControllerBase<MenuRepository, Menu>
    {

        public MenuApiController()
        {
            base.SetRepository();
        }

        public IEnumerable<UITree> GetMenusByModule(string modulecode, Guid? id)
        {
            if (string.IsNullOrEmpty(modulecode))
            {
                return null;
            }
            var  moduleMenus= Repository.Query(menu => menu.Module.Code == modulecode && menu.PMenuID == id).OrderBy(menu => menu.SortKey).ToList();

            List<UITree> menulst = new List<UITree>();
            foreach (Menu item in moduleMenus)
            {
                UITree menu = new UITree() 
                {
                    id = item.ID.ToString(), 
                    text = item.DisplayName,
                    iconCls = item.IconCls,
                    attributes = new
                    {
                        URL = string.Format("/{0}/{1}/{2}", item.Module.Code, item.Controller, item.Action),
                        Width = item.Width,
                        Height = item.Height,
                        OpenType = item.OpenModel
                    }
                };
                if (!item.IsLeaf)
                {
                    var sub = GetMenusByModule(modulecode,item.ID);
                    if (sub != null)
                    {
                        menu.children.AddRange(sub);
                    }
                }
                menulst.Add(menu);
            }
            return menulst;

        }


        //public IEnumerable<Menu> GetMenusByPage(string modulecode, string controller, string action)
        //{
        //    return Repository.GetMenusByPage(modulecode, controller, action);
        //}

        //public IEnumerable<UITree> GetSubMenusByPMenu(Guid id, string modulecode)
        //{
        //    IEnumerable<Menu> submenus = Repository.GetSubMenusByPMenu(id, modulecode);
        //    List<UITree> menulst = new List<UITree>();
        //    foreach (Menu item in submenus)
        //    {
        //        UITree menu = new UITree()
        //        {
        //            id = item.ID.ToString(),
        //            text = item.DisplayName,
        //            iconCls = item.IconCls,
        //            attributes = new
        //            {
        //                URL = string.Format("/{0}/{1}/{2}", item.Module.Code, item.Controller, item.Action),
        //                Width = item.Width,
        //                Height = item.Height,
        //                OpenType = item.OpenModel
        //            }
        //        };
        //        if (!item.IsLeaf)
        //        {
        //            var sub = GetSubMenusByPMenu(item.ID, modulecode);
        //            if (sub != null)
        //            {
        //                menu.children.AddRange(sub);
        //            }
        //        }
        //        menulst.Add(menu);
        //    }
        //    return menulst;
        //}

        //public IEnumerable<Menu> GetMenusByPMenu(Guid id, string modulecode)
        //{
        //    return Repository.GetMenusByPMenu(id, modulecode);
        //}
        /// <summary>
        /// 获取组织机构TreeGrid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<Menu> GetMenuTree(Guid? id)
        {
            List<Menu> lst = new List<Menu>();
            if (string.IsNullOrEmpty(id.ToString()))
            {
                lst.AddRange(Repository.Query(menu => menu.PMenuID == null).OrderBy(org => org.SortKey).ToList());
            }
            else
            {
                lst.AddRange(Repository.Query(menu => menu.PMenuID == id).OrderBy(org => org.SortKey).ToList());
            }

            for (int i = 0; i < lst.Count; i++)
            {
                var children = GetMenuTree(lst[i].ID);
                if (children.Any() && children != null)
                {
                    lst[i].children = new List<Menu>();
                    lst[i].children.AddRange(children);
                }
            }

            return lst;
        }

        /// <summary>
        /// 获取组织机构TreeGrid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<Menu> GetMenuTreeByModule(Guid? id,Guid? moduleid)
        {
            List<Menu> lst = new List<Menu>();
            Guid module=Guid.Parse(moduleid.ToString());
            if (string.IsNullOrEmpty(id.ToString()) && string.IsNullOrEmpty(moduleid.ToString())) 
            {
                lst.AddRange(Repository.Query(menu => menu.PMenuID == null && menu.ModuleID == module).OrderBy(org => org.SortKey).ToList());
            }
            else
            {
                lst.AddRange(Repository.Query(menu => menu.PMenuID == id && menu.ModuleID == module).OrderBy(org => org.SortKey).ToList());
            }

            for (int i = 0; i < lst.Count; i++)
            {
                var children = GetMenuTreeByModule(lst[i].ID,moduleid);
                if (children.Any() && children != null)
                {
                    lst[i].children = new List<Menu>();
                    lst[i].children.AddRange(children);
                }
            }

            return lst;
        }
    }
}