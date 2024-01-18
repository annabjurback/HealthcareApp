using HealthCare.Core.Controllers;
using HealthCare.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Test
{
	public class CaregiverControllerTests
	{
		private readonly CaregiverController _sut;
		private readonly ICaregiverRepository _caregiverRepository = Substitute.For<ICaregiverRepository>();

		public CaregiverControllerTests()
		{
			_sut = new CaregiverController(_caregiverRepository);
		}
	}
}
