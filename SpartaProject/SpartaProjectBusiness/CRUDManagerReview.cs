using SpartaProjectDB;

namespace SpartaProjectBusiness
{
	public class CRUDManagerReview : CRUDManager
	{
		public Review Selected { get; set; }

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
	}
}
