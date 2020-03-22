namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCol1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Order", "DatePayment", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "TotalMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "TotalMoney", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Order", "DatePayment", c => c.DateTime());
            DropColumn("dbo.OrderDetail", "Price");
        }
    }
}
