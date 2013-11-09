namespace WorkoutContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_exercise_objects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExercisePics",
                c => new
                    {
                        ExercisePicId = c.Int(nullable: false, identity: true),
                        ExerciseStepId = c.Int(nullable: false),
                        Description = c.String(),
                        LocationType = c.Int(nullable: false),
                        Path = c.String(),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        FileType = c.String(),
                    })
                .PrimaryKey(t => t.ExercisePicId)
                .ForeignKey("dbo.ExerciseSteps", t => t.ExerciseStepId, cascadeDelete: true)
                .Index(t => t.ExerciseStepId);
            
            CreateTable(
                "dbo.ExerciseSteps",
                c => new
                    {
                        ExerciseStepId = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        OrderNum = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExerciseStepId)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .Index(t => t.ExerciseId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExercisePics", "ExerciseStepId", "dbo.ExerciseSteps");
            DropForeignKey("dbo.ExerciseSteps", "ExerciseId", "dbo.Exercises");
            DropIndex("dbo.ExercisePics", new[] { "ExerciseStepId" });
            DropIndex("dbo.ExerciseSteps", new[] { "ExerciseId" });
            DropTable("dbo.Exercises");
            DropTable("dbo.ExerciseSteps");
            DropTable("dbo.ExercisePics");
        }
    }
}
