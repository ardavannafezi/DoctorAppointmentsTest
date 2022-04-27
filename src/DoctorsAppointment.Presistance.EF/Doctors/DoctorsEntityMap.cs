using DoctorsAppointmet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAppointment.Persistence.EF.Doctors
{
    public class DoctorEntityMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> _)
        {
            _.ToTable("Doctors");

            _.HasKey(p => p.NationalId);

            _.Property(_ => _.NationalId);

            _.Property(_ => _.Name)
              .IsRequired();

            _.Property(p => p.Field)
             .IsRequired();

            _.Property(_ => _.LastName)
                  .IsRequired();
            

            _.HasMany(_ => _.Appointments)
              .WithOne(p => p.Doctor)
              .HasForeignKey(p => p.DoctorNationalId);

        }
    }
}