using DoctorsAppointmet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAppointment.Persistence.EF.Patients
{
    public class PatientsEntityMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> _)
        {
            _.ToTable("Patients");

            _.HasKey(p => p.NationalId);

            _.Property(_ => _.NationalId);

            _.Property(_ => _.Name)
              .IsRequired();

            _.Property(_ => _.LastName)
              .IsRequired();


            _.HasMany(_ => _.Appointments)
              .WithOne(p => p.Patinet)
              .HasForeignKey(p => p.PatientNationalId);


        }
    }
}