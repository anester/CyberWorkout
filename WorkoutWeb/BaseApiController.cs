using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WorkoutData.Contracts;

namespace WorkoutWeb
{
    public class BaseApiController : ApiController
    {
    }

    [SessionRequired]
    public class SecureApiController<T> : BaseApiController
        where T : IBaseManager
    {
        public T Manager { get; set; }
        public ICyberWorkoutWebSession WorkoutWebSession { get; set; }

        public SecureApiController()
        {
            WorkoutWebSession = new CyberWorkoutSession();
            Manager = (T)Activator.CreateInstance(typeof(T), WorkoutWebSession);
        }
    }
}
