using HealthCare.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Context
{
    public class HealthcareContext : DbContext
    {
        public HealthcareContext(DbContextOptions<HealthcareContext> options) : base(options) 
        {

        }

        public DbSet<Patient> Patients {  get; set; }
        public DbSet<Caregiver> Caregivers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //public DbSet<Service> Services { get; set; }
	}
}
