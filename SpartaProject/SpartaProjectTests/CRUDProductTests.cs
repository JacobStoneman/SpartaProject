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
		public void WhenANewProductIsCreated_ItIsAddedToTheDatabase()
		{
			int originalNum = _crud.RetrieveAll<Product>().Count;
			_crud.Create("newTest", 10, "testURL");
			Assert.That(originalNum + 1, Is.EqualTo(_crud.RetrieveAll<Product>().Count));
			
			Product newProduct = _crud.GetProductByName("newTest");
			_crud.Delete(newProduct);
		}

		[Test]
		public void WhenANewProductIsCreated_ItsDetailsAreCorrect()
		{
			_crud.Create("newTest", 10, "testURL");

			Product newProduct = _crud.GetProductByName("newTest");

			Assert.That(newProduct.Name, Is.EqualTo("newTest"));
			Assert.That(newProduct.Price, Is.EqualTo(10));
			Assert.That(newProduct.Url, Is.EqualTo("testURL"));

			_crud.Delete(newProduct);
		}

		[Test]
		public void WhenProductValuesAreChanged_TheDatabaseIsUpdated()
		{
			_crud.Create("change", 5, "changeURL");

			Product testProduct = _crud.GetProductByName("change");

			_crud.Update(testProduct, "newTest", 10, "testURL");

			Product newProduct = _crud.GetProductByName("newTest");

			Assert.That(newProduct, Is.Not.Null);
			Assert.That(newProduct.Name, Is.EqualTo("newTest"));
			Assert.That(newProduct.Price, Is.EqualTo(10));
			Assert.That(newProduct.Url, Is.EqualTo("testURL"));

			_crud.Delete(newProduct);
		}

		[Test]
		public void WhenAProductIsRemoved_ItIsRemovedFromTheDatabase()
		{
			_crud.Create("newTest", 10, "testURL");

			Product newProduct = _crud.GetProductByName("newTest");

			_crud.Delete(newProduct);

			Assert.That(_crud.GetProductByName("newTest"), Is.Null);
		}
	}
}
