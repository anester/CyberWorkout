using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutData.Contracts
{
    public interface ICyberWorkoutWebSession
    {
        Login UserLogin { get; set; }
        string CurrentLoginName { get; set; }
        string CurrentLoginEmail { get; set; }
        WorkoutData.Login CurrentLogin { get; set; }
        WorkoutData.Person LoggedInUser { get; set; }
        DateTime LoggedInTime { get; set; }
    }
}
