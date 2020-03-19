namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableStaff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PositionId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ImagePath = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        Sex = c.String(nullable: false, maxLength: 3),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Position", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId);
            
            AlterColumn("dbo.Category", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Product", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Publisher", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.ProductAdvertisement", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staff", "PositionId", "dbo.Position");
            DropIndex("dbo.Staff", new[] { "PositionId" });
            AlterColumn("dbo.ProductAdvertisement", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Publisher", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Product", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Category", "CreatedDate", c => c.DateTime(nullable: false));
            DropTable("dbo.Staff");
            DropTable("dbo.Position");
        }
    }
}
