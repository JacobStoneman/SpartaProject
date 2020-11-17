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
	public partial class LoginPage : Page
	{
		CRUDManagerUser CrudUser;

		Frame Window;

		public LoginPage(Frame window, CRUDManagerUser crudUser)
		{
			CrudUser = crudUser;
			InitializeComponent();
			Window = window;

			PopulateUserBox();
		}

		private void PopulateUserBox()
		{
			using (ProjectContext db = new ProjectContext())
			{
				comboBox_username.ItemsSource = CrudUser.RetrieveAll<User>();
			}
		}

		private void button_configure_user_Click(object sender, RoutedEventArgs e)
		{
			AccountConfig config = new AccountConfig(CrudUser);
			config.Closed += AccountConfigClosed;
			config.ShowDialog();
		}
		private void AccountConfigClosed(object sender, EventArgs e)
		{
			PopulateUserBox();
		}

		private void button_login_Click(object sender, RoutedEventArgs e)
		{
			if (CrudUser.Selected != null)
			{
				if (textBox_password.Password == CrudUser.Selected.Password)
				{
					if (CrudUser.Selected.AccountType == 0)
					{
						Window.Navigate(new SellerPage(CrudUser));
					}
					else
					{
						Window.Navigate(new CustomerPage(CrudUser));
					}
				}
				else
				{
					MessageBox.Show("Password Incorrect");
				}
			}
			else
			{
				MessageBox.Show("Please enter a username and password");
			}

		}

		private void comboBox_username_Selected(object sender, RoutedEventArgs e)
		{
			CrudUser.Selected = CrudUser.SetSelected<User>(comboBox_username.SelectedItem);
		}
	}
}
