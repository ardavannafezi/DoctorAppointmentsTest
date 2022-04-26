using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmet.Entities
{
    public class Doctor : Person
    {
        public string Field { get; set; }

        public List<Appointment> Appointments{ get; set; } = new List<Appointment>();

    }
}
