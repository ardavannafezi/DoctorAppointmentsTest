﻿
namespace DoctorsAppointment.Services.Doctors.Contracts
{
    public class UpdateDoctorDto
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Field { get; set; }
    }
}
