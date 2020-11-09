using SpartaProjectBusiness;
using System;
using System.Collections.Generic;
using System.Text;
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
	/// Interaction logic for CustomerPage.xaml
	/// </summary>
	public partial class CustomerPage : Page
	{
		public CustomerPage(CRUDManagerUser crudUser)
		{
			InitializeComponent();
			customer_product_frame.Navigate(new ProductPage(crudUser));
			customer_order_frame.Navigate(new CustomerOrderPage(crudUser));
		}
	}
}
