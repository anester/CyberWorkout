using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutData;
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

        public IEnumerable<WorkoutData.Exercise> GetExercises(
            int pageno = 1,
            int pagesize = 25,
            string fltrname = "",
            string fltrdesc = "",
            int? fltrmusclegroup = null,
            int? fltrdifficulty = null,
            int? fltrresistancetype = null)
        {
            string[] arr = new string[] {
                "Name like @name",
	            "AND [Description] like @description",
	            "AND MuscleGroup = @musclegroup",
	            "AND Resistance = @resistance",
	            "AND Difficulty = @difficulty"
            };
            List<SqlParameter> parameters = new List<SqlParameter>();

            StringBuilder sb = new StringBuilder();
            
            if (!string.IsNullOrEmpty(fltrname))
            {
                sb.Append("Name like @name");
                parameters.Add(new SqlParameter("@name", fltrname));
            }
            if (!string.IsNullOrEmpty(fltrdesc))
            {
                sb.Append("AND [Description] like @description");
                parameters.Add(new SqlParameter("@description", fltrname));
            }
            if (fltrmusclegroup.HasValue)
            {
                sb.Append("AND MuscleGroup = @musclegroup");
                parameters.Add(new SqlParameter("@musclegroup", fltrname));
            }
            if (fltrdifficulty.HasValue)
            {
                sb.Append("AND Resistance = @resistance");
                parameters.Add(new SqlParameter("@resistance", fltrname));
            }
            if (fltrresistancetype.HasValue)
            {
                sb.Append("AND Difficulty = @difficulty");
                parameters.Add(new SqlParameter("@difficulty", fltrname));
            }

            parameters.Add(new SqlParameter("@offset", pageno * pagesize));
            parameters.Add(new SqlParameter("@pagesize", pagesize));


            string sql = string.Format(@"
SELECT [ExerciseId]
      ,[Name]
      ,[Description]
      ,[MuscleGroup]
      ,[Resistance]
      ,[Difficulty]
  FROM [CyberWorkout].[dbo].[Exercises]
  WHERE 1=1 {0}
  ORDER BY Name
  OFFSET @offset ROWS
  FETCH NEXT @pagesize ROWS ONLY
", sb.ToString());
            
            var res = Context.Database.SqlQuery<Exercise>(sql, parameters.ToArray()).ToArray();
            return res;
        }
    }
}
