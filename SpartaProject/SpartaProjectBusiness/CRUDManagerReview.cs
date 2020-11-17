using Microsoft.EntityFrameworkCore;
using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpartaProjectBusiness
{
	public class CRUDManagerReview : CRUDManager
	{
		public Review Selected { get; set; }

		public Review Create(int rating, string comment, Customer customer, Product product)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Review newReview = new Review()
				{
					CustomerId = customer.CustomerId,
					ProductId = product.ProductId,
					Rating = rating,
					Comment = comment
				};

				db.Reviews.Add(newReview);
				db.SaveChanges();

				return newReview;
			}
		}

		public void Update(int reviewId, int rating, string comment)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Selected = db.Reviews.Where(r => r.ReviewId == reviewId).FirstOrDefault();
				Selected.Rating = rating;
				Selected.Comment = comment;
				db.SaveChanges();
			}
		}

		//public void Delete(int reviewId)
		//{
		//	using (ProjectContext db = new ProjectContext())
		//	{
		//		Selected = db.Reviews.Where(r => r.ReviewId == reviewId).FirstOrDefault();
		//		db.Reviews.Remove(Selected);
		//		db.SaveChanges();
		//	}
		//}
	}
}
