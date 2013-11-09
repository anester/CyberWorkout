using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkoutData;
using WorkoutLogic.Managers;
using WorkoutWeb;

namespace WorkoutWebApp.Controllers.api
{
    public class ExerciseJsonController : SecureApiController<ExerciseManager>
    {
        // GET api/exercisejson
        public IEnumerable<Exercise> Get()
        {
            return null;
        }

        // GET api/exercisejson/5
        public Exercise Get(int id)
        {
            return null;
        }

        // POST api/exercisejson
        public void Post([FromBody]Exercise value)
        {
            int id = Manager.CreateExercise(value);
        }

        // PUT api/exercisejson/5
        public void Put(int id, [FromBody]Exercise value)
        {
        }

        // DELETE api/exercisejson/5
        public void Delete(int id)
        {
        }
    }
}
