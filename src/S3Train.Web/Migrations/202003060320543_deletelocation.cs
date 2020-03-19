namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletelocation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Author_Product", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Author_Product", "Location", c => c.String(maxLength: 100));
        }
    }
}
