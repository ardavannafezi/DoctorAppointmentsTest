using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmet.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string DoctorNationalId { get; set; }
        public string PatientNationalId { get; set; }
        public DateTime Date { get; set; }

        public Doctor Doctor { get; set; }
        public Patinet Patinet { get; set; }
    }
}
