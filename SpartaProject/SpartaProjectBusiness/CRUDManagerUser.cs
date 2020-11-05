using Microsoft.EntityFrameworkCore;
using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpartaProjectBusiness
{
	public class CRUDManagerUser : CRUDManager
	{
		public User Selected { get; set; }
		public User Create(string name, string password, int accountType)
		{
			using (ProjectContext db = new ProjectContext())
			{
				User newUser = new User()
				{
					Name = name,
					Password = password,
					AccountType = accountType
				};
				db.Users.Add(newUser);

				if (accountType == 0)
				{
					CRUDManagerSeller seller = new CRUDManagerSeller();
					seller.Create(newUser);
				} else if (accountType == 1)
				{
					CRUDManagerCustomer customer = new CRUDManagerCustomer();
					customer.Create(newUser);
				}

				return newUser;
			}
		}

		public void Update(int userId, string name, string password)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Selected = db.Users.Where(u => u.UserId == userId).FirstOrDefault();
				Selected.Name = name;
				Selected.Password = password;
				db.SaveChanges();
			}
		}

		public void Delete(int userId)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Selected = db.Users.Where(u => u.UserId == userId).FirstOrDefault();

				db.Users.Remove(Selected);

				db.SaveChanges();
			}
		}
	}
}
