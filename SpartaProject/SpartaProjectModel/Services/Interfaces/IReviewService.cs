using SpartaProjectDB;
using System.Collections.Generic;

namespace SpartaProjectModel.Services
{
	public interface IReviewService : IService
	{
		public Review GetReviewById(int id);
		public Review GetReviewByInfo(int productId, int userId);
		public List<Review> GetAllProductReviews(int id);
	}
}
