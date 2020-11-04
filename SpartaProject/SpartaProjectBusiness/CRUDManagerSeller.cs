using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpartaProjectBusiness
{
	class CRUDManagerSeller
	{
		public Seller SelectedSeller { get; set; }

		public void SetSelected(object selectedItem)
		{
			SelectedSeller = (Seller)selectedItem;
		}

		public Seller Create(string name)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Seller newSeller = new Seller()
				{
					Name = name
				};

				db.Sellers.Add(newSeller);

				db.SaveChanges();
				return newSeller;
			}
		}

		public List<Seller> RetrieveAll()
		{
			using (ProjectContext db = new ProjectContext())
			{
				return db.Sellers.ToList();
			}
		}

		public void Update(int id, string name)
		{
			using (ProjectContext db = new ProjectContext())
			{
				SelectedSeller = db.Sellers.Where(s => s.SellerId == id).FirstOrDefault();
				SelectedSeller.Name = name;
				db.SaveChanges();
			}
		}

		//TODO: Needs to remove links to other tables
		public void Delete(int id)
		{
			using (ProjectContext db = new ProjectContext())
			{
				SelectedSeller = db.Sellers.Where(s => s.SellerId == id).FirstOrDefault();
				db.Sellers.Remove(SelectedSeller);
				db.SaveChanges();
			}
		}
	}
}
