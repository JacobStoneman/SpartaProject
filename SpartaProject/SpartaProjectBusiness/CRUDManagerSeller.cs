using SpartaProjectDB;
using System.Linq;

namespace SpartaProjectBusiness
{
	public class CRUDManagerSeller : CRUDManager
	{
		public Seller Selected { get; set; }

		public Seller Create(User user)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Seller newSeller = new Seller()
				{
					User = user,
					UserId = user.UserId
				};

				db.Sellers.Add(newSeller);

				db.SaveChanges();
				return newSeller;
			}
		}
	}
}
