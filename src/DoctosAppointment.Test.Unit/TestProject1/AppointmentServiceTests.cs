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
using System.Collections.Generic;
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
            var dto = GenerateAppointmentDto("123");
            _sut.Add(dto);
            _dataContext.Appointments.Should()
                .Contain(_ => _.DoctorNationalId == dto.DoctorNationalId 
                && _.PatientNationalId ==dto.PatientNationalId);

        }

        [Fact]
        public void If_duplicated_Appointment_is_in_database_throw_AppointmentAlreadyExist_exeption()
        {
            CreadeDoctorAndPatiendInDatabase();
            CreateAppointmentInDataBase();
            var dto = GenerateAppointmentDto("123");

            Action expected = () => _sut.Add(dto);
            expected.Should().ThrowExactly<AppointmentAlreadyExist>();
        }

        [Fact]
        public void Doctor_cant_have_more_than_five_patient_exeption_thrown()
        {
            CreateDoctorWithFivePatients();
            CreateFiveAppointments();
            var dto = GenerateAppointmentDto("146548");

            Action expected = () => _sut.Add(dto);
            expected.Should().ThrowExactly<DoctorsDayIsFull>();
        }


        private void CreateDoctorWithFivePatients()
        {
            var patients = new List<Patient>
            {
                new Patient { NationalId= "12" , Name="dummy",LastName="dummy"},
                new Patient { NationalId= "123" , Name="dummy",LastName="dummy"},
                new Patient { NationalId= "1234" , Name="dummy",LastName="dummy"},
                new Patient { NationalId= "12345" , Name="dummy",LastName="dummy"},
                new Patient { NationalId= "123456" , Name="dummy",LastName="dummy"},
                new Patient { NationalId= "1234567" , Name="dummy",LastName="dummy"},


            };
            _dataContext.Manipulate(_ =>
            _.Patinets.AddRange(patients));

            var doctor = new Doctor
            {
                LastName = "dummy",
                Field = "dummy",
                Name = "dummy",
                NationalId = "123",
            };
            _dataContext.Manipulate(_ =>
                _.Doctors.Add(doctor));
        }


        private void CreateFiveAppointments()
        {
            var appointment = new List<Appointment>
            {
                new Appointment { DoctorNationalId= "123" , PatientNationalId = "12" ,Date = DateTime.Now.Date},
                new Appointment { DoctorNationalId= "123" , PatientNationalId = "123" ,Date = DateTime.Now.Date},
                new Appointment { DoctorNationalId= "123" , PatientNationalId = "1234" ,Date = DateTime.Now.Date},
                new Appointment { DoctorNationalId= "123" , PatientNationalId = "12345" ,Date = DateTime.Now.Date},
                new Appointment { DoctorNationalId= "123" , PatientNationalId = "123456" ,Date = DateTime.Now.Date},
            };
            _dataContext.Manipulate(_ =>
            _.Appointments.AddRange(appointment));
        }


            private AddAppointmentDto GenerateAppointmentDto(string id)
        {
            return new AddAppointmentDto
            {
                DoctorNationalId = "123",
                PatientNationalId = id,
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
            CreadeDoctorAndPatiendInDatabase();
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
