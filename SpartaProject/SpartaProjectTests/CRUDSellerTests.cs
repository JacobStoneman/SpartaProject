using NUnit.Framework;
using SpartaProjectBusiness;
using SpartaProjectDB;
using System.Linq;

namespace SpartaProjectTests
{
	public class CRUDSellerTests
	{
		CRUDManagerSeller _crud = new CRUDManagerSeller();

		//[SetUp]
		//public void Setup()
		//{
		//	using (var db = new ProjectContext())
		//	{
		//		var selectedSellers =
		//			from s in db.Sellers
		//			where s.Name == "testSeller"
		//			select s;

		//		db.Sellers.RemoveRange(selectedSellers);

		//		db.SaveChanges();
		//	}
		//}

		//[TearDown]
		//public void TearDown()
		//{
		//	using (var db = new ProjectContext())
		//	{
		//		var selectedSellers =
		//			from s in db.Sellers
		//			where s.Name == "testSeller"
		//			select s;

		//		db.Sellers.RemoveRange(selectedSellers);

		//		db.SaveChanges();
		//	}
		//}

		//[Test]
		//public void WhenANewSellerIsAdded_TheNumberOfSellersIncreasesBy1()
		//{
		//	using (var db = new ProjectContext())
		//	{
		//		int originalNum = db.Sellers.Count();
		//		_crud.Create("testSeller");

		//		Assert.AreEqual(originalNum + 1, db.Sellers.Count());
		//	}
		//}

		//[Test]
		//public void WhenANewSellerIsAdded_TheirDetailsAreCorrect()
		//{
		//	using (var db = new ProjectContext())
		//	{
		//		_crud.Create("testSeller");
		//		Seller newSellerSelected = db.Sellers.Where(s => s.Name == "testSeller").FirstOrDefault();
		//		Assert.AreEqual("testSeller", newSellerSelected.Name);
		//	}
		//}

		//[Test]
		//public void WhenASellerNameIsChanged_TheDatabaseIsUpdated()
		//{
		//	using (var db = new ProjectContext())
		//	{
		//		Seller testSeller = new Seller
		//		{
		//			Name = "change"
		//		};
		//		db.Sellers.Add(testSeller);
		//		db.SaveChanges();

		//		_crud.Update(testSeller.SellerId, "testSeller");


		//		var selectNewName =
		//			from s in db.Sellers
		//			where s.SellerId == testSeller.SellerId
		//			select s.Name;

		//		string newName = selectNewName.FirstOrDefault();

		//		Assert.AreEqual("testSeller", newName);
		//	}
		//}

		//[Test]
		//public void WhenASellerrIsRemoved_TheyAreNoLongerInTheDatabase()
		//{
		//	using (var db = new ProjectContext())
		//	{
		//		Seller testSeller = new Seller
		//		{
		//			Name = "testSeller"
		//		};
		//		db.Sellers.Add(testSeller);
		//		db.SaveChanges();

		//		_crud.Delete(testSeller.SellerId);

		//		Seller newSellerSelected = db.Sellers.Where(s => s.SellerId == testSeller.SellerId).FirstOrDefault();

		//		CollectionAssert.DoesNotContain(db.Customers, newSellerSelected);
		//	}
		//}
	}
}