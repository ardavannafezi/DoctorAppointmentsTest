using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Patients.Contract
{
    public class GetPatientDto
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string LastName{ get; set; }

    }
}
