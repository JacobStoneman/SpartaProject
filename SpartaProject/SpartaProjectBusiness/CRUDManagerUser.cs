using SpartaProjectDB;

namespace SpartaProjectBusiness
{
	public class CRUDManagerUser : CRUDManager
	{
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
	}
}
