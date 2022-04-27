using BookStore.Persistence.EF;
using DoctorsAppointment.Services.Appointments.Contract;
using DoctorsAppointmet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Presistance.EF.Appointments
{
    public class EFAppointmentRepisitory : AppointmentRepository
    {
        private readonly EFDataContext _dataContext;

        public EFAppointmentRepisitory(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public void Add(Appointment appointment)
        {
            _dataContext.Appointments.Add(appointment);
        }


        public int AppointmentsPerDay(string doctorNationalId , DateTime date)
        {

            var doctorsappointments = _dataContext.Set<Appointment>()
              .Where(_ => _.DoctorNationalId == doctorNationalId && _.Date == date)
              .Select(_ => new Appointment
              {
                  DoctorNationalId = _.Doctor.NationalId,

              });

            var ApInDay = from a in _dataContext.Doctors
                          join p in doctorsappointments on a.NationalId equals p.DoctorNationalId
                          select new
                          {
                              date = p.Date,
                              Id = a.NationalId,
                          };

            return ApInDay.Count();
        }


        public IList<GetAppointmentDto> GetAll()
        {
            return _dataContext.Appointments
                .Select(x => new GetAppointmentDto
                {
                    DoctorNationalId = x.DoctorNationalId,
                    PatientNationalId = x.PatientNationalId,
                    Date = x.Date,

                }).ToList();
        }

        public Appointment GetById(int id)
        {
            return _dataContext.Appointments.FirstOrDefault(_ => _.Id == id);
        }

        public bool isExist(string doctorNationalId, string patientNationalId)
        {
            if(_dataContext.Appointments.Any(_ => _.DoctorNationalId == doctorNationalId 
                && _.PatientNationalId== patientNationalId))
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        public void Update(Appointment appointment)
        {
            _dataContext.Appointments.Update(appointment);
        }
    }
}
