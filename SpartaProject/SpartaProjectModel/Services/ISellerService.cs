using SpartaProjectDB;


namespace SpartaProjectModel.Services
{
	public interface ISellerService : IUserService
	{
		public Seller GetSellerById(int id);
	}
}
