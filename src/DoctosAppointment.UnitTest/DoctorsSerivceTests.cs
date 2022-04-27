using BookStore.Persistence.EF;
using DoctorsAppointment.Infrastructure.Application;
using DoctorsAppointment.Infrastructure.Test;
using DoctorsAppointment.Presistance.Ef.Doctors;
using DoctorsAppointment.Services.Doctors;
using DoctorsAppointment.Services.Doctors.Contracts;
using DoctorsAppointmet.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTest
{
    public class DoctorsSerivceTests
    {

        private readonly DoctorRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly DoctorService _sut;
        private readonly EFDataContext _dataContext;


        public DoctorsSerivceTests()
        {
            _dataContext =
                new EFInMemoryDatabase()
                .CreateDataContext<EFDataContext>();
            _unitOfWork = new EFUnitOfWork(_dataContext);
            _repository = new EFDoctorRepository(_dataContext);
            _sut = new DoctorAppServices(_repository, _unitOfWork);
        }


        [Fact]
        public void Add_add_doctors_porperly()
        {

            var doctor = GenerateDoctorDto();
            _sut.Add(doctor);
            _dataContext.Doctors.Should().Contain(_ => _.NationalId == doctor.NationalId);

        }

        private AddDoctorDto GenerateDoctorDto()
        {
            return new AddDoctorDto
            {
                Name = "dummy",
                LastName = "dummy",
                NationalId = "123",
                Field = "dummy",
            };

        }

        [Fact]
        public void If_duplicated_doctor_is_in_database_throw_DoctorAlreadyExist_exeption()
        {
            CreateDoctorInDataBase();
            var doctor = GenerateDoctorDto();

            Action expected = () => _sut.Add(doctor);
            expected.Should().ThrowExactly<DoctorAlreadyExist>();
        }

        [Fact]
        public void GetAll_Doctor_show_all_doctors_in_database()
        {
            CreateDoctorInDataBase();

            var expected = _sut.GetAll();
            expected.Should().HaveCount(1);
            expected.Should().Contain(_ => _.NationalId == "123");

        }

        private Doctor CreateDoctorInDataBase()
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

            return doctor;
        }

        [Fact]
        public void Update_Doctor_Update_All_Doctors_informations_with_given_informations()
        {
            var doctor = CreateDoctorInDataBase();

            string nationalId = "123";
            var dto = GenerateUpdateDoctorDto("123");

            _sut.Update(dto, nationalId);

            var expected = _dataContext.Doctors
                .FirstOrDefault(_ => _.NationalId == nationalId);
            expected.Name.Should().Be(dto.Name);
        }

        [Fact]
        public void Update_checks_if_another_doctor_exist_with_the_new_given_nationalId()
        {
            CreateDoctorListInDatabase();

            string nationalId = "123";
            var dto = GenerateUpdateDoctorDto("1234");
            

            Action expected = () => _sut.Update(dto, nationalId);
            expected.Should().ThrowExactly<NationalIdExistForAnotherDoctor>();
        }

        public UpdateDoctorDto GenerateUpdateDoctorDto(string id)
        {
            return new UpdateDoctorDto
            {
                NationalId = id,
                Field = "field",
                Name = "dummy2",
                LastName = "Dummy2",
            };
        }
        private void CreateDoctorListInDatabase()
        {
            var doctors = new List<Doctor>
            {
                new Doctor { NationalId= "123" , Name="dummy",LastName="dummy",Field="dummy"},
                new Doctor { NationalId= "1234" , Name="dummy",LastName="dummy",Field="dummy"},
                new Doctor { NationalId= "12356" , Name="dummy",LastName="dummy",Field="dummy"},

            };
            _dataContext.Manipulate(_ =>
            _.Doctors.AddRange(doctors));
        }
    }
}
