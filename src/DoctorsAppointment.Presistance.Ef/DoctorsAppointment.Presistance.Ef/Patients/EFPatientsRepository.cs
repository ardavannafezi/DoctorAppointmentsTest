using BookStore.Persistence.EF;
using DoctorsAppointment.Services.Doctors.Contracts;
using DoctorsAppointment.Services.Patients.Contract;
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

        public Patient FindByNationalId(string nationalId)
        {
            return _dataContext.Patinets.FirstOrDefault(x => x.NationalId == nationalId);
        }

        public IList<GetPatientDto> GetAll()
        {
            return _dataContext.Patinets
                .Select(x => new GetPatientDto
                {
                    Name = x.Name,
                    LastName = x.LastName,
                    NationalId = x.NationalId
                }).ToList();
        }

        public bool isExist(string nationalId)
        {
            if(_dataContext.Patinets.Any(_ => _.NationalId == nationalId) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(Patient patient)
        {
            _dataContext.Update(patient);
        }
    }
}
