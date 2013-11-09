using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutData
{
    public enum PicLocationType
    {
        HardDrive,
        Db,
        Web
    }

    public class ExercisePic
    {
        public int ExercisePicId { get; set; }
        public int ExerciseStepId { get; set; }
        public string Description { get; set; }
        public PicLocationType LocationType { get; set; }
        public string Path { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string FileType { get; set; }

        public virtual ExerciseStep Step { get; set; }
    }
}
