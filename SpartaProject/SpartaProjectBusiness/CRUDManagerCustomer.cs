using SpartaProjectDB;
using SpartaProjectModel.Services;

namespace SpartaProjectBusiness
{
	public class CRUDManagerCustomer : CRUDManager
	{
		private new ICustomerService _service;

		public CRUDManagerCustomer()
		{
			_service = new CustomerService(new ProjectContext());
		}

		public CRUDManagerCustomer(ICustomerService service) : base(service)
		{
			_service = service;
		}

		public Customer Selected { get; set; }

		public Customer Create(User user)
		{
			Customer newCustomer = new Customer()
			{
				UserId = user.UserId
			};

			_service.Create(newCustomer);

			return newCustomer;
		}

		public Customer GetCustomerById(int id) => _service.GetCustomerById(id);
		public Customer GetCustomerByUserId(int id) => _service.GetCustomerByUserId(id);
	}
}
