using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManyToManyMapping
{
    public class Doctors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Patients> Patients { get; set; }

        public Doctors()
        {
            Patients = new List<Patients>();
        }
    }

    public class Patients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Doctors> Doctors { get; set; }

        public Patients()
        {
            Doctors = new List<Doctors>();
        }
    }

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyEFC_DB7;Integrated Security=True");
                optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Doctors>()
            //    .HasMany(p => p.Patients)
            //    .WithMany(p => p.Doctors)
            //    .UsingEntity<DoctorsPatients>(
            //        j => j.HasOne(pt => pt.Patient).WithMany().HasForeignKey(a => a.PatientsId),            
            //        j => j.HasOne(pt => pt.Doctor).WithMany().HasForeignKey(a => a.DoctorsId));
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    //public class DoctorsPatients
    //{
    //    public int DoctorsId { get; set; }
    //    public Doctors Doctor { get; set; }
    //    public int PatientsId { get; set; }
    //    public Patients Patient { get; set; }
    //}
}
