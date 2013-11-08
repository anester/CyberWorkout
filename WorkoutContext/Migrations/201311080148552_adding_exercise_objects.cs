namespace WorkoutContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_exercise_objects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        Password = c.String(),
                        Roles = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        LoginId = c.Int(nullable: false),
                        Handle = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .Index(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "LoginId", "dbo.Logins");
            DropIndex("dbo.People", new[] { "LoginId" });
            DropTable("dbo.People");
            DropTable("dbo.Logins");
        }
    }
}
