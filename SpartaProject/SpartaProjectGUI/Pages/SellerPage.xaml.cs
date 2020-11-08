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
		public SellerPage(CRUDManagerUser crudUser)
		{
			InitializeComponent();
			seller_product_frame.Navigate(new ProductPage(crudUser));
		}

	}
}
