using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointment.Services.Appointments.Contract
{
    public interface AppointmentService
    {
        void Add(AddAppointmentDto dto);
        IList<GetAppointmentDto> GetAll();
        void Update(UpdateAppointmentDto dto, int id);
    }
}
