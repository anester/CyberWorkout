using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutData.Contracts
{
    public interface IBaseManager
    {
        ICyberWorkoutWebSession WebSession { get; set; }
    }
}
