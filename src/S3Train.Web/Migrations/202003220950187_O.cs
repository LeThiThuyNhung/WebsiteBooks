namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class O : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Order", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Order", "ApplicationUserId");
            RenameColumn(table: "dbo.Order", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Order", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Order", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Order", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Order", "ApplicationUserId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Order", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Order", "ApplicationUserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Order", "ApplicationUser_Id");
        }
    }
}
