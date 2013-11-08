using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutContext;
using WorkoutData.Contracts;

namespace WorkoutLogic.Managers
{
    public class AccountCheckManager
    {
        protected CyberWorkoutContext Context { get; private set; }

        public AccountCheckManager(string connectionstring = "DefaultConnection")
        {
            Context = new CyberWorkoutContext(connectionstring);
        }

        public bool EmailExists(string email)
        {
            return Context.Logins.Count(l => l.EmailAddress == email) > 0;
        }

        public bool HandleExists(string handle)
        {
            return Context.People.Count(h => h.Handle == handle) > 0;
        }
    }
}
