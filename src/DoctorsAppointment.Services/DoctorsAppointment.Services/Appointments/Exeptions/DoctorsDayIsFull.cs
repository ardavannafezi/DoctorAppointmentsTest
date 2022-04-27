using System;
using System.Runtime.Serialization;

namespace DoctorsAppointment.Services.Appointments
{
    [Serializable]
    public class DoctorsDayIsFull : Exception
    {
        public DoctorsDayIsFull()
        {
        }

        public DoctorsDayIsFull(string message) : base(message)
        {
        }

        public DoctorsDayIsFull(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DoctorsDayIsFull(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}