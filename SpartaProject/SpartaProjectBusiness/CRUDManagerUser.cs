using SpartaProjectDB;
using SpartaProjectModel.Services;

namespace SpartaProjectBusiness
{
	public class CRUDManagerUser : CRUDManager
	{
		private new IUserService _service;

		public CRUDManagerUser()
		{
			_service = new UserService(new ProjectContext());
		}

		public CRUDManagerUser(IUserService service) : base(service)
		{
			_service = service;
		}

		public User Selected { get; set; }
		public User Create(string name, string password, int accountType)
		{
			User newUser = new User()
			{
				Name = name,
				Password = password,
				AccountType = accountType
			};

			_service.Create(newUser);

			if (accountType == 0)
			{
				CRUDManagerSeller seller = new CRUDManagerSeller();
				seller.Create(newUser);
			} else if (accountType == 1)
			{
				CRUDManagerCustomer customer = new CRUDManagerCustomer();
				customer.Create(newUser);
			}

			return newUser;
		}

		public void Update(User Selected, string name, string password)
		{
			Selected.Name = name;
			Selected.Password = password;
			_service.SaveChanges();
		}

		public bool ExistsByName(string name) => _service.ExistsByName(name);
	}
}
