namespace MobileSalesTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employee", "FirstMidName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "FirstMidName", c => c.String());
            AlterColumn("dbo.Employee", "LastName", c => c.String());
        }
    }
}
