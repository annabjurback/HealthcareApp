using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HealthCare.Core.Controllers
{
	public class PersonController : Controller //: IHealthcareController
	{
		private readonly HealthcareContext _context;

		public PersonController(HealthcareContext context)
		{
			_context = context;
		}
	}

	//[HttpGet("/person")]   //eller?
	public Person GetPerson(int id)
	{
		// men, vi ska kanske inte skicka HELA personobjektet...?
	}
}
