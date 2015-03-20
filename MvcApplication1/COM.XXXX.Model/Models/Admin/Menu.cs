/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：Menu
// 文件功能描述：
//
// 创建标识：xycui 2014/12/5 14:04:00
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace COM.XXXX.Models.Admin
{
    public class Menu : IModel
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int? Width { get; set; } 
        /// <summary>
        /// 高度 
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// 用于排序的字段,如果是列表菜单，则为0，否则为排序列
        /// </summary>
        public int? SortKey { get; set; }
        /// <summary>
        /// 导航Controller
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// 导航Action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 所属页面controller
        /// </summary>
        public string OwnController { get; set; }
        /// <summary>
        /// 所属页面Action
        /// </summary>
        public string OwnAction { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string IconCls { get; set; }
        /// <summary>
        /// 叶子节点对应一个URL
        /// </summary>
        public bool IsLeaf { get; set; }
        
        /// <summary>
        /// 窗口打开类型
        /// </summary>
        public int? OpenModel { get; set; }


        public  Guid? PMenuID { get; set; } 

        public virtual Menu PMenu { get; set; }

        public Guid? ModuleID { get; set; } 

        public virtual Module Module { get; set; }


    }
}
