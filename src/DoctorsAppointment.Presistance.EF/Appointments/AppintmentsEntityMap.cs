using DoctorsAppointmet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAppointment.Persistence.EF.Appointments
{
    public class AppointmentsEntityMaps : IEntityTypeConfiguration<Appointment>
    {
            public void Configure(EntityTypeBuilder<Appointment> _)
            {
                _.ToTable("Appointments");

                _.HasKey(p => p.Id);

                _.Property(_ => _.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

                _.Property(_ => _.Date);

                _.Property(_ => _.DoctorNationalId);

                _.Property(p => p.PatientNationalId);
            }
        }
}