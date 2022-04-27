﻿
using DoctorsAppointment.Persistence.EF.Doctors;
using DoctorsAppointmet.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.EF
{
    public class EFDataContext : DbContext
    {

        public EFDataContext(string connectionString) :
            this(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
        { }
       
        public EFDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(DoctorEntityMap).Assembly);
        }
       
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patinets { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

    }
}
