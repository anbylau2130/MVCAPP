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
                Education = "˶ʿ",
                InUse = true,
                IsMarry = true,
                OfferTime = DateTime.Now.ToString("yyyy-MM-dd"),
                PassWord = "0",
                Professional = "�����",
                RealName = "xycui",
                Remark = "���Թ���Ա",
                UserName = "Eric"
            };
      

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

            Organization org1 = new Organization() { Name = "A����", Remark = "A���ŵ���Ϣ", Sort = 1, OrgType = "department" };

            Organization org11 = new Organization() { Name = "A���Ųɹ���", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 1, OrgType = "department" };
            Organization org111 = new Organization() { Name = "�ɹ���1��", POrganization = org11, Remark = "A���ŵ���Ϣ", Sort = 1, OrgType = "department" };
            Organization org112 = new Organization() { Name = "�ɹ���2��", POrganization = org11, Remark = "A���ŵ���Ϣ", Sort = 2, OrgType = "department" };

            Organization org12 = new Organization() { Name = "A����IT��", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 2, OrgType = "department" };
            Organization org13 = new Organization() { Name = "A������ά��", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 3, OrgType = "department" };
            Organization org14 = new Organization() { Name = "A����������Դ", POrganization = org1, Remark = "A���ŵ���Ϣ", Sort = 4, OrgType = "department" };
            Organization org15 = new Organization() { Name = "A����CEO", POrganization = org1, Remark = "A�����ܾ���", Sort = 1, OrgType = "usergroup" };

            Organization org2 = new Organization() { Name = "B����", Remark = "B���ŵ���Ϣ", Sort = 2, OrgType = "department" };
            Organization org21 = new Organization() { Name = "B���Ųɹ���", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 1, OrgType = "department" };
            Organization org22 = new Organization() { Name = "B����IT��", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 2, OrgType = "department" };
            Organization org23 = new Organization() { Name = "B������ά��", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 3, OrgType = "department" };
            Organization org24 = new Organization() { Name = "B����������Դ", POrganization = org2, Remark = "B���ŵ���Ϣ", Sort = 4, OrgType = "department" };
            Eric.Organization = org15;
                 context.Users.AddOrUpdate(Eric);
            context.Organizations.AddOrUpdate(
                org1, org11, org111, org112, org12, org13, org14, org2, org21, org22, org23, org24, org15
                );

            Dictionary rootdic = new Dictionary() { Code = "System", Title = "�����ֵ�", PDictionaryID = null, Sort = 0, Desc = "���ڵ�" };
            Dictionary OpenTypedic = new Dictionary() { Code = "OpenType", Title = "Ӧ�ô�����", PDictionary = rootdic, Desc = "Ӧ�ó��������" };
            Dictionary OpenTypedic1 = new Dictionary() {  Title = "Tab��", Value = "1", PDictionary = OpenTypedic, Desc = "Ӧ�ó��������-Tab��" };
            Dictionary OpenTypedic2 = new Dictionary() {  Title = "�Ի����", Value = "2", PDictionary = OpenTypedic, Desc = "Ӧ�ó��������-�Ի����" };
            Dictionary OpenTypedic3 = new Dictionary() {  Title = "ģ̬�Ի����", Value = "3", PDictionary = OpenTypedic, Desc = "Ӧ�ó��������-ģ̬�Ի����" };

            Dictionary orgTypedic = new Dictionary() { Code = "OrgType", Title = "��֯��������", PDictionary = rootdic, Desc = "��֯��������" };
            Dictionary orgTypedic1 = new Dictionary() {  Title = "����",Value = "1",  PDictionary = orgTypedic, Desc = "��֯��������" };
            Dictionary orgTypedic2 = new Dictionary() {  Title = "����",Value = "2",  PDictionary = orgTypedic, Desc = "��֯��������" };
            Dictionary orgTypedic3 = new Dictionary() { Title = "ְ��", Value = "3", PDictionary = orgTypedic, Desc = "��֯��������" };

            context.Dictionarys.AddOrUpdate(rootdic, OpenTypedic, OpenTypedic1, OpenTypedic2, OpenTypedic3, orgTypedic, orgTypedic1, orgTypedic2, orgTypedic3);
        }
    }
}
