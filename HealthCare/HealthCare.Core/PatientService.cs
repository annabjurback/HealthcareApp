using HealthCare.Core.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core
{
	public class PatientService
	{
		private readonly PatientController _controller;
		public PatientService(PatientController controller) 
		{
			_controller = controller;
		}

		public void LogInPatient(Guid patientId, string firstName, string lastName, string email)
		{
			// save patient first if it doesnt exist in db
			if(!_controller.PatientExists(patientId))
			{
				if(firstName == null || firstName == "")
				{
					_controller.SavePatient(patientId, "", "", email);
				}
				else
				{
					_controller.SavePatient(patientId, firstName, lastName, email);
				}
			}
			// then, return patient
			_controller.GetPatient(patientId);
		}
	}
}
