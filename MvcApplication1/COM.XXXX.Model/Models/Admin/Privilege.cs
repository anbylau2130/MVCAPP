/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：Privilege
// 文件功能描述：
//
// 创建标识：xycui 2014/12/11 9:51:23
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace COM.XXXX.Models.Admin
{
    /// <summary>
    ///1，把菜单的配置放在数据库上，每一个菜单对于一个唯一的编码MenuNo，每一个“叶节点”的菜单项对于一个页面(url)。
    ///2，把按钮的配置放在数据库上，并归属于一个菜单项上（其实就是挂在某一个页面上）。应该一个页面可能会有几个按钮组，比如说有两个列表，这两个列表都需要有“增加、修改、删除”。所以需要增加一个按钮分组的字段来区分。
    ///3,把菜单权限分配给用户/角色，PrivilegeMaster为"User"或"Role",PrivilegeMasterValue为UserID或RoleID,PrivilegeAccess为“Menu",PrivilegeAccessValue为MenuNo,PrivilegeOperation为"enabled"
    ///4,把按钮权限分配给用户/角色，PrivilegeMaster为"User"或"Role",PrivilegeMasterValue为UserID或RoleID,PrivilegeAccess为“Button",PrivilegeAccessValue为BtnID,PrivilegeOperation为"enabled"
    ///5,如果需要禁止单个用户的权限，PrivilegeOperation 设置为"disabled"。
    /// </summary>
    public class Privilege : IModel
    {

        /// <summary>
        /// PrivilegeMaster为"User"或"Role"
        /// </summary>
        public string Master { get; set; }

        /// <summary>
        /// PrivilegeMasterValue为UserID或RoleID
        /// </summary>
        public string MasterValue { get; set; }

        /// <summary>
        /// PrivilegeAccess为“Menu"或者Button
        /// </summary>
        public string Access { get; set; } 

        /// <summary>
        /// PrivilegeAccessValue为MenuID或者BtnID
        /// </summary>
        public string AccessValue { get; set; }

        /// <summary>
        /// 如果需要禁止单个用户的权限，PrivilegeOperation 设置为"disabled"。
        /// </summary>  
        public string Operation { get; set; }

    }
}
