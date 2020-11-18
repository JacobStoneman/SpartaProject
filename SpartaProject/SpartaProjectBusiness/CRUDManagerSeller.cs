using SpartaProjectDB;
using SpartaProjectModel.Services;

namespace SpartaProjectBusiness
{
	public class CRUDManagerSeller : CRUDManager
	{
		private new ISellerService _service;

		public CRUDManagerSeller()
		{
			_service = new SellerService(new ProjectContext());
		}

		public CRUDManagerSeller(ISellerService service) : base(service)
		{
			_service = service;
		}

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

		public Seller GetSellerById(int id) => _service.GetSellerById(id);
		public Seller GetSellerByUserId(int id) => _service.GetSellerByUserId(id);
	}
}
