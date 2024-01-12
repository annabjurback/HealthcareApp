using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.Core.Context;
using Microsoft.EntityFrameworkCore;
using HealthCare.Core.Models;
using Microsoft.AspNetCore.Mvc;
using HealthCare.Core.Repositories;

namespace HealthCare.Core.Controllers
{
    [Route("/api/patient")]
	public class PatientController : ControllerBase
	{
		private readonly IPatientRepository _patientRepository;
		public PatientController(IPatientRepository patientRepository)
		{
			_patientRepository = patientRepository;
		}

		[HttpPost]
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

				_patientRepository.SavePatient(Patient);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException);
			}
		}

		[HttpGet]
		public ActionResult<Patient> GetPatient(string id)
		{
			try
			{
				return Ok(_patientRepository.GetPatient(id));
			}
			catch (Exception ex)
			{
				return NotFound(ex.InnerException);
			}
		}

		[HttpPut]
		public ActionResult UpdatePatient(string id, string firstName, string lastName)
		{
			//fix error handling here!
			try
			{
				_patientRepository.UpdatePatient(id, firstName, lastName);
			}
			catch (Exception ex)
			{
				return NotFound(ex.InnerException);
			}
			return Ok();
		}
	}
}
