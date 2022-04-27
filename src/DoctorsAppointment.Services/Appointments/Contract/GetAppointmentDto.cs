using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Appointments.Contract
{
    public class GetAppointmentDto
    {
        public int Id { get; set; }
        public string DoctorNationalId { get; set; }
        public string PatientNationalId { get; set; }
        public DateTime Date { get; set; }
    }
}
