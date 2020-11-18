using NUnit.Framework;
using SpartaProjectBusiness;
using SpartaProjectDB;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpartaProjectModel.Services;

namespace SpartaProjectTests
{
	public class CRUDProductTests
	{
		CRUDManagerProduct _crud;
		IProductService productService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			var options = new DbContextOptionsBuilder<ProjectContext>()
				.UseInMemoryDatabase(databaseName: "Test_DB")
				.Options;
			var context = new ProjectContext(options);
			productService = new ProductService(context);
			_crud = new CRUDManagerProduct(productService);
			_crud.Create("test", 5, "testURL");
		}

		[Test]
		public void WhenANewProductIsCreated_ItIsAddedToTheDatabaseAndItsDetailsAreCorrect()
		{
			_crud.Create("newTest", 10, "testURL");

			Product newProduct = _crud.GetProductByName("newTest");

			Assert.That(newProduct.Name, Is.EqualTo("newTest"));
			Assert.That(newProduct.Price, Is.EqualTo(10));
			Assert.That(newProduct.Url, Is.EqualTo("testURL"));
		}

		[Test]
		[Ignore ("Uses old db")]
		public void WhenProductsValuesAreChanged_TheDatabaseIsUpdated()
		{
			using (var db = new ProjectContext())
			{
				Product testProduct = new Product
				{
					Name = "change",
					Url = "change",
					Price = 0
				};
				db.Products.Add(testProduct);
				db.SaveChanges();

				_crud.Update(testProduct, "testProduct", 1,"url");
				db.SaveChanges();

				var selectUpdated =
					from p in db.Products
					where p.ProductId == testProduct.ProductId
					select new { p.Name, p.Price, p.Url };

				string newName = selectUpdated.FirstOrDefault().Name;
				string newUrl = selectUpdated.FirstOrDefault().Url;
				decimal newPrice = selectUpdated.FirstOrDefault().Price;

				Assert.AreEqual("testProduct", newName);
				Assert.AreEqual("url", newUrl);
				Assert.AreEqual(1, newPrice);
			}
		}

		[Test]
		public void WhenAProductIsRemoved_ItIsRemovedFromTheDatabase()
		{
			_crud.Create("newTest", 10, "testURL");

			Product newProduct = _crud.GetProductByName("newTest");

			_crud.Delete(newProduct);

			Assert.That(_crud.GetProductByName("newTest"), Is.Null);
		}

		[Test]
		[Ignore("Uses old db")]
		public void WhenAProductIsRemoved_ItIsNoLongerInTheDatabase()
		{
			using (var db = new ProjectContext())
			{
				Product testProduct = new Product
				{
					Name = "testProduct"
				};
				db.Products.Add(testProduct);
				db.SaveChanges();

				_crud.Delete(testProduct);

				Product newProductSelected = db.Products.Where(p => p.ProductId == testProduct.ProductId).FirstOrDefault();

				CollectionAssert.DoesNotContain(db.Products, newProductSelected);
			}
		}
	}
}
