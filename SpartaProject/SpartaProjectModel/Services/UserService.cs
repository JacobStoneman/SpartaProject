using SpartaProjectDB;
using System.Linq;

namespace SpartaProjectModel.Services
{
	public class UserService : Service, IUserService
	{
		public UserService(ProjectContext context) : base(context)
		{
		}

		public User GetUserById(int id) => db.Users.Where(u => u.UserId == id).FirstOrDefault();

		public bool ExistsByName(string name) => db.Users.Any(u => u.Name == name);
	}
}
