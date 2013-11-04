using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutData;

namespace WorkoutContext
{
    public class CyberWorkoutContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Person> Persons { get; set; }

        public CyberWorkoutContext()
            : this("DefaultConnection")
        {

        }

        public CyberWorkoutContext(string connectionstring)
            : base(connectionstring)
        {

        }
    }
}
