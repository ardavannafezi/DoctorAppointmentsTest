using DoctorsAppointment.Infrastructure.Application;
using DoctorsAppointment.Services.Patients.Contract;
using DoctorsAppointmet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Doctors.Contracts
{
    public interface PatientRepository : Service
    {
        void Add(Patient patient);
        IList<GetPatientDto> GetAll();
        void Update(Patient patient);
        Patient FindByNationalId(string nationalId);
    }
}
