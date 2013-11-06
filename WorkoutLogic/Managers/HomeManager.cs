using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutData.Contracts;

namespace WorkoutLogic.Managers
{
    /// <summary>
    /// This manager will handle all the summary information that
    /// goes on the home screen.
    /// </summary>
    public class HomeManager : BaseManager
    {
        public HomeManager(ICyberWorkoutWebSession websession)
            : base(websession)
        {
        }
    }
}
