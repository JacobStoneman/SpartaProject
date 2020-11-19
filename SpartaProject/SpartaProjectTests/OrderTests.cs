using NUnit.Framework;
using SpartaProjectBusiness;
using SpartaProjectDB;
using Microsoft.EntityFrameworkCore;
using SpartaProjectModel.Services;
using System.Linq;
using Moq;
using System.Collections.Generic;

namespace SpartaProjectTests
{
	public class OrderTests
	{
		CRUDManagerOrder _crud;
		IOrderService orderService;
		Product testProduct;
		Customer testCustomer;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			DbContextOptions<ProjectContext> options = new DbContextOptionsBuilder<ProjectContext>()
				.UseInMemoryDatabase(databaseName: "Test_DB")
				.Options;
			ProjectContext context = new ProjectContext(options);
			orderService = new OrderService(context);
			_crud = new CRUDManagerOrder(orderService);

			testProduct = new Product() { ProductId = 1, Name = "testProduct", Price = 5, Url = "testUrl" };
			testCustomer = new Customer() { CustomerId = 1, UserId = 1 };
		}

		[Test]
		[Category("CRUD")]
		public void WhenANewOrderIsCreated_ItIsAddedToTheDatabase()
		{
			int originalNum = _crud.RetrieveAll<Order>().Count;
			Order newOrder = _crud.Create(testProduct,testCustomer);
			
			Assert.That(originalNum + 1, Is.EqualTo(_crud.RetrieveAll<Order>().Count));

			_crud.Delete(newOrder);
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
