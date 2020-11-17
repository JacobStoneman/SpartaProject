using SpartaProjectDB;
using System;

namespace SpartaProjectBusiness
{
	public class CRUDManagerOrder : CRUDManager
	{
		const int daysFromOrderToShip = 3;
		public Order Selected;

		public Order Create(Product product, Customer customer)
		{
			Order newOrder = new Order()
			{
				ProductId = product.ProductId,
				CustomerId = customer.CustomerId,
				OrderDate = DateTime.Today,
				ShipDate = DateTime.Today.AddDays(daysFromOrderToShip)
			};

			_service.Create(newOrder);

			return newOrder;
		}

		public void MarkAsShipped(Order order)
		{
			order.Shipped = true;
			_service.SaveChanges();
		}
	}
}
