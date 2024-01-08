using System;
namespace HealthCare.Core.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Note { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public bool Completed { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public string CaregiverId { get; set; }
        public Caregiver Caregiver { get; set; }
    }

}

