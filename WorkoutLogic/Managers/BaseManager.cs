using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutContext;
using WorkoutData.Contracts;

namespace WorkoutLogic.Managers
{
    public class BaseManager : IBaseManager
    {
        public ICyberWorkoutWebSession WebSession { get; set; }
        protected CyberWorkoutContext Context { get; private set; }

        public BaseManager(string connectionstring = "DefaultConnection")
        {
            Context = new CyberWorkoutContext(connectionstring);
        }

        public BaseManager(ICyberWorkoutWebSession websession, string connectionstring = "DefaultConnection")
            : this(connectionstring)
        {
            WebSession = websession;
        }
    }
}
