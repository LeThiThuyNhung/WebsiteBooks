namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "DatePayment", c => c.DateTime());
            AlterColumn("dbo.Order", "Status", c => c.String(maxLength: 100));
            AlterColumn("dbo.Order", "Note", c => c.String(maxLength: 300));
            AlterColumn("dbo.Order", "TotalMoney", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "TotalMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Order", "Note", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Order", "Status", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Order", "DatePayment", c => c.DateTime(nullable: false));
        }
    }
}
