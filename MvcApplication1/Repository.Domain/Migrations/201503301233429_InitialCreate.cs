namespace Repository.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buttons",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        BtnName = c.String(),
                        BtnNo = c.String(),
                        BtnClass = c.String(),
                        BtnIcon = c.String(),
                        BtnStatus = c.String(),
                        MenuID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menus", t => t.MenuID)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Width = c.Int(),
                        Height = c.Int(),
                        SortKey = c.Int(),
                        Controller = c.String(),
                        Action = c.String(),
                        IconCls = c.String(),
                        IsLeaf = c.Boolean(nullable: false),
                        OpenModel = c.Int(),
                        PMenuID = c.Guid(),
                        ModuleID = c.Guid(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Modules", t => t.ModuleID)
                .ForeignKey("dbo.Menus", t => t.PMenuID)
                .Index(t => t.PMenuID)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Desc = c.String(),
                        PicUrl = c.String(),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DictionaryGroups",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        GroupName = c.String(),
                        GroupCode = c.String(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dictionaries",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        GroupCode = c.String(),
                        Key = c.String(),
                        Value = c.String(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        POrganizationID = c.Guid(),
                        Sort = c.Int(nullable: false),
                        UserID = c.Guid(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.POrganizationID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.POrganizationID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        RealName = c.String(),
                        UserName = c.String(),
                        PassWord = c.String(),
                        OfferTime = c.DateTime(),
                        Education = c.String(),
                        Professional = c.String(),
                        IsMarry = c.Boolean(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        InUse = c.Boolean(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Privileges",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Master = c.String(),
                        MasterValue = c.String(),
                        Access = c.String(),
                        AccessValue = c.String(),
                        Operation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleRights",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        RoleID = c.Guid(),
                        UserID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.RoleID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleRights", "UserID", "dbo.Users");
            DropForeignKey("dbo.RoleRights", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Organizations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Organizations", "POrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Buttons", "MenuID", "dbo.Menus");
            DropForeignKey("dbo.Menus", "PMenuID", "dbo.Menus");
            DropForeignKey("dbo.Menus", "ModuleID", "dbo.Modules");
            DropIndex("dbo.RoleRights", new[] { "UserID" });
            DropIndex("dbo.RoleRights", new[] { "RoleID" });
            DropIndex("dbo.Organizations", new[] { "UserID" });
            DropIndex("dbo.Organizations", new[] { "POrganizationID" });
            DropIndex("dbo.Menus", new[] { "ModuleID" });
            DropIndex("dbo.Menus", new[] { "PMenuID" });
            DropIndex("dbo.Buttons", new[] { "MenuID" });
            DropTable("dbo.Roles");
            DropTable("dbo.RoleRights");
            DropTable("dbo.Privileges");
            DropTable("dbo.Users");
            DropTable("dbo.Organizations");
            DropTable("dbo.Dictionaries");
            DropTable("dbo.DictionaryGroups");
            DropTable("dbo.Modules");
            DropTable("dbo.Menus");
            DropTable("dbo.Buttons");
        }
    }
}
