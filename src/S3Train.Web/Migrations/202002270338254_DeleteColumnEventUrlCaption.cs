namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteColumnEventUrlCaption : DbMigration
    {
        public override void Up()
        {
            
            DropColumn("dbo.ProductAdvertisement", "EventUrlCaption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductAdvertisement", "EventUrlCaption", c => c.String(maxLength: 10));
        }
    }
}
