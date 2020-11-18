using SpartaProjectDB;
using System.Linq;


namespace SpartaProjectModel.Services
{
	public class SellerService : UserService, ISellerService
	{
		public SellerService(ProjectContext context) : base(context)
		{
		}

		public Seller GetSellerById(int id) => db.Sellers.Where(s => s.SellerId == id).FirstOrDefault();
		public Seller GetSellerByUserId(int id) => db.Sellers.Where(s => s.UserId == id).FirstOrDefault();
	}
}
