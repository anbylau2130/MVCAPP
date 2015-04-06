using COM.XXXX.Models.Admin;

namespace Repository.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class DBConfiguration 
    {
       
        public  static void Seed(TestDbContext context)
        {
       var Eric=      new User()
            {
                BirthDay = DateTime.Now.ToString("yyyy-MM-dd"),
                Education = "硕士",
                InUse = true,
                IsMarry = true,
                OfferTime = DateTime.Now.ToString("yyyy-MM-dd"),
                PassWord = "0",
                Professional = "计算机",
                RealName = "xycui",
                Remark = "测试管理员",
                UserName = "Eric"
            };
      

            Module adminModule = new Module() { Code = "Admin", Name = "系统管理", Desc = "系统管理" };
            Module crmModule = new Module() { Code = "CRM", Name = "CRM系统", Desc = "CRM系统" };


            //主菜单中的Module必须是Main
            Menu XitongMenu = new Menu()
            {
                DisplayName = "系统配置",
                IsLeaf = false,
                Module = adminModule,
            };
            //主菜单中的Module必须是Main
            Menu CRmMenu = new Menu() 
            {
                DisplayName = "CRM",
                IsLeaf = false,
                Module = crmModule,
            };
            //子菜单中Module需要是个模块的Module
            Menu kehuMenu = new Menu()
            { 
                DisplayName = "客户管理",
                Controller = "Customer",
                Action = "Index",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = CRmMenu,
                Module = crmModule,
               
            };
            //子菜单中Module需要是个模块的Module
            Menu organizationMenu = new Menu()
            {
                DisplayName = "组织机构",
                Controller = "Organization",
                Action = "Index",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,
              
            };
           
            Menu userMenu = new Menu()
            {
                DisplayName = "用户管理",
                Controller = "User",
                Action = "Index",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,
              
            };


            Menu caidanMenu = new Menu()
            {
                DisplayName = "菜单管理",
                Controller = "Menu",
                Action = "Index",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,
            };
            Menu DictionaryMenu = new Menu() 
            {
                DisplayName = "字典管理",
                Controller = "Dictionary",
                Action = "Index",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,

            };
            context.Menus.AddOrUpdate(
                 XitongMenu,CRmMenu,organizationMenu,kehuMenu,userMenu, caidanMenu,DictionaryMenu
                );

            Organization org1 = new Organization() { Name = "A集团", Remark = "A集团的信息", Sort = 1, OrgType = "department" };

            Organization org11 = new Organization() { Name = "A集团采购部", POrganization = org1, Remark = "A集团的信息", Sort = 1, OrgType = "department" };
            Organization org111 = new Organization() { Name = "采购部1组", POrganization = org11, Remark = "A集团的信息", Sort = 1, OrgType = "department" };
            Organization org112 = new Organization() { Name = "采购部2组", POrganization = org11, Remark = "A集团的信息", Sort = 2, OrgType = "department" };

            Organization org12 = new Organization() { Name = "A集团IT部", POrganization = org1, Remark = "A集团的信息", Sort = 2, OrgType = "department" };
            Organization org13 = new Organization() { Name = "A集团运维部", POrganization = org1, Remark = "A集团的信息", Sort = 3, OrgType = "department" };
            Organization org14 = new Organization() { Name = "A集团人力资源", POrganization = org1, Remark = "A集团的信息", Sort = 4, OrgType = "department" };
            Organization org15 = new Organization() { Name = "A集团CEO", POrganization = org1, Remark = "A集团总经理", Sort = 1, OrgType = "usergroup" };

            Organization org2 = new Organization() { Name = "B集团", Remark = "B集团的信息", Sort = 2, OrgType = "department" };
            Organization org21 = new Organization() { Name = "B集团采购部", POrganization = org2, Remark = "B集团的信息", Sort = 1, OrgType = "department" };
            Organization org22 = new Organization() { Name = "B集团IT部", POrganization = org2, Remark = "B集团的信息", Sort = 2, OrgType = "department" };
            Organization org23 = new Organization() { Name = "B集团运维部", POrganization = org2, Remark = "B集团的信息", Sort = 3, OrgType = "department" };
            Organization org24 = new Organization() { Name = "B集团人力资源", POrganization = org2, Remark = "B集团的信息", Sort = 4, OrgType = "department" };
            Eric.Organization = org15;
                 context.Users.AddOrUpdate(Eric);
            context.Organizations.AddOrUpdate(
                org1, org11, org111, org112, org12, org13, org14, org2, org21, org22, org23, org24, org15
                );


          
        }
    }
}
