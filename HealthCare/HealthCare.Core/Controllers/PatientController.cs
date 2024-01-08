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

		[HttpGet("/patientexist")]
		public bool PatientExists(string patientId)
		{
			if (_context.Patients.Single(x => x.PatientId == patientId) != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		[HttpPost("/savepatient")]
		public void SavePatient(string patientId, string firstName, string lastName, string email)
		{
			// dont forget error handling
			var Patient = new Patient
			{
				PatientId = patientId,
				FirstName = firstName,
				LastName = lastName,
				Email = email,
			};
			try
			{
				_context.Patients.Add(Patient);
				_context.SaveChanges();
			}
			catch (DbUpdateException ex)
			{
				// inner exception
				var innerException = ex.InnerException;
			}
		}

		[HttpGet("/patient")]
		public Patient GetPatient(string patientId)
		{
			return _context.Patients.Single(x => x.PatientId == patientId);
		}
		//public ActionResult<Patient> GetPatient(string patientId)
		//{
		//	return Ok(_context.Patients.Single(x => x.PatientId == patientId));
		//}
	}
}
