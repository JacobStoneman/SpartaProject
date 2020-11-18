using NUnit.Framework;
using SpartaProjectBusiness;
using SpartaProjectDB;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SpartaProjectTests
{
	public class CRUDOrderTests
	{
		CRUDManagerOrder _crud = new CRUDManagerOrder();

		//[OneTimeSetUp]
		//public void OneTimeSetUp()
		//{
		//	DbContextOptions options = new DbContextOptionsBuilder<ProjectContext>()
		//		.UseInMemoryDatabase(databaseName: "Test_DB")
		//		.Options;
		//	var context = new ProjectContext(options);
		//}

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
		[Ignore("Using old db implementation")]
		public void WhenANewOrderIsAdded_TheNumberOfOrdersIncreasesBy1()
		{
			using (var db = new ProjectContext())
			{
				int originalNum = db.Orders.Count();
				_crud.Create(db.Products.FirstOrDefault(),db.Customers.FirstOrDefault());

				Assert.AreEqual(originalNum + 1, db.Orders.Count());
			}
		}

		[Test]
		[Ignore("Using old db implementation")]
		public void OrderIsMarkedAsShipped()
		{
			using (var db = new ProjectContext())
			{
				Order testOrder = new Order()
				{
					ProductId = db.Products.FirstOrDefault().ProductId,
					CustomerId = db.Customers.FirstOrDefault().CustomerId,
					Shipped = false
				};
				db.Orders.Add(testOrder);
				db.SaveChanges();
				_crud.MarkAsShipped(testOrder);
				db.SaveChanges();

				var selectUpdated =
					from o in db.Orders
					where o.OrderId == testOrder.OrderId
					select o.Shipped;

				bool result = selectUpdated.FirstOrDefault();

				Assert.AreEqual(true, result);
			}
		}


		[Test]
		[Ignore("Using old db implementation")]
		public void WhenAnOrderIsRemoved_ItIsNoLongerInTheDatabase()
		{
			using (var db = new ProjectContext())
			{
				Order testOrder = new Order()
				{
					ProductId = db.Products.FirstOrDefault().ProductId,
					CustomerId = db.Customers.FirstOrDefault().CustomerId,
					Shipped = false
				};
				db.Orders.Add(testOrder);
				db.SaveChanges();

				_crud.Delete(testOrder);

				Order newOrderSelected = db.Orders.Where(o => o.OrderId == testOrder.OrderId).FirstOrDefault();

				Assert.AreEqual(null, newOrderSelected);
				CollectionAssert.DoesNotContain(db.Orders, newOrderSelected);
			}
		}
	}
}
