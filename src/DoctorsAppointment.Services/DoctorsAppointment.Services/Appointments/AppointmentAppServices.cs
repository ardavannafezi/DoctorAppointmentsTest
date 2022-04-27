using DoctorsAppointment.Infrastructure.Application;
using DoctorsAppointment.Services.Appointments.Contract;
using DoctorsAppointmet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Appointments
{
    public class AppointmentAppServices : AppointmentService
    {
        private readonly AppointmentRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public AppointmentAppServices(
            AppointmentRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddAppointmentDto dto)
        {
            var Appointment = new Appointment
            {
               DoctorNationalId = dto.DoctorNationalId,
               PatientNationalId = dto.PatientNationalId,
               Date = dto.Date,
            };
            _repository.Add(Appointment);
            _unitOfWork.Commit();
        }

        public IList<GetAppointmentDto> GetAll()
        {   

            return _repository.GetAll();
        }

        public void Update(UpdateAppointmentDto dto, int id)
        {
           Appointment appointment =  _repository.GetById(id);
            appointment.DoctorNationalId = dto.DoctorNationalId;
            appointment.PatientNationalId = dto.PatientNationalId;
            appointment.Date = dto.Date;

            _repository.Update(appointment);
            _unitOfWork.Commit();
        }
    }
}
