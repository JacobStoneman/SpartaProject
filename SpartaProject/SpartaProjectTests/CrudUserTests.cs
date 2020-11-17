using NUnit.Framework;
using SpartaProjectBusiness;
using SpartaProjectDB;
using System.Linq;

namespace SpartaProjectTests
{
	public class CRUDUserTests
	{
		CRUDManagerUser _crud = new CRUDManagerUser();

		[SetUp]
		public void Setup()
		{
			using (var db = new ProjectContext())
			{
				var selectedUsers =
					from u in db.Users
					where u.Name == "testUser"
					select u;

				db.Users.RemoveRange(selectedUsers);

				db.SaveChanges();
			}
		}

		[TearDown]
		public void TearDown()
		{
			using (var db = new ProjectContext())
			{
				var selectedUsers =
					from u in db.Users
					where u.Name == "testUser"
					select u;

				db.Users.RemoveRange(selectedUsers);

				db.SaveChanges();
			}
		}

		[Test]
		public void WhenANewSellerIsAdded_TheNumberOfSellersIncreasesBy1()
		{
			using (var db = new ProjectContext())
			{
				int originalNum = db.Sellers.Count();
				_crud.Create("testUser","testPassword",0);

				Assert.AreEqual(originalNum + 1, db.Sellers.Count());
			}
		}

		[Test]
		public void WhenANewSellerIsAdded_TheirDetailsAreCorrect()
		{
			using (var db = new ProjectContext())
			{
				_crud.Create("testUser", "testPassword", 1);
				User newSellerSelected = db.Users.Where(u => u.Name == "testUser").FirstOrDefault();
				Assert.AreEqual("testUser", newSellerSelected.Name);
				Assert.AreEqual("testPassword", newSellerSelected.Password);
				Assert.AreEqual(1, newSellerSelected.AccountType);
			}
		}

		[Test]
		public void WhenUserValuesAreChanged_TheDatabaseIsUpdated()
		{
			using (var db = new ProjectContext())
			{
				User testUser = new User
				{
					Name = "change",
					Password = "change"
				};
				db.Users.Add(testUser);
				db.SaveChanges();

				_crud.Update(testUser, "testUser", "password");
				db.SaveChanges();

				var selectUpdated =
					from u in db.Users
					where u.UserId == testUser.UserId
					select new { u.Name , u.Password};

				string newName = selectUpdated.FirstOrDefault().Name;
				string newPassword = selectUpdated.FirstOrDefault().Password;

				Assert.AreEqual("testUser", newName);
				Assert.AreEqual("password", newPassword);
			}
		}

		[Test]
		public void WhenAUserIsRemoved_TheyAreNoLongerInTheDatabase()
		{
			using (var db = new ProjectContext())
			{
				User testUser = new User
				{
					Name = "testUser"
				};
				db.Users.Add(testUser);
				db.SaveChanges();

				_crud.Delete(testUser);

				User newUserSelected = db.Users.Where(u => u.UserId == testUser.UserId).FirstOrDefault();

				CollectionAssert.DoesNotContain(db.Users, newUserSelected);
			}
		}

		[Test]
		public void WhenACustomerIsRemoved_TheyAreNoLongerInTheCustomerTable()
		{
			using (var db = new ProjectContext())
			{
				User testUser = new User
				{
					Name = "testUser",
					AccountType = 1
				};
				db.Users.Add(testUser);
				db.SaveChanges();
				
				Customer newCustomerSelected = db.Customers.Where(c => c.UserId == testUser.UserId).FirstOrDefault();

				_crud.Delete(testUser);

				CollectionAssert.DoesNotContain(db.Customers, newCustomerSelected);
			}
		}

		[Test]
		public void WhenASellerIsRemoved_TheyAreNoLongerInTheSellerTable()
		{
			using (var db = new ProjectContext())
			{
				User testUser = new User
				{
					Name = "testUser",
					AccountType = 0
				};
				db.Users.Add(testUser);
				db.SaveChanges();

				Seller newSellerSelected = db.Sellers.Where(s => s.UserId == testUser.UserId).FirstOrDefault();

				_crud.Delete(testUser);

				CollectionAssert.DoesNotContain(db.Sellers, newSellerSelected);
			}
		}
	}
}