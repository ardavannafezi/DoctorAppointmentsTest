using System;
using System.Runtime.Serialization;

namespace DoctorsAppointment.Services.Patients
{
    [Serializable]
    public class PatientAlreadyExist : Exception
    {
        public PatientAlreadyExist()
        {
        }

        public PatientAlreadyExist(string message) : base(message)
        {
        }

        public PatientAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PatientAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}