using DoctorsAppointment.Infrastructure.Application;
using DoctorsAppointment.Services.Doctors.Contracts;
using DoctorsAppointment.Services.Patients.Contract;
using DoctorsAppointment.Services.Patients.Contracts;
using DoctorsAppointmet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Patients
{
    public class PatientAppServices : PatientService
    {

        private readonly PatientRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public PatientAppServices(
            PatientRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

 
        public void Add(AddPatientDto dto)
        {
            var patient = new Patient
            {
                LastName = dto.LastName,
                Name = dto.Name,
                NationalId = dto.NationalId,
            };
            _repository.Add(patient);
            _unitOfWork.Commit();
        }
    }
}
