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
                Education = "˶ʿ",
                InUse = true,
                IsMarry = true,
                OfferTime = DateTime.Now,
                PassWord = "0",
                Professional = "�����",
                RealName = "xycui",
                Remark = "���Թ���Ա",
                UserName = "Eric"
            };
       context.Users.AddOrUpdate(Eric);

            Module mainModule = new Module() { Code = "Main", Name = "�����", Desc = "��ҳ��" };
            Module adminModule = new Module() { Code = "Admin", Name = "ϵͳ����", Desc = "ϵͳ����" };
            Module crmModule = new Module() { Code = "CRM", Name = "CRMϵͳ", Desc = "CRMϵͳ" };

            Menu pMenu = new Menu()
            {
                ID = Guid.Empty,
                OwnModule = mainModule
            };
            //���˵��е�Module������Main
            Menu XitongMenu = new Menu()
            {
                DisplayName = "ϵͳ����",
                OwnAction = "Index",
                OwnController = "Home",
                IsLeaf = false,
                PMenu = pMenu,
                Module = adminModule,
                OwnModule = mainModule
            };
            //���˵��е�Module������Main
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
            //�Ӳ˵���Module��Ҫ�Ǹ�ģ���Module
            Menu kehuMenu = new Menu()
            { 
                DisplayName = "�ͻ�����",
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
            //�Ӳ˵���Module��Ҫ�Ǹ�ģ���Module
            Menu organizationMenu = new Menu()
            {
                DisplayName = "��֯����",
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
                DisplayName = "�û�����",
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
                DisplayName = "�˵�����",
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

            Organization org1 = new Organization() { Name = "A����", Remark = "A���ŵ���Ϣ", Sort = 1, User = Eric };
            Organization org11 = new Organization() { Name = "A���Ųɹ���", POrganization=org1, Remark = "A���ŵ���Ϣ" ,Sort=1};
            Organization org111 = new Organization() { Name = "�ɹ���1��", POrganization = org11, Remark = "A���ŵ���Ϣ", Sort = 1 };
            Organization org112 = new Organization() { Name = "�ɹ���2��", POrganization = org11, Remark = "A���ŵ���Ϣ", Sort = 1 };
            Organization org12 = new Organization() { Name = "A����IT��", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 2 };
            Organization org13 = new Organization() { Name = "A������ά��", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 3 };
            Organization org14 = new Organization() { Name = "A����������Դ", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 4 };

            Organization org2 = new Organization() { Name = "B����", Remark = "B���ŵ���Ϣ", Sort = 2, User = Eric };
            Organization org21 = new Organization() { Name = "B���Ųɹ���", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 1 };
            Organization org22 = new Organization() { Name = "B����IT��", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 2 };
            Organization org23 = new Organization() { Name = "B������ά��", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 3 };
            Organization org24 = new Organization() { Name = "B����������Դ", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 4 };

            context.Organizations.AddOrUpdate(
                org1, org11, org111, org112, org12, org13, org14, org2, org21, org22, org23, org24
                );
        }
    }
}
