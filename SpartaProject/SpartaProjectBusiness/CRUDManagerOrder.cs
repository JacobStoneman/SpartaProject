using SpartaProjectDB;
using System;
using System.Collections.Generic;
using SpartaProjectModel.Services;

namespace SpartaProjectBusiness
{
	public class CRUDManagerOrder : CRUDManager
	{
		const int daysFromOrderToShip = 3;
		public Order Selected;
		private new IOrderService _service;

		public CRUDManagerOrder()
		{
			_service = new OrderService(new ProjectContext());
		}

		public CRUDManagerOrder(IOrderService service) : base(service)
		{
			_service = service;
		}

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

		public List<Order> GetAllOrdersByCustomer(Customer customer)
		{
			return _service.GetAllOrdersByCustomer(customer);
		}
	}
}
