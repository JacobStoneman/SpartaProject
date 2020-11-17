using SpartaProjectDB;
using SpartaProjectModel.Services;

namespace SpartaProjectBusiness
{
	public class CRUDManagerProduct : CRUDManager
	{
		private new IProductService _service;
		public CRUDManagerProduct()
		{
			_service = new ProductService(new ProjectContext());
		}

		public CRUDManagerProduct(IService service) : base(service)
		{
		}

		public Product Selected { get; set; }

		public Product Create(string name, decimal price, string url)
		{
			Product newProduct = new Product()
			{
				Name = name,
				Price = price,
				Url = url
			};
			_service.Create(newProduct);
			return newProduct;
		}

		public void Update(Product Selected, string name, decimal price, string url)
		{
			Selected.Name = name;
			Selected.Price = price;
			Selected.Url = url;
			_service.SaveChanges();
		}

		public Product GetProductById(int id)
		{
			return _service.GetProductById(id);
		}
	}
}
