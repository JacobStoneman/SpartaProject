using SpartaProjectBusiness;
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
	public partial class LoginWindow : Window
	{
		CRUDManagerSeller crudSeller = new CRUDManagerSeller();
		CRUDManagerCustomer crudCustomer = new CRUDManagerCustomer();
		CRUDManagerUser crudUser = new CRUDManagerUser();

		public LoginWindow()
		{
			InitializeComponent();


			//using (ProjectContext db = new ProjectContext())
			//{
			//	foreach(var user in db.Users)
			//	{
			//		db.Users.Remove(user);
			//	}
			//	db.SaveChanges();
			//}

			PopulateUserBox();
		}

		private void PopulateUserBox()
		{
			using (ProjectContext db = new ProjectContext()) 
			{	
				comboBox_username.ItemsSource = crudUser.RetrieveAll(db.Users);
			}
		}

		private void button_configure_user_Click(object sender, RoutedEventArgs e)
		{
			AccountConfig config = new AccountConfig(crudUser);
			config.Closed += AccountConfigClosed;
			config.ShowDialog();
		}
		private void AccountConfigClosed(object sender, EventArgs e)
		{
			PopulateUserBox();
		}

		private void button_login_Click(object sender, RoutedEventArgs e)
		{
			if(textBox_password.Text == crudUser.Selected.Password)
			{
				MessageBox.Show("Password Correct");
			} else
			{
				MessageBox.Show("Password Incorrect");
			}

			//CustomerWindow win = new CustomerWindow();
			//Content = win;
		}

		private void comboBox_username_Selected(object sender, RoutedEventArgs e)
		{
			crudUser.Selected = crudUser.SetSelected<User>(comboBox_username.SelectedItem);
		}
	}
}
