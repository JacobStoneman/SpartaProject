using SpartaProjectBusiness;
using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpartaProjectGUI
{
	/// <summary>
	/// Interaction logic for AccountConfig.xaml
	/// </summary>
	public partial class AccountConfig : Window
	{
		CRUDManagerUser CrudUser;
		public AccountConfig(CRUDManagerUser crudUser)
		{
			CrudUser = crudUser;
			InitializeComponent();
			InitialiseValues();
		}

		private void InitialiseValues()
		{
			if (CrudUser.Selected != null)
			{
				textBlock_userID_value.Text = CrudUser.Selected.UserId.ToString();
				textBox_name_value.Text = CrudUser.Selected.Name;
				textBox_password_value.Text = CrudUser.Selected.Password;

				if (CrudUser.Selected.AccountType == 0)
				{
					radioButton_seller.IsChecked = true;
					radioButton_customer.IsChecked = false;
				}
				else
				{
					radioButton_seller.IsChecked = true;
					radioButton_customer.IsChecked = true;
				}
			}
		}

		private void button_add_Click(object sender, RoutedEventArgs e)
		{
			using (ProjectContext db = new ProjectContext())
			{
				if (db.Users.Any(u => u.Name == textBox_name_value.Text))
				{
					MessageBox.Show($"User: {textBox_name_value.Text} already exists");
					return;
				}
			}
			if (radioButton_seller.IsChecked == true)
			{
				CrudUser.Create(textBox_name_value.Text, textBox_password_value.Text, 0);
				MessageBox.Show($"Seller: {textBox_name_value.Text} created");

			} else if (radioButton_customer.IsChecked == true)
			{
				CrudUser.Create(textBox_name_value.Text, textBox_password_value.Text, 1);
				MessageBox.Show($"Customer: {textBox_name_value.Text} created");
			} else
			{
				MessageBox.Show("Please select a user type");
			}
		}

		private void button_delete_Click(object sender, RoutedEventArgs e)
		{
			CrudUser.Delete(CrudUser.Selected);

			MessageBox.Show($"User: {textBox_name_value.Text} deleted");
			CrudUser.Selected = null;
			textBlock_userID_value.Text = string.Empty;
			textBox_name_value.Text = string.Empty;
			textBox_password_value.Text = string.Empty;
		}

		private void button_update_Click(object sender, RoutedEventArgs e)
		{
			CrudUser.Update(CrudUser.Selected, textBox_name_value.Text,textBox_password_value.Text);
			MessageBox.Show($"User: {textBox_name_value.Text} updated");
		}
	}
}
