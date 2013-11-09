using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutData
{
    public enum MuscleGroupType
    {
        Back,
        Calves,
        Delts,
        Forearms,
        Glutes,
        Hams,
        Lats,
        LowerAbs,
        LowerBack,
        Neck,
        Oblique,
        Pecs,
        Quads,
        Traps,
        Triceps,
        UpperAbs
    }

    [Flags]
    public enum ResistanceType
    {
        Body = 1,
        FreeWeight = 2,
        Machine = 4,
        DumbBells = 8,
        Bands = 16
    }

    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MuscleGroupType MuscleGroup { get; set; }
        public ResistanceType Resistance { get; set; }
        public int Difficulty { get; set; }

        public virtual IEnumerable<ExerciseStep> Steps { get; set; }
    }
}
