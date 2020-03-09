namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfkpd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductAdvertisement", "ProductId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ProductAdvertisement", "ProductId");
            AddForeignKey("dbo.ProductAdvertisement", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductAdvertisement", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductAdvertisement", new[] { "ProductId" });
            DropColumn("dbo.ProductAdvertisement", "ProductId");
        }
    }
}
