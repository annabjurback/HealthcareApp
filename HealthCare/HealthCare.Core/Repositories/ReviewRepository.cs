using HealthCare.Core.Context;
using HealthCare.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Repositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly HealthcareContext _context;

		public ReviewRepository(HealthcareContext context)
		{
			_context = context;
		}

		public void SaveReview(Review review)
		{
			_context.Reviews.Add(review);
			_context.SaveChanges();
		}

		public List<Review> GetReviews()
		{
			return _context.Reviews.OrderByDescending(id => id.ReviewId).Take(15).ToList();
		}
	}
}
