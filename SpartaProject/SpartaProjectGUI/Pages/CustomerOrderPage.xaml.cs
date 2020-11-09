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
	/// Interaction logic for CustomerOrderPage.xaml
	/// </summary>
	public partial class CustomerOrderPage : Page
	{
		GUILogic logic = new GUILogic();
		CRUDManagerOrder CrudOrder = new CRUDManagerOrder();
		CRUDManagerUser CrudUser;
		public CustomerOrderPage(CRUDManagerUser crudUser)
		{
			CrudUser = crudUser;
			InitializeComponent();
			PopulateOrderList();
			CustomEvents.current.OnNewOrderPlaced += PopulateOrderList;
		}

		private void PopulateOrderList()
		{
			using (ProjectContext db = new ProjectContext())
			{
				Customer currentCustomer = db.Customers.Where(c => c.UserId == CrudUser.Selected.UserId).FirstOrDefault();
				List<Order> customerOrders = db.Orders.Where(o => o.CustomerId == currentCustomer.CustomerId).ToList();
				listBox_myOrders.ItemsSource = customerOrders;
			}
		}
	}
}
