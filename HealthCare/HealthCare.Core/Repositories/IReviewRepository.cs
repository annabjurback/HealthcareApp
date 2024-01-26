using HealthCare.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Repositories
{
	public interface IReviewRepository
	{
		void SaveReview(Review review);
		List<Review> GetReviews();
	}
}
