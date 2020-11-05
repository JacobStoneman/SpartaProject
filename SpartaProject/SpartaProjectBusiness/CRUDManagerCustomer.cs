using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpartaProjectBusiness
{
	public class CRUDManagerCustomer : CRUDManager
	{
		public Customer Selected { get; set; }

		//public Customer Create(string name)
		//{
		//	using (ProjectContext db = new ProjectContext())
		//	{
		//		Customer newCustomer = new Customer()
		//		{
		//			Name = name
		//		};

		//		db.Customers.Add(newCustomer);

		//		db.SaveChanges();
		//		return newCustomer;
		//	}
		//}

		//public void Update(int id, string name)
		//{
		//	using (ProjectContext db = new ProjectContext())
		//	{
		//		Selected = db.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
		//		Selected.Name = name;
		//		db.SaveChanges();
		//	}
		//}

		//TODO: Needs to remove links to other tables
		public void Delete(int id)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Selected = db.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
				db.Customers.Remove(Selected);
				db.SaveChanges();
			}
		}
	}
}
