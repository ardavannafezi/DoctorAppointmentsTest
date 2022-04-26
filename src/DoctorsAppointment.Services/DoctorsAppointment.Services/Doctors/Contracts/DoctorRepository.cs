using DoctorsAppointment.Infrastructure.Application;
using DoctorsAppointmet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Doctors.Contracts
{
    public interface DoctorRepository : Service
    {
        void Add(Doctor doctor);
        IList<GetDoctorDto> GetAll();
        void Update(Doctor doctor);
        Doctor FindByNationalId(string nationalId);
    }
}
