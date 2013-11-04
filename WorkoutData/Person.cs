using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutData
{
    public class Person
    {
        public int PersonId { get; set; }
        public int LoginId { get; set; }

        public string Handle { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? BirthDate { get; set; }

        public Login PersonLogin { get; set; }
    }
}
