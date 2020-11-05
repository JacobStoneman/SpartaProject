using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpartaProjectBusiness
{
	public class CRUDManagerSeller : CRUDManager
	{
		public Seller Selected { get; set; }

		//public T SetSelected<T>(object selectedItem)
		//{
		//	SelectedSeller = (T)selectedItem;
		//	return selectedSeller;
		//}

		//public List<Seller> RetrieveAll()
		//{
		//	using (ProjectContext db = new ProjectContext())
		//	{
		//		return db.Sellers.ToList();
		//	}
		//}

		//public Seller Create(string name)
		//{
		//	using (ProjectContext db = new ProjectContext())
		//	{
		//		Seller newSeller = new Seller()
		//		{
		//			Name = name
		//		};

		//		db.Sellers.Add(newSeller);

		//		db.SaveChanges();
		//		return newSeller;
		//	}
		//}


		//public void Update(int id, string name)
		//{
		//	using (ProjectContext db = new ProjectContext())
		//	{
		//		Selected = db.Sellers.Where(s => s.SellerId == id).FirstOrDefault();
		//		Selected.Name = name;
		//		db.SaveChanges();
		//	}
		//}

		//TODO: Needs to remove links to other tables
		public void Delete(int id)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Selected = db.Sellers.Where(s => s.SellerId == id).FirstOrDefault();
				db.Sellers.Remove(Selected);
				db.SaveChanges();
			}
		}
	}
}
