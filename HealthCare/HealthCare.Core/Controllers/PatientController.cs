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
	[Route("/patient")]
	//[ApiController]
	public class PatientController : ControllerBase
	{
		private readonly HealthcareContext _context;

		public PatientController(HealthcareContext context) 
		{
			_context = context;
		}

		//[HttpGet("/patientexist")]
		//public bool PatientExists(string patientId)
		//{
		//	if (_context.Patients.FirstOrDefault(x => x.PatientId == patientId) != null)
		//	{
		//		return true;
		//	}
		//	else
		//	{
		//		return false;
		//	}
		//}

		[HttpPost("/savepatient")]
		public ActionResult SavePatient(string patientId, string? firstName, string? lastName, string email)
		{
			try
			{
				var Patient = new Patient
				{
					// for firstName and lastName: if value is null set empty string
					PatientId = patientId,
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
		public ActionResult<Patient> GetPatient(string patientId)
		{
			try
			{
				return Ok(_context.Patients.Single(x => x.PatientId == patientId));
			}
			catch (Exception ex)
			{
				return NotFound(ex.InnerException);
			}
		}

		[HttpPut("/patient")]
		public ActionResult UpdatePatient(string patientId, string firstName, string lastName)
		{
			try
			{
				var patient = _context.Patients.Single(x => x.PatientId == patientId);
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
