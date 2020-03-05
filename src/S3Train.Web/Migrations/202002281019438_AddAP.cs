namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author_Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Role = c.String(nullable: false, maxLength: 100),
                        Location = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Author_Product");
        }
    }
}
