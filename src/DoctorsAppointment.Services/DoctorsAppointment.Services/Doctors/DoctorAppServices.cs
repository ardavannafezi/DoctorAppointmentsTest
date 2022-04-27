using DoctorsAppointment.Infrastructure.Application;
using DoctorsAppointment.Services.Doctors.Contracts;
using DoctorsAppointmet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Doctors
{
    public class DoctorAppServices : DoctorService
    {

        private readonly DoctorRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public DoctorAppServices(
            DoctorRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddDoctorDto dto)
        {
            var doctor = new Doctor
            {
                LastName = dto.LastName,
                Name = dto.Name,
                NationalId = dto.NationalId,
                Field = dto.Field,
            };

            bool isDoctorExist = _repository.isDcotorExist(dto.NationalId);
            if (isDoctorExist == true)
            {
                throw new DoctorAlreadyExist();
            }
            
            _repository.Add(doctor);
            _unitOfWork.Commit();
        }

        public IList<GetDoctorDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(UpdateDoctorDto dto, string nationalId)
        {
           var doctor =  _repository.FindByNationalId(nationalId);

           bool isExist = _repository.isDcotorExist(dto.NationalId);

            if(isExist == true && dto.NationalId != nationalId)
            {
                throw new NationalIdExistForAnotherDoctor();
            }

            doctor.NationalId = dto.NationalId;
            doctor.Name = dto.Name;
            doctor.LastName = dto.LastName;
            doctor.Field = dto.Field;

            _unitOfWork.Commit();
            _repository.Update(doctor);
        }
    }
   
}
