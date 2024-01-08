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
			_context.Patients.Add(Patient);
			_context.SaveChanges();
		}

		[HttpGet("/patient")]
		public ActionResult<Patient> GetPatient(string patientId)
		{
			return Ok(_context.Patients.Single(x => x.PatientId == patientId));
		}
	}
}
