using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace RepositoryLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder = optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Patient> Patients
        {
            get;
            set;
        }
        public DbSet<Clinic> Clinics
        {
            get;
            set;
        }
        public DbSet<Visit> Visits
        {
            get;
            set;
        }
        public DbSet<Result> Results
        {
            get;
            set;
        }
    }
}