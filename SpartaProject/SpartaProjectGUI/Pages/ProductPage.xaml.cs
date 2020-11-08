using SpartaProjectBusiness;
using SpartaProjectGUI.Pages;
using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpartaProjectGUI.Pages
{
	/// <summary>
	/// Interaction logic for ProductPage.xaml
	/// </summary>
	public partial class ProductPage : Page
	{
		const string defaultImage = "https://www.tibs.org.tw/images/default.jpg";
		CRUDManagerUser CrudUser;
		CRUDManagerProduct CrudProduct = new CRUDManagerProduct();
		public ProductPage(CRUDManagerUser crudUser)
		{
			CrudUser = crudUser;
			InitializeComponent();
			InitialiseValues();
			PopulateProductList();
		}

		private void InitialiseValues()
		{
			BitmapImage image = new BitmapImage(new Uri(defaultImage, UriKind.Absolute));
			image_product.Source = image;
			textBlock_product_id_value.Text = string.Empty;
			textBlock_product_name_value.Text = string.Empty;
			textBlock_product_price_value.Text = string.Empty;
			textBlock_product_rating_value.Text = string.Empty;

			if (CrudUser.Selected.AccountType == 0)
			{
				button_configure_product.IsEnabled = true;
				button_configure_product.Visibility = Visibility.Visible;
				button_order_product.IsEnabled = false;
				button_order_product.Visibility = Visibility.Hidden;
			} else if (CrudUser.Selected.AccountType == 1)
			{
				button_configure_product.IsEnabled = false;
				button_configure_product.Visibility = Visibility.Hidden;
				button_order_product.IsEnabled = true;
				button_order_product.Visibility = Visibility.Visible;
			}
		}

		private void PopulateProductList()
		{
			using (ProjectContext db = new ProjectContext())
			{
				//listBox_product.ItemsSource = CrudProduct.RetrieveAll(db.Products);
				//listBox_product.Items.Clear();
				List<Product> allProducts = CrudProduct.RetrieveAll(db.Products);
				if (textBox_product_search.Text == string.Empty)
				{
					listBox_product.ItemsSource = allProducts;
				}
				else
				{
					List<Product> searchResults = new List<Product>();
					foreach (Product prod in allProducts)
					{
						string nameUpper = prod.Name.ToUpper();
						if (nameUpper.Contains(textBox_product_search.Text.ToUpper()))
						{
							searchResults.Add(prod);
						}
					}
					listBox_product.ItemsSource = searchResults;
				}
			}
		}

		private void SetProductValues()
		{
			if (CrudProduct.Selected == null)
			{
				InitialiseValues();
			}
			else
			{
				try
				{
					BitmapImage image = new BitmapImage(new Uri(CrudProduct.Selected.Url, UriKind.Absolute));
					image_product.Source = image;
				}
				catch (UriFormatException)
				{
					BitmapImage image = new BitmapImage(new Uri(defaultImage, UriKind.Absolute));
					image_product.Source = image;
				}

				textBlock_product_name_value.Text = CrudProduct.Selected.Name;
				textBlock_product_id_value.Text = CrudProduct.Selected.ProductId.ToString();
				textBlock_product_price_value.Text = $"£{CrudProduct.Selected.Price}";
				//TODO: Rating updated here
			}
		}

		private void button_configure_product_Click(object sender, RoutedEventArgs e)
		{
			ProductConfig config = new ProductConfig(CrudProduct);
			config.Closed += ProductConfigClosed;
			config.ShowDialog();
		}

		private void ProductConfigClosed(object sender, EventArgs e)
		{
			PopulateProductList();
			CrudProduct.Selected = null;
		}

		private void listBox_product_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CrudProduct.Selected = CrudProduct.SetSelected<Product>(listBox_product.SelectedItem);
			SetProductValues();
		}

		private void textBox_product_search_TextChanged(object sender, TextChangedEventArgs e)
		{
			PopulateProductList();
		}
	}
}
