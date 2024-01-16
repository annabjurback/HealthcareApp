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
	public class BookingControllerTests
	{
		private readonly BookingController _sut;
		private readonly IBookingRepository _bookingRepository = Substitute.For<IBookingRepository>();

        public BookingControllerTests()
        {
            _sut = new BookingController(_bookingRepository);
        }
    }
}
