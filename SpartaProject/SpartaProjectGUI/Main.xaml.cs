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
	/// Interaction logic for Main.xaml
	/// </summary>
	public partial class Main : Window
	{
		public Main()
		{
			InitializeComponent();
			ReturnToLogin();
		}

		public void ReturnToLogin()
		{
			main.Navigate(new LoginPage(main));
		}

		public void SetTopBarEnabled(bool enabled)
		{
			button_logout.IsEnabled = enabled;

			if (enabled)
			{
				textBlock_user_info.Visibility = Visibility.Visible;
				button_logout.Visibility = Visibility.Visible;
			} else
			{
				textBlock_user_info.Visibility = Visibility.Hidden;
				button_logout.Visibility = Visibility.Hidden;
			}
		}

		private void button_logout_Click(object sender, RoutedEventArgs e)
		{
			ReturnToLogin();
		}

		private void main_Navigated(object sender, NavigationEventArgs e)
		{
			Page current = main.Content as Page;
			if(current.Title == "LoginPage")
			{
				SetTopBarEnabled(false);
			} else
			{
				SetTopBarEnabled(true);
			}
		}
	}
}
