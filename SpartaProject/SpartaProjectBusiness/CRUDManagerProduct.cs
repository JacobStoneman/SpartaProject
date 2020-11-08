using Microsoft.EntityFrameworkCore;
using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpartaProjectBusiness
{
	public class CRUDManagerProduct : CRUDManager
	{
		public Product Selected { get; set; }

		public Product Create(string name, decimal price, string url)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Product newProduct = new Product()
				{
					Name = name,
					Price = price,
					Url = url
				};

				db.Products.Add(newProduct);
				db.SaveChanges();

				return newProduct;
			}
		}

		public void Update(int productId, string name, decimal price, string url)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Selected = db.Products.Where(p => p.ProductId == productId).FirstOrDefault();
				Selected.Name = name;
				Selected.Price = price;
				Selected.Url = url;
				db.SaveChanges();
			}
		}

		public void Delete(int productId)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Selected = db.Products.Where(p => p.ProductId == productId).FirstOrDefault();
				db.Products.Remove(Selected);
				db.SaveChanges();
			}
		}
	}
}
