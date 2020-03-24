namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upadatecol : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Order", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Order", "ApplicationUserId");
            RenameColumn(table: "dbo.Order", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AddColumn("dbo.OrderDetail", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Order", "Status", c => c.String(maxLength: 100));
            AlterColumn("dbo.Order", "Note", c => c.String(maxLength: 300));
            AlterColumn("dbo.Order", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Order", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Order", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Order", "ApplicationUserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Order", "Note", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Order", "Status", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.OrderDetail", "Price");
            RenameColumn(table: "dbo.Order", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Order", "ApplicationUserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Order", "ApplicationUser_Id");
        }
    }
}
