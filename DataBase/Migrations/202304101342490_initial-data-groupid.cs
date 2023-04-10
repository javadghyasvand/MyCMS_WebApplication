namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdatagroupid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "GroupPage_GroupId", "dbo.PageGroups");
            DropIndex("dbo.Pages", new[] { "GroupPage_GroupId" });
            RenameColumn(table: "dbo.Pages", name: "GroupPage_GroupId", newName: "GroupId");
            AlterColumn("dbo.Pages", "GroupId", c => c.Long(nullable: false));
            CreateIndex("dbo.Pages", "GroupId");
            AddForeignKey("dbo.Pages", "GroupId", "dbo.PageGroups", "GroupId", cascadeDelete: true);
            DropColumn("dbo.Pages", "PageGroupsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "PageGroupsId", c => c.Long(nullable: false));
            DropForeignKey("dbo.Pages", "GroupId", "dbo.PageGroups");
            DropIndex("dbo.Pages", new[] { "GroupId" });
            AlterColumn("dbo.Pages", "GroupId", c => c.Long());
            RenameColumn(table: "dbo.Pages", name: "GroupId", newName: "GroupPage_GroupId");
            CreateIndex("dbo.Pages", "GroupPage_GroupId");
            AddForeignKey("dbo.Pages", "GroupPage_GroupId", "dbo.PageGroups", "GroupId");
        }
    }
}
