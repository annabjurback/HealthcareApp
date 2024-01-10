using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.Core.Context;
using Microsoft.EntityFrameworkCore;
using HealthCare.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Core.Controllers
{
	//[Route("/patient")]
	public class PatientController : ControllerBase
	{
		private readonly HealthcareContext _context;

		public PatientController(HealthcareContext context) 
		{
			_context = context;
		}

		[HttpPost("/savepatient")]
		public ActionResult SavePatient(string id, string? firstName, string? lastName, string email)
		{
			try
			{
				var Patient = new Patient
				{
					// for firstName and lastName: if value is null set empty string
					PatientId = id,
					FirstName = firstName ?? "",
					LastName = lastName ?? "",
					Email = email,
				};
				_context.Patients.Add(Patient);
				_context.SaveChanges();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException);
			}
		}

		[HttpGet("/patient")]
		public ActionResult<Patient> GetPatient(string id)
		{
			try
			{
				return Ok(_context.Patients.Single(x => x.PatientId == id));
			}
			catch (Exception ex)
			{
				return NotFound(ex.InnerException);
			}
		}

		[HttpPut("/updatepatient")]
		public ActionResult UpdatePatient(string id, string firstName, string lastName)
		{
			//fix error handling here!
			try
			{
				var patient = _context.Patients.Single(x => x.PatientId == id);
				patient.FirstName = firstName;
				patient.LastName = lastName;
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				return NotFound(ex.InnerException);
			}
			return Ok();
		}
	}
}
