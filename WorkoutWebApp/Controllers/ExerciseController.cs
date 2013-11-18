using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WorkoutData;
using WorkoutLogic.Managers;
using WorkoutWeb;
using WorkoutWebApp.Models;

namespace WorkoutWebApp.Controllers
{
    [CustomAuthorization(Role = "Admin")]
    public class ExerciseController : SecureController<ExerciseManager>
    {
        //
        // GET: /Exercise/

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetExercisesGridPart()
        {
            var exercises = Manager.GetExercises(0, 10);
            ListWrapper<Exercise> wrapper = new ListWrapper<Exercise>(exercises);

            return PartialView("GetExercisesGridPart", wrapper);
        }

        [HttpPost]
        public PartialViewResult GetExercisesGridPart(string fltrname, string fltrmusclegroup, string fltrdifficulty, string fltrresistancetype)
        {
            var exercises = Manager.GetExercises(0, 10);
            return PartialView("GetExercisesGridPart", new { Exercises = exercises });
        }

        public PartialViewResult CreateExerciseFormPart()
        {

            //SelectList lst = new SelectList()
            setupDropDowns();

            Exercise exercise = new Exercise
            {
                Name = "Exercise Name",
                Description = "Exercise Description",
                Resistance = ResistanceType.Body,
                Difficulty = 1
            };
            return PartialView("CreateExerciseFormPart", exercise);
        }

        private void setupDropDowns()
        {
            ViewBag.MuscleGroupDD = Enum.GetValues(typeof(MuscleGroupType))
                                        .Cast<MuscleGroupType>()
                                        .Select(e => new SelectListItem()
                                        {
                                            Text = makeEnumStringFriendly(e.ToString()),
                                            Value = ((int)e).ToString()
                                        });

            ViewBag.ResistanceDD = Enum.GetValues(typeof(ResistanceType))
                                        .Cast<ResistanceType>()
                                        .Select(e => new SelectListItem()
                                        {
                                            Text = makeEnumStringFriendly(e.ToString()),
                                            Value = ((int)e).ToString()
                                        });

            ViewBag.DifficultyDD = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Select(i => new SelectListItem { Text = i.ToString(), Value = i.ToString() });
        }

        private string makeEnumStringFriendly(string str)
        {
            int cpos = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    sb.Append(str.Substring(cpos, i)).Append(" ");
                    cpos = i;
                }
            }

            sb.Append(str.Substring(cpos));

            return sb.ToString().TrimEnd();
        }
    }
}
