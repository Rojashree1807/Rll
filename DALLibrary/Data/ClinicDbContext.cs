using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLibrary.Data
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext() : base("name = ClinicDB")
        {

        }
        public DbSet<Manager> Managers => Set<Manager>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Front_Officer> Front_Officers => Set<Front_Officer>();
        public DbSet<Medicine> Medicines => Set<Medicine>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Pharmacist> Pharmacists => Set<Pharmacist>();
    }
}
