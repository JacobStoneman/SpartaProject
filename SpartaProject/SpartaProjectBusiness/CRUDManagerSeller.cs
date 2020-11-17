using SpartaProjectDB;

namespace SpartaProjectBusiness
{
	public class CRUDManagerSeller : CRUDManager
	{
		public Seller Selected { get; set; }

		public Seller Create(User user)
		{
			Seller newSeller = new Seller()
			{
				UserId = user.UserId
			};

			_service.Create(newSeller);

			return newSeller;
		}
	}
}
