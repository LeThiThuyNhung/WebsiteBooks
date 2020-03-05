namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpromotion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PromotionDetail",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        PromotionId = c.Guid(nullable: false),
                        PromotionPercent = c.Double(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Promotion", t => t.PromotionId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PromotionId);
            
            CreateTable(
                "dbo.Promotion",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PromotionName = c.String(nullable: false, maxLength: 300),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PromotionDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.PromotionDetail", "PromotionId", "dbo.Promotion");
            DropIndex("dbo.PromotionDetail", new[] { "PromotionId" });
            DropIndex("dbo.PromotionDetail", new[] { "ProductId" });
            DropTable("dbo.Promotion");
            DropTable("dbo.PromotionDetail");
        }
    }
}
