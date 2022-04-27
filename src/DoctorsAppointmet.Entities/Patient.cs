using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmet.Entities
{
    public class Patient : Person
    {
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
