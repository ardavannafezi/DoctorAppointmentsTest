using DoctorsAppointment.Infrastructure.Application;
using DoctorsAppointmet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Appointments.Contract
{
    public interface AppointmentRepository : Service
    {
        public void Add(Appointment appointment);
        public IList<GetAppointmentDto> GetAll();
        Appointment GetById(int id);
        void Update(Appointment appointment);
        bool isExist(string doctorNationalId, string patientNationalId);
    }
}
