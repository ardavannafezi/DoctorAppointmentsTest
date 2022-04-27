using System;
using System.Runtime.Serialization;

namespace DoctorsAppointment.Services.Doctors
{
    [Serializable]
    public class DoctorAlreadyExist : Exception
    {
        public DoctorAlreadyExist()
        {
        }

    }
}