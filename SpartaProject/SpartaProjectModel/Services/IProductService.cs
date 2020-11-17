using SpartaProjectDB;

namespace SpartaProjectModel.Services
{
	public interface IProductService : IService
	{
		public Product GetProductById(int id);
	}
}
