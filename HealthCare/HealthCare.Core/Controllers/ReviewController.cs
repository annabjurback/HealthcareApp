using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.Core.Models;
using Microsoft.AspNetCore.Mvc;
using HealthCare.Core.Repositories;

namespace HealthCare.Core.Controllers
{
	[Route("/api/review")]
	public class ReviewController
	{
		private readonly IReviewRepository _reviewRepository;
		public ReviewController(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}


		// fråga - ska den mesta logiken ligga i repository eller controller? 
		// för repository: booking tar in ett booking-objekt, medan patient och caregiver tar in strängar och skapar objektet i sina endpoints..

		//[HttpPost]
		//public ActionResult CreateReview(string id, string reviewText)
		//{
		//	Review review 
		//}
	}
}
