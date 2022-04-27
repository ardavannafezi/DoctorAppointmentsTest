using DoctorsAppointment.Services.Patients.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Patients.Contracts
{
    public interface PatientService
    {
        void Add(AddPatientDto dto);
        IList<GetPatientDto> GetAll();
        void Update(UpdatePatientDto dto, string nationalId);
    }
}
