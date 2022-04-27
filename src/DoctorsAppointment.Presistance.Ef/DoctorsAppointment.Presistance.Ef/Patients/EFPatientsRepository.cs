using BookStore.Persistence.EF;
using DoctorsAppointment.Services.Doctors.Contracts;
using DoctorsAppointmet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Presistance.Ef.Patients
{
    public class EFPatientsRepository : PatientRepository
    {
        private readonly EFDataContext _dataContext;

        public EFPatientsRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Patient patient)
        {
            _dataContext.Patinets.Add(patient);
        }

    }
}
