using SpartaProjectDB;
using System.Collections.Generic;
using System.Linq;

namespace SpartaProjectModel.Services
{
	public class OrderService : Service, IOrderService
	{
		public OrderService(ProjectContext context) : base(context)
		{
		}

		public List<Order> GetAllOrdersByCustomer(Customer customer) => db.Orders.Where(o => o.CustomerId == customer.CustomerId).ToList();

		public Order GetOrderById(int id) => db.Orders.Where(o => o.OrderId == id).FirstOrDefault();
	}
}
