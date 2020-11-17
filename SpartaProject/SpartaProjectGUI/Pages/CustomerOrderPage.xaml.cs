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
		CRUDManagerOrder CrudOrder = new CRUDManagerOrder();
		CRUDManagerProduct CrudProduct = new CRUDManagerProduct();
		CRUDManagerUser CrudUser;

		ProductGrid pGrid;

		public CustomerOrderPage(CRUDManagerUser crudUser)
		{
			CrudUser = crudUser;
			InitializeComponent();
			pGrid = new ProductGrid(textBlock_product_id_value, textBlock_product_name_value, textBlock_product_price_value, textBlock_product_rating_value,image_product);
			PopulateOrderList();
			CustomEvents.current.OnNewOrderPlaced += PopulateOrderList;
		}

		private void PopulateOrderList()
		{
			using (ProjectContext db = new ProjectContext())
			{
				Customer currentCustomer = db.Customers.Where(c => c.UserId == CrudUser.Selected.UserId).FirstOrDefault();
				List<Order> customerOrders = db.Orders.Where(o => o.CustomerId == currentCustomer.CustomerId).ToList();
				List<OrderItem> listItems = new List<OrderItem>();

				foreach(Order o in customerOrders)
				{
					if (o.Shipped)
					{
						BitmapImage newImage = new BitmapImage(new Uri(@"\Images\shipped.png", UriKind.Relative));
						listItems.Add(new OrderItem() {Order = o, OrderDetails = o.ToString(), OrderStatus = newImage });
					} else
					{
						listItems.Add(new OrderItem() {Order = o, OrderDetails = o.ToString(), OrderStatus = null });
					}
				}

				listBox_myOrders.ItemsSource = listItems;
			}
		}

		private void SetSelectedProductGrid()
		{
			if (CrudOrder.Selected == null)
			{
				pGrid.InitialiseProductInfoGrid();
			}
			else
			{
				pGrid.Focus = CrudProduct.Selected;
			}
		}

		private void button_deleteOrder_Click(object sender, RoutedEventArgs e)
		{
			if (CrudOrder.Selected.Shipped)
			{
				MessageBox.Show("This order has been shipped and can no longer be cancelled");
			}
			else
			{
				CrudOrder.Delete(CrudOrder.Selected);
				CrudOrder.Selected = null;
				CrudProduct.Selected = null;
				SetSelectedProductGrid();
				PopulateOrderList();
			}
		}

		private void listBox_myOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listBox_myOrders.SelectedItem != null)
			{
				OrderItem selectedItem = listBox_myOrders.SelectedItem as OrderItem;
				CrudOrder.Selected = CrudOrder.SetSelected<Order>(selectedItem.Order);
				CrudProduct.Selected = CrudProduct.GetProductById(CrudOrder.Selected.ProductId);
				SetSelectedProductGrid();
			}
		}
	}

	//Used to Set individual elements of listbox item
	public class OrderItem
	{
		public Order Order { get; set; }
		public string OrderDetails { get; set; }
		public ImageSource OrderStatus { get; set; }
	}
}
