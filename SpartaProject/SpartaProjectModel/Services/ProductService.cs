using SpartaProjectDB;
using System.Linq;

namespace SpartaProjectModel.Services
{
	public class ProductService : Service, IProductService
	{
		public ProductService(ProjectContext context) : base(context)
		{
		}

		public Product GetProductById(int id) => db.Products.Where(p => p.ProductId == id).FirstOrDefault();
	}
}
