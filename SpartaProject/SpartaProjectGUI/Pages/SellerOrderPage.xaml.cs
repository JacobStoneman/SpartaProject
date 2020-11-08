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
	/// <summary>
	/// Interaction logic for SellerOrderPage.xaml
	/// </summary>
	public partial class SellerOrderPage : Page
	{
		CRUDManagerOrder CrudOrder = new CRUDManagerOrder();
		public SellerOrderPage()
		{
			InitializeComponent();
			PopulateNewOrders();
		}

		private void PopulateNewOrders()
		{
			using (ProjectContext db = new ProjectContext())
			{
				listBox_newOrders.ItemsSource = CrudOrder.RetrieveAll(db.Orders);
			}
		}
	}
}
