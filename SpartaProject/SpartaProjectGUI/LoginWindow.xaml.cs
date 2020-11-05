using SpartaProjectBusiness;
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
	public partial class LoginWindow : Window
	{
		CRUDManagerSeller crudSeller = new CRUDManagerSeller();
		CRUDManagerCustomer crudCustomer = new CRUDManagerCustomer();

		public LoginWindow()
		{
			InitializeComponent();
		}

		private void button_configure_user_Click(object sender, RoutedEventArgs e)
		{
			AccountConfig config = new AccountConfig(crudSeller,crudCustomer);
			config.Closed += AccountConfigClosed;
			config.ShowDialog();
		}
		private void AccountConfigClosed(object sender, EventArgs e)
		{

		}

		private void button_login_Click(object sender, RoutedEventArgs e)
		{
			CustomerWindow win = new CustomerWindow();
			Content = win;
		}

	}
}
