using HealthCare.Core.Context;
using HealthCare.Core.Models;
using HealthCare.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HealthCare.Core.Controllers
{
	[Route("/api/booking")]
	public class BookingController : ControllerBase
	{
		private readonly IBookingRepository _bookingRepository;

		public BookingController(IBookingRepository bookingRepository)
		{
			_bookingRepository = bookingRepository;
		}

		[HttpPost]
		public ActionResult CreateBooking(DateTime start,string note, bool completed, string? patientId, string caregiverId)
		{
			try
			{
				var booking = new Booking
				{
					Start = start,
					End = start.AddHours(1),
					Note = note,
					Completed = completed,
					PatientId = patientId,
					CaregiverId = caregiverId
				};

				_bookingRepository.CreateBooking(booking);

				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.InnerException);
			}

		}

		[HttpGet]
		public ActionResult<List<Booking>> GetBookings(string Id)
		{
			try
			{
				var bookings = _bookingRepository.GetBookings(Id);

				return Ok(bookings);
			}
			catch
			{
				return NotFound();
			}
		}

		[HttpGet("/api/booking/getAvailableAppointments")]
		public ActionResult<List<Booking>> GetAvailableAppointments(string? Id)
		{
			try
			{
				return _bookingRepository.GetAvailableAppointments(Id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException);
			}
		}
	}
}
