using SpartaProjectDB;
using System.Linq;

namespace SpartaProjectModel.Services
{
	public class CustomerService : UserService, ICustomerService
	{
		public CustomerService(ProjectContext context) : base(context)
		{
		}

		public Customer GetCustomerById(int id) => db.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
	}
}
