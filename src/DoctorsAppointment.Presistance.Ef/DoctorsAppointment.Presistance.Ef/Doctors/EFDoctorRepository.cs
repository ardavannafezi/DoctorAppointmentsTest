using BookStore.Persistence.EF;
using DoctorsAppointment.Services.Doctors.Contracts;
using DoctorsAppointmet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Presistance.Ef.Doctors
{
    public class EFDoctorRepository : DoctorRepository
    {
        private readonly EFDataContext _dataContext;

        public EFDoctorRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Doctor doctor)
        {

            _dataContext.Doctors.Add(doctor);
        }

        public IList<GetDoctorDto> GetAll()
        {
            return _dataContext.Doctors.Select(
                _ => new GetDoctorDto
                {
                    Name = _.Name,
                    LastName = _.LastName,
                    NationalId = _.NationalId,
                    Field = _.Field,
                }).ToList();
        }

        public void Update(Doctor doctor)
        {
            _dataContext.Update(doctor);
        }

    
        public Doctor FindByNationalId(string nationalId)
        {
            return _dataContext.Doctors.Find(nationalId);
        }
    }
}
