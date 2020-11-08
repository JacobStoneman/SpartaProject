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

namespace SpartaProjectGUI
{
	/// <summary>
	/// Interaction logic for SellerPage.xaml
	/// </summary>
	public partial class SellerPage : Page
	{
		const string defaultImage = "https://www.tibs.org.tw/images/default.jpg";
		CRUDManagerUser CrudUser;
		CRUDManagerProduct CrudProduct = new CRUDManagerProduct();
		public SellerPage(CRUDManagerUser crudUser)
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
		}

		private void PopulateProductList()
		{
			using (ProjectContext db = new ProjectContext())
			{
				listBox_product.ItemsSource = CrudProduct.RetrieveAll(db.Products);
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
		}
	}
}
