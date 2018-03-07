namespace MobileSalesTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employee", name: "FirstMidName", newName: "First Name");
            CreateTable(
                "dbo.AccountType",
                c => new
                {
                    ConsumerID = c.Int(nullable: false),
                    Location = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.ConsumerID)
                .ForeignKey("dbo.Consumer", t => t.ConsumerID)
                .Index(t => t.ConsumerID);

            CreateTable(
                "dbo.Consumer",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    LastName = c.String(maxLength: 50),
                    FirstName = c.String(maxLength: 50),
                    HireDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Department",
                c => new
                {
                    DepartmentID = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 50),
                    Budget = c.Decimal(nullable: false, storeType: "money"),
                    StartDate = c.DateTime(nullable: false),
                    ConsumerID = c.Int(),
                })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Consumer", t => t.ConsumerID)
                .Index(t => t.ConsumerID);

            CreateTable(
                "dbo.PromotionConsumer",
                c => new
                {
                    PromotionID = c.Int(nullable: false),
                    ConsumerID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.PromotionID, t.ConsumerID })
                .ForeignKey("dbo.Promotion", t => t.PromotionID, cascadeDelete: true)
                .ForeignKey("dbo.Consumer", t => t.ConsumerID, cascadeDelete: true)
                .Index(t => t.PromotionID)
                .Index(t => t.ConsumerID);

            // Create  a department for course to point to.
            Sql("INSERT INTO dbo.Department (Name, Budget, StartDate) VALUES ('Temp', 0.00, GETDATE())");
            //  default value for FK points to department created above.
            AddColumn("dbo.Promotion", "DepartmentID", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Promotion", "AccountType_ConsumerID", c => c.Int());
            AlterColumn("dbo.Employee", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employee", "First Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Promotion", "Title", c => c.String(maxLength: 50));
            CreateIndex("dbo.Promotion", "DepartmentID");
            CreateIndex("dbo.Promotion", "AccountType_ConsumerID");
            AddForeignKey("dbo.Promotion", "AccountType_ConsumerID", "dbo.AccountType", "ConsumerID");
            AddForeignKey("dbo.Promotion", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Promotion", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "ConsumerID", "dbo.Consumer");
            DropForeignKey("dbo.AccountType", "ConsumerID", "dbo.Consumer");
            DropForeignKey("dbo.PromotionConsumer", "ConsumerID", "dbo.Consumer");
            DropForeignKey("dbo.PromotionConsumer", "PromotionID", "dbo.Promotion");
            DropForeignKey("dbo.Promotion", "AccountType_ConsumerID", "dbo.AccountType");
            DropIndex("dbo.PromotionConsumer", new[] { "ConsumerID" });
            DropIndex("dbo.PromotionConsumer", new[] { "PromotionID" });
            DropIndex("dbo.Department", new[] { "ConsumerID" });
            DropIndex("dbo.Promotion", new[] { "AccountType_ConsumerID" });
            DropIndex("dbo.Promotion", new[] { "DepartmentID" });
            DropIndex("dbo.AccountType", new[] { "ConsumerID" });
            AlterColumn("dbo.Promotion", "Title", c => c.String());
            AlterColumn("dbo.Employee", "First Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employee", "LastName", c => c.String(maxLength: 50));
            DropColumn("dbo.Promotion", "AccountType_ConsumerID");
            DropColumn("dbo.Promotion", "DepartmentID");
            DropTable("dbo.PromotionConsumer");
            DropTable("dbo.Department");
            DropTable("dbo.Consumer");
            DropTable("dbo.AccountType");
            RenameColumn(table: "dbo.Employee", name: "First Name", newName: "FirstMidName");
        }
    }
}
