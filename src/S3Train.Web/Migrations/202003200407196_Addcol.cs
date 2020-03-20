namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "ApplicationUserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Order", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Order", "ApplicationUser_Id");
            AddForeignKey("dbo.Order", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Order", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Order", "ApplicationUser_Id");
            DropColumn("dbo.Order", "ApplicationUserId");
        }
    }
}
