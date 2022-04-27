using BookStore.Persistence.EF;
using DoctorsAppointment.Infrastructure.Application;
using DoctorsAppointment.Infrastructure.Test;
using DoctorsAppointment.Presistance.Ef.Doctors;
using DoctorsAppointment.Presistance.EF.Appointments;
using DoctorsAppointment.Services.Appointments;
using DoctorsAppointment.Services.Appointments.Contract;
using DoctorsAppointment.Services.Doctors;
using DoctorsAppointment.Services.Doctors.Contracts;
using DoctorsAppointmet.Entities;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Test.Unit
{
    public class AppointmentServiceTests
    {

        private readonly AppointmentRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly AppointmentService _sut;
        private readonly EFDataContext _dataContext;


        public AppointmentServiceTests()
        {
            _dataContext =
                new EFInMemoryDatabase()
                .CreateDataContext<EFDataContext>();
            _unitOfWork = new EFUnitOfWork(_dataContext);
            _repository = new EFAppointmentRepisitory(_dataContext);
            _sut = new AppointmentAppServices(_repository, _unitOfWork);
        }


        [Fact]
        public void Add_add_appointment_porperly()
        {
            CreadeDoctorAndPatiendInDatabase();
            var dto = GenerateAppointmentDto();
            _sut.Add(dto);
            _dataContext.Appointments.Should().Contain(_ => _.DoctorNationalId == dto.DoctorNationalId );

        }
        private AddAppointmentDto GenerateAppointmentDto()
        {
            return new AddAppointmentDto
            {
                DoctorNationalId = "123",
                PatientNationalId = "123",
                Date = DateTime.Now.Date,
            };
        }

        private void CreadeDoctorAndPatiendInDatabase()
        {

          var doctor = new Doctor
            {
                LastName = "dummy",
                Field = "dummy",
                Name = "dummy",
                NationalId = "123",
            };
            _dataContext.Manipulate(_ =>
                _.Doctors.Add(doctor));


            var patient = new Patient
            {
                LastName = "dummy",
                Name = "dummy",
                NationalId = "123",
            };
            _dataContext.Manipulate(_ =>
                _.Patinets.Add(patient));

        }

        [Fact]
        public void GetAll_appointment_show_all_appointments_in_database_with_doctornationalId_and_patientnationalId()
        {
            CreadeDoctorAndPatiendInDatabase();
            CreateAppointmentInDataBase();

            var expected = _sut.GetAll();
            expected.Should().HaveCount(1);
            expected.Should().Contain(_ => _.DoctorNationalId == "123");

        }

        private Appointment CreateAppointmentInDataBase()
        {
            var appointment = new Appointment
            {
               PatientNationalId = "123",
               DoctorNationalId = "123",
               Date = DateTime.Now.Date,
            };
            _dataContext.Manipulate(_ =>
                _.Appointments.Add(appointment));

            return appointment;
        }

        [Fact]
        public void Update__Update_All_Appointments_informations_with_given_informations()
        {
            CreateDoctorInDatabase();
            CreadeDoctorAndPatiendInDatabase()
            var appointment = CreateAppointmentInDataBase();
            
          
            int id = 1;
            var dto = new UpdateAppointmentDto
            {
                DoctorNationalId = "1234",
                PatientNationalId   = "123",
                Date = DateTime.Now.Date,
            };

            _sut.Update(dto, id);

            var expected = _dataContext.Appointments
                .FirstOrDefault(_ => _.Id == id);
            expected.DoctorNationalId.Should().Be(dto.DoctorNationalId);
        }

        public void CreateDoctorInDatabase()
        {
            var doctor = new Doctor
            {
                LastName = "dummy",
                Field = "dummy",
                Name = "dummy",
                NationalId = "1234",
            };
            _dataContext.Manipulate(_ =>
                _.Doctors.Add(doctor));
        }

    }
}
