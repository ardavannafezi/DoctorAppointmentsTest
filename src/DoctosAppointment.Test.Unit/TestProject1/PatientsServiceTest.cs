using BookStore.Persistence.EF;
using DoctorsAppointment.Infrastructure.Application;
using DoctorsAppointment.Infrastructure.Test;
using DoctorsAppointment.Presistance.Ef.Patients;
using DoctorsAppointment.Services.Doctors.Contracts;
using DoctorsAppointment.Services.Patients;
using DoctorsAppointment.Services.Patients.Contract;
using DoctorsAppointment.Services.Patients.Contracts;
using DoctorsAppointmet.Entities;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Test.Unit
{
    public class PatientsServiceTest
    {

        private readonly PatientRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly PatientService _sut;
        private readonly EFDataContext _dataContext;


        public PatientsServiceTest()
        {
            _dataContext =
                new EFInMemoryDatabase()
                .CreateDataContext<EFDataContext>();
            _unitOfWork = new EFUnitOfWork(_dataContext);
            _repository = new EFPatientsRepository(_dataContext);
            _sut = new PatientAppServices(_repository, _unitOfWork);
        }


        [Fact]
        public void Add_add_patient_porperly_in_databe()
        {
            AddPatientDto dto = GeneratePatientDto();
            _sut.Add(dto);
            _dataContext.Patinets.Should().Contain(_ => _.Name == dto.Name);
        }

        public AddPatientDto GeneratePatientDto()
        {
            return new AddPatientDto
            {
                LastName = "dummy",
                Name = "dummy",
                NationalId = "123",
            };
        }

        [Fact]
        public void GetAll_Gets_All_Patients_in_the_databse()
        {
            CreatePatientInDataBase();

            var expected = _sut.GetAll();
            expected.Should().HaveCount(1);
            expected.Should().Contain(_ => _.NationalId == "123");

        }

        private Patient CreatePatientInDataBase()
        {
            var patient = new Patient
            {
                LastName = "dummy",
                Name = "dummy",
                NationalId = "123",
            };
            _dataContext.Manipulate(_ =>
                _.Patinets.Add(patient));

            return patient;
        }


        [Fact]
        public void Update_patient_Update_All_patient_informations_with_given_informations()
        {
            var patient = CreatePatientInDataBase();

            string nationalId = "123";
            var dto = new UpdatePatientDto
            {
                NationalId = "123",
                Name = "dummy2",
                LastName = "Dummy2",
            };

            _sut.Update(dto, nationalId);

            var expected = _dataContext.Patinets
                .FirstOrDefault(_ => _.NationalId == nationalId);
            expected.Name.Should().Be(dto.Name);
        }
    }
}
