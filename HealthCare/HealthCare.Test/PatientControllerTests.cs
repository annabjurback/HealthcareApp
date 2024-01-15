using HealthCare.Core.Controllers;
using HealthCare.Core.Models;
using HealthCare.Core.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Net;

namespace HealthCare.Test
{
	public class PatientControllerTests
	{
		// sut = system under test
		private readonly PatientController _sut;
		// Tell NSubstitute what interface we intend to substitute
		private readonly IPatientRepository _patientRepository = Substitute.For<IPatientRepository>();
		public PatientControllerTests()
		{
			_sut = new PatientController(_patientRepository);
		}

		[Fact]
		public void GetPatient_ShouldReturnPatient_WhenPatientExists()
		{
			// Arrange
			string id = "SomeId";
			string firstName = "Max";
			string lastName = "Hansen";
			// Cast from enum to int for comparison
			var code = (int)HttpStatusCode.OK;
			Patient patient = new() { PatientId = id, FirstName = firstName, LastName = lastName };

			// Tell NSubstitute what to return from our dependancy
			_patientRepository.GetPatient(id).Returns(patient);

			// Act
			// Run target controller method (In this case: PatientController.GetPatient)
			var statusCodeAndPatient = _sut.GetPatient(id);
			// Extract status code object
			var okResult = statusCodeAndPatient.Result as OkObjectResult;
			// Extract Patient object from status code object
			var resultPatient = okResult.Value as Patient;

			// Assert
			Assert.Equal(okResult.StatusCode, code);

			Assert.Equal(id, resultPatient.PatientId);
			Assert.Equal(firstName, resultPatient.FirstName);
			Assert.Equal(lastName, resultPatient.LastName);
		}

		[Fact]
		public void GetPatient_ShouldReturnNotFound_WhenPatientDoesntExist()
		{
			// Arrange
			string id = "SomeId";
			// Cast from enum to int for comparison
			var code = (int)HttpStatusCode.NotFound;
			NotFoundResult notFound = new();
			// Tell NSubstitute what to return from our dependancy
			_patientRepository.GetPatient(id).Returns(x => { throw new Exception(); });

			// Act
			// Run target controller method (In this case: PatientController.GetPatient)
			var statusCodeAndPatient = _sut.GetPatient(id);
			// Extract status code object
			var notFoundResult = statusCodeAndPatient.Result as NotFoundObjectResult;
			// Extract Patient object from status code object

			// Assert
			Assert.Equal(notFoundResult.StatusCode, code);
		}
	}
}