namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Author_Product", "AuthorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Author_Product", "ProductId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Author_Product", "AuthorId");
            CreateIndex("dbo.Author_Product", "ProductId");
            AddForeignKey("dbo.Author_Product", "AuthorId", "dbo.Author", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Author_Product", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Author_Product", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Author_Product", "AuthorId", "dbo.Author");
            DropIndex("dbo.Author_Product", new[] { "ProductId" });
            DropIndex("dbo.Author_Product", new[] { "AuthorId" });
            DropColumn("dbo.Author_Product", "ProductId");
            DropColumn("dbo.Author_Product", "AuthorId");
        }
    }
}
