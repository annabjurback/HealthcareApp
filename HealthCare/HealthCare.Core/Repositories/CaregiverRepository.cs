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
	public class CaregiverRepository : ICaregiverRepository
	{
		private readonly HealthcareContext _context;
        public CaregiverRepository(HealthcareContext context)
        {
			_context = context;
        }
        public void CreateCaregiver(Caregiver caregiver)
		{
			_context.Caregivers.Add(caregiver);
			_context.SaveChanges();
		}

		public Caregiver EditCaregiver(string id, string firstName, string lastName, string role)
		{
			var caregiver = _context.Caregivers.Single(x => x.CaregiverId == id);
			caregiver.FirstName = firstName;
			caregiver.LastName = lastName;
			caregiver.Role = role;

			_context.SaveChanges();
			return caregiver;
		}

		public List<Caregiver> GetAll()
		{
			return _context.Caregivers.ToList();
		}

		public Caregiver GetCaregiver(string id)
		{
			return _context.Caregivers.Single(x => x.CaregiverId == id);
		}
	}
}
