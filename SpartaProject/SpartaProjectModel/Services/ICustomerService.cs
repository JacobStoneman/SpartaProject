using SpartaProjectDB;

namespace SpartaProjectModel.Services
{
	public interface ICustomerService : IService
	{
		public Customer GetCustomerById(int id);
	}
}
