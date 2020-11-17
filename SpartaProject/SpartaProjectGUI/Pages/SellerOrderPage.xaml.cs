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
		GUILogic logic = new GUILogic();
		CRUDManagerOrder CrudOrder = new CRUDManagerOrder();

		ProductGrid pGrid;

		public SellerOrderPage()
		{
			InitializeComponent();
			pGrid = new ProductGrid(textBlock_product_id_value, textBlock_product_name_value, textBlock_product_price_value, textBlock_product_rating_value, image_product);
			PopulateOrderLists();
			ToggleButtons();
			CustomEvents.current.OnProductDeleted += PopulateOrderLists;
		}

		private void PopulateOrderLists()
		{
			using (ProjectContext db = new ProjectContext())
			{
				List<Order> allOrders = CrudOrder.RetrieveAll(db.Orders);
				List<Order> newOrders = new List<Order>();
				List<Order> shippedOrders = new List<Order>();

				foreach(Order o in allOrders)
				{
					if (o.Shipped)
					{
						shippedOrders.Add(o);
					} else
					{
						newOrders.Add(o);
					}
				}

				listBox_newOrders.ItemsSource = newOrders;
				listBox_shippedOrders.ItemsSource = shippedOrders;
			}
		}

		private void button_markOrder_Click(object sender, RoutedEventArgs e)
		{
			CrudOrder.MarkAsShipped(CrudOrder.Selected);
			PopulateOrderLists();
		}

		private void ToggleButtons()
		{
			if(CrudOrder.Selected == null)
			{
				button_deleteOrder.IsEnabled = false;
				button_markOrder.IsEnabled = false;
			} else
			{
				if (CrudOrder.Selected.Shipped)
				{
					button_deleteOrder.IsEnabled = true;
					button_markOrder.IsEnabled = false;
				} else
				{
					button_deleteOrder.IsEnabled = false;
					button_markOrder.IsEnabled = true;
				}
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
				using (ProjectContext db = new ProjectContext())
				{
					Product selectedProduct = db.Products.Where(p => p.ProductId == CrudOrder.Selected.ProductId).FirstOrDefault();
					pGrid.Focus = selectedProduct;
				}
			}
		}

		private void listBox_newOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listBox_newOrders.SelectedItem != null)
			{
				listBox_shippedOrders.SelectedItem = null;
				CrudOrder.Selected = CrudOrder.SetSelected<Order>(listBox_newOrders.SelectedItem);
				ToggleButtons();
				SetSelectedProductGrid();
			}
		}

		private void listBox_shippedOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listBox_shippedOrders.SelectedItem != null)
			{
				listBox_newOrders.SelectedItem = null;
				CrudOrder.Selected = CrudOrder.SetSelected<Order>(listBox_shippedOrders.SelectedItem);
				ToggleButtons();
				SetSelectedProductGrid();
			}
		}

		private void button_deleteOrder_Click(object sender, RoutedEventArgs e)
		{
			using (ProjectContext db = new ProjectContext())
			{
				CrudOrder.Delete(db, db.Orders, CrudOrder.Selected);
			}
			CrudOrder.Selected = null;
			SetSelectedProductGrid();
			PopulateOrderLists();
		}
	}
}
