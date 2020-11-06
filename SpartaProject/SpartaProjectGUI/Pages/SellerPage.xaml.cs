﻿using SpartaProjectBusiness;
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

namespace SpartaProjectGUI
{
	/// <summary>
	/// Interaction logic for SellerPage.xaml
	/// </summary>
	public partial class SellerPage : Page
	{
		CRUDManagerUser CrudUser = new CRUDManagerUser();
		public SellerPage(CRUDManagerUser crudUser)
		{
			CrudUser = crudUser;
			InitializeComponent();
		}

		private void button_logout_Click(object sender, RoutedEventArgs e)
		{
			LoginWindow win = new LoginWindow();
			Content = win;
			CrudUser.Selected = null;
		}
	}
}