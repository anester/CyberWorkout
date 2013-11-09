using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutData.Contracts;

namespace WorkoutLogic.Managers
{
    public class ExerciseManager : BaseManager
    {
        public ExerciseManager(ICyberWorkoutWebSession websession)
            : base(websession, "DefaultConnection")
        {
        }

        public int CreateExercise(WorkoutData.Exercise value)
        {
            value.ExerciseId = 0;

            Context.Exercises.Add(value);
            Context.SaveChanges();

            return value.ExerciseId;
        }

        public IEnumerable<WorkoutData.Exercise> GetExercises()
        {
            throw new NotImplementedException();
        }
    }
}
