using SpartaProjectDB;

namespace SpartaProjectModel.Services
{
	public interface IUserService : IService
	{
		public User GetUserById(int id);

		public bool ExistsByName(string name);
	}
}
