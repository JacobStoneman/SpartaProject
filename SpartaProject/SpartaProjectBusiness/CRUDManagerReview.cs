using SpartaProjectDB;
using SpartaProjectModel.Services;
using System.Collections.Generic;

namespace SpartaProjectBusiness
{
	public class CRUDManagerReview : CRUDManager
	{
		public Review Selected { get; set; }
		private new IReviewService _service;

		public CRUDManagerReview()
		{
			_service = new ReviewService(new ProjectContext());
		}

		public CRUDManagerReview(IReviewService service) : base(service)
		{
			_service = service;
		}

		public Review Create(int rating, string comment, Customer customer, Product product)
		{
			Review newReview = new Review()
			{
				CustomerId = customer.CustomerId,
				ProductId = product.ProductId,
				Rating = rating,
				Comment = comment
			};
			_service.Create(newReview);
			
			return newReview;
		}

		public void Update(Review Selected, int rating, string comment)
		{
			Selected.Rating = rating;
			Selected.Comment = comment;
			_service.SaveChanges();
		}

		public Review GetReviewByInfo(int productId, int customerId) => _service.GetReviewByInfo(productId, customerId);
		public List<Review> GetAllProductReviews(int id) => _service.GetAllProductReviews(id);
	}
}
