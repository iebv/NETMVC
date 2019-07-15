namespace MVCScaffoldingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Company : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalEmployees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Employees", "Company_ID", c => c.Int());
            CreateIndex("dbo.Employees", "Company_ID");
            AddForeignKey("dbo.Employees", "Company_ID", "dbo.Companies", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Company_ID", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "Company_ID" });
            DropColumn("dbo.Employees", "Company_ID");
            DropTable("dbo.Companies");
        }
    }
}
