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
		ProductService productService;

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

		[SetUp]
		public void Setup()
		{
			using (var db = new ProjectContext())
			{
				var selectedProducts =
					from p in db.Products
					where p.Name == "testProduct"
					select p;

				db.Products.RemoveRange(selectedProducts);

				db.SaveChanges();
			}
		}

		[TearDown]
		public void TearDown()
		{
			using (var db = new ProjectContext())
			{
				var selectedProducts =
					from p in db.Products
					where p.Name == "testProduct"
					select p;

				db.Products.RemoveRange(selectedProducts);

				db.SaveChanges();
			}
		}

		[Test]
		public void WhenANewProductIsAdded_TheNumberOfProductsIncreasesBy1()
		{
			using (var db = new ProjectContext())
			{
				int originalNum = db.Products.Count();
				_crud.Create("testProduct", 1, "url");

				Assert.AreEqual(originalNum + 1, db.Products.Count());
			}
		}

		[Test]
		public void WhenANewProductIsAdded_ItsDetailsAreCorrect()
		{
			using (var db = new ProjectContext())
			{
				_crud.Create("testProduct", 1, "url");
				Product newProductSelected = db.Products.Where(p => p.Name == "testProduct").FirstOrDefault();
				Assert.AreEqual("testProduct", newProductSelected.Name);
				Assert.AreEqual(1, newProductSelected.Price);
				Assert.AreEqual("url", newProductSelected.Url);
			}
		}

		[Test]
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
