using SpartaProjectDB;
using System.Collections.Generic;

namespace SpartaProjectModel.Services
{
	public interface IOrderService : IService
	{
		public Order GetOrderById(int id);

		public List<Order> GetAllOrdersByCustomer(Customer customer);
	}
}
