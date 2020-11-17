using SpartaProjectDB;

namespace SpartaProjectBusiness
{
	public class CRUDManagerCustomer : CRUDManager
	{
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
