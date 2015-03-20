﻿using COM.XXXX.Models.Admin;
using Repository.Domain;
using Repository.Domain.Infrastructure;
/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：MenuRepository
// 文件功能描述：
//
// 创建标识：xycui 2014/12/5 15:22:57
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.DAL.Repository
{
    public  class MenuRepository:Repository<Menu>
    {
        public MenuRepository()
        {
        }

        public MenuRepository(TestDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// 获取指定模块的指定页面的菜单
        /// </summary>
        /// <param name="modulecode"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public List<Menu> GetMenusByPage(string modulecode,string controller,string action)
        {
             //&& !menu.IsLeaf
            var temp= base.Query( menu => menu.PMenuID==0&&menu.OwnController == controller && menu.OwnAction == action && modulecode==menu.Module.Code).ToList();
            return temp;
        }

        /// <summary>
        /// 根据模块编号和父菜单获取子菜单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modulecode"></param>
        /// <returns></returns>
        public List<Menu> GetMenusByPMenu(int id, string modulecode)
        {
            return base.Query(menu => menu.PMenuID == id && menu.IsLeaf && modulecode == menu.Module.Code).ToList();
        }

        /// <summary>
        /// 根据模块编号和和父菜单获取所有子菜单的tree数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modulecode"></param>
        /// <returns></returns>
        public List<Menu> GetSubMenusByPMenu(int id, string modulecode)
        {
            return  base.Query(menu => menu.PMenuID == id  && modulecode == menu.Module.Code).ToList();
        }  
        
    }
}
