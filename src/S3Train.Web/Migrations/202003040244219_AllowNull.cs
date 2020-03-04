namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Author_Product", "Role", c => c.String(maxLength: 100));
            AlterColumn("dbo.Author_Product", "Location", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Author_Product", "Location", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Author_Product", "Role", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
