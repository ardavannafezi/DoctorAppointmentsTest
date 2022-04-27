using System;
using System.Runtime.Serialization;

namespace DoctorsAppointment.Services.Doctors
{
    [Serializable]
    public class NationalIdExistForAnotherDoctor : Exception
    {
        public NationalIdExistForAnotherDoctor()
        {
        }

        public NationalIdExistForAnotherDoctor(string message) : base(message)
        {
        }

        public NationalIdExistForAnotherDoctor(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NationalIdExistForAnotherDoctor(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}