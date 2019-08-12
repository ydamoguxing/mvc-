namespace StudentSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GradeName = c.String(),
                        CreateTiem = c.DateTime(nullable: false),
                        IsMoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentName = c.String(),
                        Age = c.Int(nullable: false),
                        GId = c.Guid(nullable: false),
                        CreateTiem = c.DateTime(nullable: false),
                        IsMoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GId)
                .Index(t => t.GId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "GId", "dbo.Grades");
            DropIndex("dbo.Students", new[] { "GId" });
            DropTable("dbo.Students");
            DropTable("dbo.Grades");
        }
    }
}
