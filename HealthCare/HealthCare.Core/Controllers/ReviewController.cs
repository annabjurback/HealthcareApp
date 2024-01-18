using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthCare.Core.Models;
using Microsoft.AspNetCore.Mvc;
using HealthCare.Core.Repositories;

namespace HealthCare.Core.Controllers
{
	[Route("/api/review")]
	public class ReviewController : ControllerBase
	{
		private readonly IReviewRepository _reviewRepository;
		public ReviewController(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		[HttpPost]
		public ActionResult CreateReview(string reviewText, int rating, string patientId)
		{
			try
			{
				var review = new Review
				{
					ReviewText = reviewText,
					Rating = rating,
					PatientId = patientId
				};

				_reviewRepository.SaveReview(review);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException);
			}
		}

		[HttpGet]
		public ActionResult<List<Review>> GetReviews()
		{
			try
			{
				return Ok(_reviewRepository.GetReviews());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.InnerException);
			}
		}
	}
}
