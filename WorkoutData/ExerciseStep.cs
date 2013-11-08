using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutData
{
    public class ExerciseStep
    {
        public int ExerciseStepId { get; set; }
        public int ExerciseId { get; set; }
        public int? ExercisePicId { get; set; }
        public int OrderNum { get; set; }
        public string Description { get; set; }

        public virtual Exercise CurrentExercise { get; set; }
        public virtual ExercisePic StepPicture { get; set; }
    }
}
