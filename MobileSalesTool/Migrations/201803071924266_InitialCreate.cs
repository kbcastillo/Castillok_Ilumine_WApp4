namespace MobileSalesTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        PromotionID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                        Employees_ID = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Employee", t => t.Employees_ID)
                .ForeignKey("dbo.Promotion", t => t.PromotionID, cascadeDelete: true)
                .Index(t => t.PromotionID)
                .Index(t => t.Employees_ID);
            
            CreateTable(
                "dbo.Promotion",
                c => new
                    {
                        PromotionID = c.Int(nullable: false),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "PromotionID", "dbo.Promotion");
            DropForeignKey("dbo.Enrollment", "Employees_ID", "dbo.Employee");
            DropIndex("dbo.Enrollment", new[] { "Employees_ID" });
            DropIndex("dbo.Enrollment", new[] { "PromotionID" });
            DropTable("dbo.Promotion");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Employee");
        }
    }
}
