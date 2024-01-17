using HealthCare.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Repositories
{
	public interface ICaregiverRepository
	{
		void CreateCaregiver(Caregiver caregiver);
		Caregiver GetCaregiver(string id);
		List<Caregiver> GetAll();
		Caregiver EditCaregiver(string id, string firstName, string lastName, string role);
	}
}
