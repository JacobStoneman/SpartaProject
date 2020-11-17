using SpartaProjectDB;

namespace SpartaProjectBusiness
{
	public class CRUDManagerProduct : CRUDManager
	{
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
	}
}
