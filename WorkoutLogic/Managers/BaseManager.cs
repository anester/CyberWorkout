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
        protected StringBuilder SqlLog { get; set; }
        protected string Log { get { return SqlLog.ToString(); } }

        public BaseManager(string connectionstring = "DefaultConnection")
        {
            SqlLog = new StringBuilder();
            Context = new CyberWorkoutContext(connectionstring);
            Context.Database.Log = delegate(string s)
            {
                SqlLog.AppendLine(s);
            };
        }

        public BaseManager(ICyberWorkoutWebSession websession, string connectionstring = "DefaultConnection")
            : this(connectionstring)
        {
            WebSession = websession;
        }
    }
}
