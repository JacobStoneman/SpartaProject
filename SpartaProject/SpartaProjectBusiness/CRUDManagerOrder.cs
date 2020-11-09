using Microsoft.EntityFrameworkCore;
using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SpartaProjectBusiness
{
	public class CRUDManagerOrder : CRUDManager
	{
		const int daysFromOrderToShip = 3;
		public Order Selected;

		public Order Create(Product product, Customer customer)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Order newOrder = new Order()
				{
					ProductId = product.ProductId,
					CustomerId = customer.CustomerId,
					OrderDate = DateTime.Today,
					ShipDate = DateTime.Today.AddDays(daysFromOrderToShip)
				};

				db.Orders.Add(newOrder);
				db.SaveChanges();

				return newOrder;
			}
		}

		public void MarkAsShipped(Order order)
		{
			using (ProjectContext db = new ProjectContext())
			{
				db.Orders.Where(o => o.OrderId == order.OrderId).FirstOrDefault().Shipped = true;
				db.SaveChanges();
			}
		}

		public void Delete(int orderId)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Selected = db.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
				db.Orders.Remove(Selected);
				db.SaveChanges();
			}
		}
	}
}
