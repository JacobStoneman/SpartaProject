using SpartaProjectDB;
using System.Collections.Generic;
using System.Linq;

namespace SpartaProjectModel.Services
{
	public class ReviewService : Service, IReviewService
	{
		public ReviewService(ProjectContext context) : base(context)
		{
		}

		public Review GetReviewById(int id) => db.Reviews.Where(r => r.ReviewId == id).FirstOrDefault();
		public Review GetReviewByInfo(int productId, int userId) => db.Reviews.Where(r => r.ProductId == productId && r.Customer.User.UserId == userId).FirstOrDefault();
		public List<Review> GetAllProductReviews(int id) => (from r in db.Reviews where r.ProductId == id select r).ToList();
	}
}
