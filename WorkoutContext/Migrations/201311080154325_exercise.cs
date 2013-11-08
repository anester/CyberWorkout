namespace WorkoutContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exercise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExercisePics",
                c => new
                    {
                        ExercisePicId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        LocationType = c.Int(nullable: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.ExercisePicId);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ExerciseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MuscleGroup = c.Int(nullable: false),
                        Resistance = c.Int(nullable: false),
                        Difficulty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseId);
            
            CreateTable(
                "dbo.ExerciseSteps",
                c => new
                    {
                        ExerciseStepId = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        ExercisePicId = c.Int(),
                        OrderNum = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExerciseStepId)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.ExercisePics", t => t.ExercisePicId)
                .Index(t => t.ExerciseId)
                .Index(t => t.ExercisePicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExerciseSteps", "ExercisePicId", "dbo.ExercisePics");
            DropForeignKey("dbo.ExerciseSteps", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.ExerciseSteps", new[] { "ExercisePicId" });
            DropIndex("dbo.ExerciseSteps", new[] { "ExerciseId" });
            DropTable("dbo.ExerciseSteps");
            DropTable("dbo.Exercises");
            DropTable("dbo.ExercisePics");
        }
    }
}
