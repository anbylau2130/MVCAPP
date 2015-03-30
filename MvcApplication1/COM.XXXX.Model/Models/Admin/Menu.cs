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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace COM.XXXX.Models.Admin
{
    [Serializable]
    [DataContract]
    public class Menu : IModel
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [DataMember]
        public int? Width { get; set; } 
        /// <summary>
        /// 高度 
        /// </summary>
        [DataMember]
        public int? Height { get; set; }
        /// <summary>
        /// 用于排序的字段,如果是列表菜单，则为0，否则为排序列
        /// </summary>
        [DataMember]
        public int? SortKey { get; set; }
        /// <summary>
        /// 导航Controller
        /// </summary>
        [DataMember]
        public string Controller { get; set; }
        /// <summary>
        /// 导航Action
        /// </summary>
        [DataMember]
        public string Action { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [DataMember]
        public string IconCls { get; set; }
        /// <summary>
        /// 叶子节点对应一个URL
        /// </summary>
        [DataMember]
        public bool IsLeaf { get; set; }
        
        /// <summary>
        /// 窗口打开类型
        /// </summary>
        [DataMember]
        public int? OpenModel { get; set; }


        [DataMember]
        public Guid? PMenuID { get; set; } 

        public virtual Menu PMenu { get; set; }

        /// <summary>
        /// 导航模块
        /// </summary>
        [DataMember]
        public Guid? ModuleID { get; set; }

        [DataMember]
        public virtual Module Module { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public  string Desc { get; set; }


        /// <summary>
        /// easyui加载界面使用
        /// </summary>
        [NotMapped]
        [DataMember]
        public List<Menu> children { get; set; }
    }
}
