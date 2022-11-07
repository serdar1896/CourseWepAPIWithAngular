namespace GulaylarCase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serdark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Slug = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        VideoUrl = c.String(unicode: false),
                        DateAdded = c.DateTime(),
                        LastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        CourseId = c.Int(),
                        DateAdded = c.DateTime(),
                        LastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        RoleId = c.Int(),
                        DateAdded = c.DateTime(),
                        LastModified = c.DateTime(),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DateAdded = c.DateTime(),
                        LastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WatchHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        CourseId = c.Int(),
                        DateAdded = c.DateTime(nullable: false),
                        Deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WatchHistory", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Subscribe", "CourseId", "dbo.Course");
            DropForeignKey("dbo.WatchHistory", "UserId", "dbo.User");
            DropForeignKey("dbo.Subscribe", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropIndex("dbo.WatchHistory", new[] { "CourseId" });
            DropIndex("dbo.WatchHistory", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.Subscribe", new[] { "CourseId" });
            DropIndex("dbo.Subscribe", new[] { "UserId" });
            DropTable("dbo.WatchHistory");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Subscribe");
            DropTable("dbo.Course");
        }
    }
}
