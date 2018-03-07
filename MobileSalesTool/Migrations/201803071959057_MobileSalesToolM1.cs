namespace MobileSalesTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MobileSalesToolM1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollment", "Employees_ID", "dbo.Employee");
            DropIndex("dbo.Enrollment", new[] { "Employees_ID" });
            RenameColumn(table: "dbo.Enrollment", name: "Employees_ID", newName: "EmployeeID");
            AlterColumn("dbo.Enrollment", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollment", "EmployeeID");
            AddForeignKey("dbo.Enrollment", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: true);
            DropColumn("dbo.Enrollment", "StudentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrollment", "StudentID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Enrollment", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.Enrollment", new[] { "EmployeeID" });
            AlterColumn("dbo.Enrollment", "EmployeeID", c => c.Int());
            RenameColumn(table: "dbo.Enrollment", name: "EmployeeID", newName: "Employees_ID");
            CreateIndex("dbo.Enrollment", "Employees_ID");
            AddForeignKey("dbo.Enrollment", "Employees_ID", "dbo.Employee", "ID");
        }
    }
}
