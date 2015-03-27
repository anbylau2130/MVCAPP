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
                BirthDay = DateTime.Now,
                Education = "硕士",
                InUse = true,
                IsMarry = true,
                OfferTime = DateTime.Now,
                PassWord = "0",
                Professional = "计算机",
                RealName = "xycui",
                Remark = "测试管理员",
                UserName = "Eric"
            };
       context.Users.AddOrUpdate(Eric);

            Module mainModule = new Module() { Code = "Main", Name = "主框架", Desc = "主页面" };
            Module adminModule = new Module() { Code = "Admin", Name = "系统管理", Desc = "系统管理" };
            Module crmModule = new Module() { Code = "CRM", Name = "CRM系统", Desc = "CRM系统" };

            Menu pMenu = new Menu()
            {
                ID = Guid.Empty,
                OwnModule = mainModule
            };
            //主菜单中的Module必须是Main
            Menu XitongMenu = new Menu()
            {
                DisplayName = "系统配置",
                OwnAction = "Index",
                OwnController = "Home",
                IsLeaf = false,
                PMenu = pMenu,
                Module = adminModule,
                OwnModule = mainModule
            };
            //主菜单中的Module必须是Main
            Menu CRmMenu = new Menu() 
            {
                DisplayName = "CRM",
                OwnAction = "Index",
                OwnController = "Home",
                IsLeaf = false,
                PMenu = pMenu,
                Module = crmModule,
                OwnModule = mainModule
            };
            //子菜单中Module需要是个模块的Module
            Menu kehuMenu = new Menu()
            { 
                DisplayName = "客户管理",
                Controller = "Customer",
                Action = "Index",
                OwnAction = "Index",
                OwnController = "Home",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = CRmMenu,
                Module = crmModule,
                OwnModule = crmModule
            };
            //子菜单中Module需要是个模块的Module
            Menu organizationMenu = new Menu()
            {
                DisplayName = "组织机构",
                Controller = "Organization",
                Action = "Index",
                OwnAction = "Index",
                OwnController = "Home",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,
                OwnModule = adminModule
            };
           
            Menu userMenu = new Menu()
            {
                DisplayName = "用户管理",
                Controller = "User",
                Action = "Index",
                OwnAction = "Index",
                OwnController = "Home",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,
                OwnModule = adminModule
            };


            Menu caidanMenu = new Menu()
            {
                DisplayName = "菜单管理",
                Controller = "Menu",
                Action = "Index",
                OwnAction = "Index",
                OwnController = "Home",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,
                OwnModule = adminModule
            };
            context.Menus.AddOrUpdate(
                pMenu, XitongMenu,CRmMenu,organizationMenu,kehuMenu,userMenu, caidanMenu
                );

            Organization org1 = new Organization() { Name = "A集团", Remark = "A集团的信息", Sort = 1, User = Eric };
            Organization org11 = new Organization() { Name = "A集团采购部", POrganization=org1, Remark = "A集团的信息" ,Sort=1};
            Organization org111 = new Organization() { Name = "采购部1组", POrganization = org11, Remark = "A集团的信息", Sort = 1 };
            Organization org112 = new Organization() { Name = "采购部2组", POrganization = org11, Remark = "A集团的信息", Sort = 1 };
            Organization org12 = new Organization() { Name = "A集团IT部", POrganization = org1, Remark = "A集团的信息", Sort = 2 };
            Organization org13 = new Organization() { Name = "A集团运维部", POrganization = org1, Remark = "A集团的信息", Sort = 3 };
            Organization org14 = new Organization() { Name = "A集团人力资源", POrganization = org1, Remark = "A集团的信息", Sort = 4 };

            Organization org2 = new Organization() { Name = "B集团", Remark = "B集团的信息", Sort = 2, User = Eric };
            Organization org21 = new Organization() { Name = "B集团采购部", POrganization = org2, Remark = "B集团的信息", Sort = 1 };
            Organization org22 = new Organization() { Name = "B集团IT部", POrganization = org2, Remark = "B集团的信息", Sort = 2 };
            Organization org23 = new Organization() { Name = "B集团运维部", POrganization = org2, Remark = "B集团的信息", Sort = 3 };
            Organization org24 = new Organization() { Name = "B集团人力资源", POrganization = org2, Remark = "B集团的信息", Sort = 4 };

            context.Organizations.AddOrUpdate(
                org1, org11, org111, org112, org12, org13, org14, org2, org21, org22, org23, org24
                );
        }
    }
}
