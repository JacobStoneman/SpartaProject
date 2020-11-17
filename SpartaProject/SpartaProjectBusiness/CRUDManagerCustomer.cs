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

		public CRUDManagerCustomer(IService service) : base(service)
		{
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
	}
}
