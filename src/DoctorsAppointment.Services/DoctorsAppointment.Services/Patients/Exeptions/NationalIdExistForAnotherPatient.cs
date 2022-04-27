using System;
using System.Runtime.Serialization;

namespace DoctorsAppointment.Services.Patients
{
    [Serializable]
    public class NationalIdExistForAnotherPatient : Exception
    {
        public NationalIdExistForAnotherPatient()
        {
        }

        public NationalIdExistForAnotherPatient(string message) : base(message)
        {
        }

        public NationalIdExistForAnotherPatient(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NationalIdExistForAnotherPatient(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}