using NUnit.Framework;
using SpartaProjectBusiness;
using SpartaProjectDB;
using System.Linq;

namespace SpartaProjectTests
{
	public class CRUDOrderTests
	{
		CRUDManagerOrder _crud = new CRUDManagerOrder();

		[SetUp]
		public void Setup()
		{
			using (var db = new ProjectContext())
			{
				var selectedOrders =
					from o in db.Orders
					where o.CustomerId == db.Customers.FirstOrDefault().CustomerId
					select o;

				db.Orders.RemoveRange(selectedOrders);

				db.SaveChanges();
			}
		}

		[TearDown]
		public void TearDown()
		{
			using (var db = new ProjectContext())
			{
				var selectedOrders =
					from o in db.Orders
					where o.CustomerId == db.Customers.FirstOrDefault().CustomerId
					select o;

				db.Orders.RemoveRange(selectedOrders);

				db.SaveChanges();
			}
		}

		[Test]
		public void WhenANewOrderIsAdded_TheNumberOfOrdersIncreasesBy1()
		{
			using (var db = new ProjectContext())
			{
				int originalNum = db.Orders.Count();
				_crud.Create(db.Products.FirstOrDefault(),db.Customers.FirstOrDefault());

				Assert.AreEqual(originalNum + 1, db.Orders.Count());
			}
		}
	}
}
