using NUnit.Framework;
using SpartaProjectBusiness;
using SpartaProjectDB;
using System.Linq;

namespace SpartaProjectTests
{
	public class CRUDReviewTests
	{
		CRUDManagerReview _crud = new CRUDManagerReview();

		[SetUp]
		public void Setup()
		{
			using (var db = new ProjectContext())
			{
				var selectedReview =
					from r in db.Reviews
					where r.Comment == "testComment"
					select r;

				db.Reviews.RemoveRange(selectedReview);

				db.SaveChanges();
			}
		}

		[TearDown]
		public void TearDown()
		{
			using (var db = new ProjectContext())
			{
				var selectedReview =
					from r in db.Reviews
					where r.Comment == "testComment"
					select r;

				db.Reviews.RemoveRange(selectedReview);

				db.SaveChanges();
			}
		}

		[Test]
		public void WhenANewReviewIsAdded_TheNumberOfReviewsIncreasesBy1()
		{
			using (var db = new ProjectContext())
			{
				int originalNum = db.Reviews.Count();
				_crud.Create(5,"testComment", db.Customers.FirstOrDefault(), db.Products.FirstOrDefault());

				Assert.AreEqual(originalNum + 1, db.Reviews.Count());
			}
		}

		[Test]
		public void WhenANewOrderIsAdded_ItsDetailsAreCorrect()
		{
			using (var db = new ProjectContext())
			{
				_crud.Create(5, "testComment", db.Customers.FirstOrDefault(), db.Products.FirstOrDefault());
				Review newReviewSelected = db.Reviews.Where(r => r.Comment == "testComment").FirstOrDefault();
				Assert.AreEqual("testComment", newReviewSelected.Comment);
				Assert.AreEqual(5, newReviewSelected.Rating);
			}
		}


		[Test]
		public void WhenReviewsValuesAreChanged_TheDatabaseIsUpdated()
		{
			using (var db = new ProjectContext())
			{
				Review testReview = new Review
				{
					Rating = 1,
					Comment = "Change",
					ProductId = db.Products.FirstOrDefault().ProductId,
					CustomerId = db.Customers.FirstOrDefault().CustomerId
				};
				db.Reviews.Add(testReview);
				db.SaveChanges();

				_crud.Update(testReview.ReviewId,5,"testComment");

				var selectUpdated =
					from r in db.Reviews
					where r.ReviewId == testReview.ReviewId
					select new { r.Comment, r.Rating };

				string newComment = selectUpdated.FirstOrDefault().Comment;
				float newRating = selectUpdated.FirstOrDefault().Rating;

				Assert.AreEqual("testComment", newComment);
				Assert.AreEqual(5, newRating);
			}
		}

		[Test]
		public void WhenAnOrderIsRemoved_ItIsNoLongerInTheDatabase()
		{
			using (var db = new ProjectContext())
			{
				Review testReview = new Review
				{
					Rating = 1,
					Comment = "testComment",
					ProductId = db.Products.FirstOrDefault().ProductId,
					CustomerId = db.Customers.FirstOrDefault().CustomerId
				};
				db.Reviews.Add(testReview);
				db.SaveChanges();

				_crud.Delete(testReview.ReviewId);

				Review newReviewSelected = db.Reviews.Where(r => r.ReviewId == testReview.ReviewId).FirstOrDefault();

				CollectionAssert.DoesNotContain(db.Reviews, newReviewSelected);
			}
		}
	}
}
