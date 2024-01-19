using HealthCare.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Repositories
{
	public interface IBookingRepository
	{
		void CreateBooking(Booking booking);
		List<Booking> GetBookings(string id);
		List<Booking> GetAvailableAppointments(string? caregiverId);
		Booking UpdateBooking(int id, string patientId, string? note);
	}
}
