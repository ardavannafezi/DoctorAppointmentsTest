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

            bool isExist =  _repository.isExist(dto.NationalId);
            if (isExist ==true)
            {
                throw new PatientAlreadyExist();
            }
            
            _repository.Add(patient);
            _unitOfWork.Commit();
        }

        public IList<GetPatientDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(UpdatePatientDto dto, string nationalId)
        {
            var patient = _repository.FindByNationalId(nationalId);

            bool isExist = _repository.isExist(dto.NationalId);

            if (isExist == true && dto.NationalId != nationalId)
            {
                throw new NationalIdExistForAnotherPatient();
            }


            patient.LastName = dto.LastName;
            patient.Name = dto.Name;
            patient.NationalId = dto.NationalId;

            _repository.Update(patient);
            _unitOfWork.Commit();
        }

    }
}
