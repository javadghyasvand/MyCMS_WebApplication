namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Long(nullable: false, identity: true),
                        PageGroupsId = c.Long(nullable: false),
                        PageTitle = c.String(nullable: false, maxLength: 250),
                        ShortDescription = c.String(nullable: false, maxLength: 350),
                        Description = c.String(nullable: false),
                        Visit = c.Long(nullable: false),
                        ImageName = c.String(),
                        ShowInSlider = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        GroupPage_GroupId = c.Long(),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.PageGroups", t => t.GroupPage_GroupId)
                .Index(t => t.GroupPage_GroupId);
            
            CreateTable(
                "dbo.PageComments",
                c => new
                    {
                        CommentId = c.Long(nullable: false, identity: true),
                        PageId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(),
                        WebSite = c.String(),
                        Comment = c.String(nullable: false, maxLength: 500),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        GroupId = c.Long(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "GroupPage_GroupId", "dbo.PageGroups");
            DropForeignKey("dbo.PageComments", "PageId", "dbo.Pages");
            DropIndex("dbo.PageComments", new[] { "PageId" });
            DropIndex("dbo.Pages", new[] { "GroupPage_GroupId" });
            DropTable("dbo.PageGroups");
            DropTable("dbo.PageComments");
            DropTable("dbo.Pages");
        }
    }
}
