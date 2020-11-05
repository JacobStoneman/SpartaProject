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
using System.Windows.Shapes;

namespace SpartaProjectGUI
{
	/// <summary>
	/// Interaction logic for AccountConfig.xaml
	/// </summary>
	public partial class AccountConfig : Window
	{
		CRUDManagerSeller CrudSeller;
		CRUDManagerCustomer CrudCustomer;
		public AccountConfig(CRUDManagerSeller crudSeller, CRUDManagerCustomer crudCustomer)
		{
			CrudSeller = crudSeller;
			CrudCustomer = crudCustomer;
			InitializeComponent();
		}

		private void button_add_Click(object sender, RoutedEventArgs e)
		{
			if (radioButton_customer.IsChecked == true)
			{

			} else if(radioButton_seller.IsChecked == true)
			{
				//CrudSeller.Create(textBox_name_value.Text);
			}
		}
	}
}
