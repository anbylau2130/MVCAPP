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

            Module adminModule = new Module() { Code = "Admin", Name = "ϵͳ����", Desc = "ϵͳ����" };
            Module crmModule = new Module() { Code = "CRM", Name = "CRMϵͳ", Desc = "CRMϵͳ" };


            //���˵��е�Module������Main
            Menu XitongMenu = new Menu()
            {
                DisplayName = "ϵͳ����",
                IsLeaf = false,
                Module = adminModule,
            };
            //���˵��е�Module������Main
            Menu CRmMenu = new Menu() 
            {
                DisplayName = "CRM",
                IsLeaf = false,
                Module = crmModule,
            };
            //�Ӳ˵���Module��Ҫ�Ǹ�ģ���Module
            Menu kehuMenu = new Menu()
            { 
                DisplayName = "�ͻ�����",
                Controller = "Customer",
                Action = "Index",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = CRmMenu,
                Module = crmModule,
               
            };
            //�Ӳ˵���Module��Ҫ�Ǹ�ģ���Module
            Menu organizationMenu = new Menu()
            {
                DisplayName = "��֯����",
                Controller = "Organization",
                Action = "Index",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,
              
            };
           
            Menu userMenu = new Menu()
            {
                DisplayName = "�û�����",
                Controller = "User",
                Action = "Index",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,
              
            };


            Menu caidanMenu = new Menu()
            {
                DisplayName = "�˵�����",
                Controller = "Menu",
                Action = "Index",
                IsLeaf = false,
                OpenModel = 3,
                PMenu = XitongMenu,
                Module = adminModule,
            };
            Menu DictionaryMenu = new Menu() 
            {
                DisplayName = "�ֵ����",
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
           
            Organization org1 = new Organization() { Name = "A����", Remark = "A���ŵ���Ϣ", Sort = 1,OrgType = "organization"};

            Organization org11 = new Organization() { Name = "A���Ųɹ���", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 1, OrgType = "department" };
            Organization org111 = new Organization() { Name = "�ɹ���1��", POrganization = org11, Remark = "A���ŵ���Ϣ", Sort = 1, OrgType = "department" };
            Organization org112 = new Organization() { Name = "�ɹ���2��", POrganization = org11, Remark = "A���ŵ���Ϣ", Sort = 2, OrgType = "department" };

            Organization org12 = new Organization() { Name = "A����IT��", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 2, OrgType = "department" };
            Organization org13 = new Organization() { Name = "A������ά��", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 3, OrgType = "department" };
            Organization org14 = new Organization() { Name = "A����������Դ", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 4, OrgType = "department" };
            Organization org15 = new Organization() { Name = "A����CEO", POrganization = org1, Remark = "A�����ܾ���", Sort = 1, OrgType = "usergroup" };

            Organization org2 = new Organization() { Name = "B����", Remark = "B���ŵ���Ϣ", Sort = 2, OrgType = "organization" };
            Organization org21 = new Organization() { Name = "B���Ųɹ���", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 1, OrgType = "department" };
            Organization org22 = new Organization() { Name = "B����IT��", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 2, OrgType = "department" };
            Organization org23 = new Organization() { Name = "B������ά��", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 3, OrgType = "department" };
            Organization org24 = new Organization() { Name = "B����������Դ", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 4, OrgType = "department" };

            context.Organizations.AddOrUpdate(
                org1, org11, org111, org112, org12, org13, org14, org2, org21, org22, org23, org24, org15
                );


          
        }
    }
}
