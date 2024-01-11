using HealthCare.Core.Context;
using HealthCare.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HealthCare.Core.Controllers
{
	[Route("/booking")]
	public class BookingController : ControllerBase
	{
		private readonly HealthcareContext _context;

		public BookingController(HealthcareContext context)
		{
			_context = context;
		}

		[HttpPost("/createbooking")]
		public ActionResult CreateBooking(DateTime start,string note, bool completed, string patientId, string caregiverId)
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

				_context.Add(booking);
				_context.SaveChanges();

				return Ok();
			}
			catch 
			{
				return NotFound();
			}
		}

		[HttpGet("/getbooking")]
		public ActionResult<List<Booking>> GetBooking(string patientId)
		{
			try
			{
				var bookings = _context.Bookings.Where(p => p.PatientId == patientId).ToList();

				return Ok(bookings);
			}
			catch
			{
				return NotFound();
			}
		}
	}
}
