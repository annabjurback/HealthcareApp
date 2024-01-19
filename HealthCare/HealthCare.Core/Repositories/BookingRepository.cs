using HealthCare.Core.Context;
using HealthCare.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		private readonly HealthcareContext _context;

        public BookingRepository(HealthcareContext context)
        {
            _context = context;
        }

		public void CreateBooking(Booking booking)
		{
			_context.Add(booking);
			_context.SaveChanges();
		}

		public List<Booking> GetAvailableAppointments(string? caregiverId)
		{
			if (string.IsNullOrWhiteSpace(caregiverId))
			{
				return _context.Bookings.Where(patient => patient.PatientId == null).ToList();
			}
			else
			{
				return _context.Bookings.Where(caregiver => caregiver.CaregiverId == caregiverId).Where(patient => patient.PatientId == null).ToList();
			}
		}

		public List<Booking> GetBookings(string id)
		{
			return _context.Bookings.Where(p => p.PatientId == id)
				.Include(c => c.Caregiver)
				.ToList();
		}

		public Booking UpdateBooking(int id, string patientId, string? note)
		{
			Booking booking = _context.Bookings.First(dbApointment => dbApointment.BookingId == id);

			booking.PatientId = patientId;

			if(note != null)
			{
				booking.Note = note.ToString();
			}

			_context.SaveChanges();
			return booking;
		}

        public List<Booking> GetBookingsForCaregivers(string id)
        {
            return _context.Bookings.Where(p => p.CaregiverId == id).ToList();
        }

    }
}

