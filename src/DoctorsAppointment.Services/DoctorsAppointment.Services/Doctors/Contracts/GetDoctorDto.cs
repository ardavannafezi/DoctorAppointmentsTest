using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Doctors.Contracts
{
    public class GetDoctorDto
    {

        public string NationalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Field { get; set; }


    }
}
