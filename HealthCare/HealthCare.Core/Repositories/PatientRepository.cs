using HealthCare.Core.Context;
using HealthCare.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Repositories
{
	public class PatientRepository : IPatientRepository
	{
		private readonly HealthcareContext _context;

        public PatientRepository(HealthcareContext context)
        {
            _context = context;
        }
        public Patient GetPatient(string id)
		{
			return _context.Patients.Single(x => x.PatientId == id);
		}

		public void SavePatient(Patient patient)
		{
			_context.Patients.Add(patient);
			_context.SaveChanges();
		}

		public void UpdatePatient(string id, string firstName, string lastName)
		{
			var patient = _context.Patients.Single(x => x.PatientId == id);
			patient.FirstName = firstName;
			patient.LastName = lastName;
			_context.SaveChanges();
		}
	}
}
