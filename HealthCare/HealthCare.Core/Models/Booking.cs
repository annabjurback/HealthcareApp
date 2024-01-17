using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Core.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Note { get; set; }

        //[ForeignKey(nameof(Service))]
        //public int ServiceId { get; set; }
        //public Service Service { get; set; }
        public bool Completed { get; set; }

		public string? PatientId { get; set; }
        public Patient Patient { get; set; }

		[ForeignKey(nameof(Caregiver))]
		public string CaregiverId { get; set; }
        public Caregiver Caregiver { get; set; }
    }

}

